using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RegiX.IdentityServer.RegiXClientUsers;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Common;
using TechnoLogica.Mail;

namespace TechnoLogica.RegiX.IdentityServer.ClientAppCredentials
{
    public class ClientProfileService : IProfileClientService
    {
        private readonly IMailService emailService;
        protected RegiXClientContext RegiXClientContext { get; set; }
        protected PublicClientSettings PublicClientSettings { get; set; }
        private readonly SMTPSettings _smtpSettings;

        public virtual string ClientId => "regixclientangular";
        protected virtual string AugmentedUsername(string scheme, string username) => username;

        public ClientProfileService(
            RegiXClientContext regiXClientContext, 
            IConfiguration configuration,
            IMailService emailService)
        {
            this.emailService = emailService;
            RegiXClientContext = regiXClientContext;
            PublicClientSettings = configuration.GetSettings<PublicClientSettings>();
            _smtpSettings = configuration.GetSettings<SMTPSettings>();
        }

        public async Task<UserInfo> FindByUsername(string scheme, string username)
        {
            username = AugmentedUsername(scheme, username);
            var user =
                RegiXClientContext
                .Users
                .Where(u => u.UserName == username)
                .Select(u =>
                   new UserInfo()
                   {
                       Username = u.UserName,
                       SubjectId = u.Id.ToString(),
                       Name = u.Name,
                       Active = u.IsActive
                   }
                )
                .FirstOrDefault();
            if (user == null && (scheme == "EAuthHandlerV2" || scheme == "EAuthHandler"))
            {
                string identifierType = "PNOBG";
                string identifier = username;
                string[] splitted = username.Split('-');
                if (splitted.Length == 2)
                {
                    identifierType = splitted[0];
                    identifier = splitted[1];
                }
                user = (from u in RegiXClientContext.Users
                       join ue in RegiXClientContext.UsersEAuth on u.Id equals ue.Id
                       where ue.Identifier == identifier && ue.IdentifierType == identifierType
                       select new UserInfo()
                       {
                           Username = u.UserName,
                           SubjectId = u.Id.ToString(),
                           Name = u.Name,
                           Active = u.IsActive
                       })
                       .FirstOrDefault();                
            }
            return user;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userID = Convert.ToDecimal((context.Subject.Identity as ClaimsIdentity).Claims.FirstOrDefault(c => c.Type == "sub").Value);
            var user = 
                RegiXClientContext.Set<Users>()
                .AsNoTracking()
                .Include(u => u.FederationUsers)
                .Include(u => u.UsersToRoles)
                .Where(u => u.Id == userID)
                .Select(u => new
                {
                    u.Name,
                    u.UserName,
                    u.UserType,
                    UserAuthorityId = (u.FederationUsers != null) ? (int?)u.FederationUsers.UserAuthorityId : (int?)null,
                    UsersToRoles = u.UsersToRoles,
                    RoleTypes = u.UsersToRoles.Select(r => r.Role.RoleType).Distinct()
                })
                .FirstOrDefault();
            if (user != null)
            {
                context.IssuedClaims.Add(new Claim("FullName", user.Name));
                context.IssuedClaims.Add(new Claim("UserName", user.UserName));
                if (user.UserType == UserTypeEnum.PUBLIC)
                {
                    string publicAdministrationCode = PublicClientSettings.PublicAdministrationCode;
                    var authorityId = RegiXClientContext.Administrations.Where(a => a.Code == publicAdministrationCode).Select(a => a.Id).First();
                    context.IssuedClaims.Add(new Claim("AdministrationID", authorityId.ToString()));
                    // Add dedicated columsn for public user authentication data
                    var publicUserData = user.UserName.Replace("public-user-", "").Split('-');
                    if (publicUserData.Length == 2)
                    {
                        if (publicUserData[0] == "PNF")
                        {
                            // IdentitifierEnum in Angular/API expects LNCH instead of PNF
                            context.IssuedClaims.Add(new Claim("IdentifierType", "LNCH"));
                        }
                        else
                        {
                            context.IssuedClaims.Add(new Claim("IdentifierType",  publicUserData[0]));
                        }
                        context.IssuedClaims.Add(new Claim("Identifier", publicUserData[1]));
                    }
                }
                if (user.UserAuthorityId.HasValue)
                {
                    context.IssuedClaims.Add(new Claim("AdministrationID", user.UserAuthorityId.ToString()));
                }
                if (user.UsersToRoles != null && user.UsersToRoles.Count > 0)
                {
                    foreach (var userToRole in user.UsersToRoles)
                    {
                        context.IssuedClaims.Add(new Claim("RoleID", userToRole.RoleId.ToString()));
                    }
                    foreach (var roleType in user.RoleTypes)
                    {
                        context.IssuedClaims.Add(new Claim(JwtClaimTypes.Role, GetRole(roleType, user.UserAuthorityId)));
                    }
                }
                else
                {
                    // The user has no roles; Set basic role as default (needed for directly associated reports to work)
                    context.IssuedClaims.Add(new Claim(JwtClaimTypes.Role, "BASIC"));
                }

            }
        }

        private string GetRole(int role, int? userAuthorityId)
        {
            switch (role)
            {
                case 0:
                    {
                        return "BASIC";
                    }
                case 1:
                    {
                        return "PUBLIC";
                    }
                case 2:
                    {
                        return userAuthorityId.HasValue && userAuthorityId == 0 ? "GLOBAL_ADMIN" : "ADMIN";
                    }
                default:
                    {
                        throw new ApplicationException($"No role type defined for value: {role}");
                    }
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = Convert.ToDecimal(subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value);
            var user = RegiXClientContext.Users.Where(u => u.Id == subjectId).FirstOrDefault();
            context.IsActive = user != null;
        }

        public async Task<bool> ValidateCredentials(string scheme, string username, string password)
        {
            var user = RegiXClientContext.Users.Where(u => u.UserName == username).FirstOrDefault();

            if (user.UserType == UserTypeEnum.LOCAL)
            {
                var federatedUser = RegiXClientContext.FederationUsers.FirstOrDefault(u => u.Id == user.Id);
                var result = (from x in RegiXClientContext.LocalUsers
                             join xu in RegiXClientContext.Users on x.Id equals xu.Id
                             where xu.UserName == username
                             select new
                             {
                                 Id = x.Id,
                                 Password = x.Password,
                                 IsPasswordMigrated = x.IsPasswordMigrated,
                                 xu.IsActive
                             }).FirstOrDefault();
                bool isValid = false;
                if (!result.IsPasswordMigrated)
                {
                    string hashedPassword = PassUtil.CreateSHA256Pass(password, false);
                    isValid = (result.Password == hashedPassword);
                    if (isValid)
                    {
                        var localUser = RegiXClientContext.LocalUsers.Find(user.Id);
                        string hashedMigratedPassword = PassUtil.CreateSHA256Pass(password);
                        localUser.IsPasswordMigrated = true;
                        localUser.Password = hashedMigratedPassword;
                        RegiXClientContext.SaveChanges();
                    }                    
                }
                else
                {
                    isValid = PassUtil.VerifyPassword(result.Password, password);
                }                
                return isValid;
            }
            else
            {
                return false;
            }
        }

        public async virtual Task<UserRegistrationResult> RegisterUser(string scheme, string name, string userName, string email, string password, Dictionary<string, string> additionalAttributes)
        {
            switch (scheme)
            {
                default:
                {
                    if (additionalAttributes.ContainsKey("administrationID") &&
                        Int32.TryParse(additionalAttributes["administrationID"], out int administrationID))
                    {
                        return await RegisterLocalUser(
                            name, 
                            email, 
                            password, 
                            administrationID, 
                            additionalAttributes["administrationName"], 
                            additionalAttributes.GetValueOrDefault("identifierType"), 
                            additionalAttributes.GetValueOrDefault("identifier"));
                    }
                    else
                    { 
                        return new UserRegistrationResult()
                        {
                            Succeeded = false,
                            Errors = new List<UserRegistrationError>() {
                                new UserRegistrationError() {
                                    Code = "administrationID",
                                    Description = "Parameter 'administrationID' should be provided as additional attribute!"
                                }
                            }
                        };
                    }
                }
            }
        }

        private async Task<UserRegistrationResult> RegisterLocalUser(
            string name, 
            string email, 
            string password, 
            int administrationID, 
            string administrationName, 
            string identifierType, 
            string identifier)
        {

            //email is used for userName
            try
            {
                var user = new Users
                {
                    Name = name,
                    UserType = UserTypeEnum.LOCAL,
                    UserName = email,
                    Email = email,
                    IsActive = false,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "identity-server"
                };

                FederationUsers fUser = new FederationUsers();
                fUser.Position = "Позиция по подразбиране";
                fUser.UserName = email;
                fUser.UserAuthorityId = administrationID;
                user.FederationUsers = fUser;



                var localUser = new LocalUsers();
                localUser.IsPasswordMigrated = true;
                localUser.Password = PassUtil.CreateSHA256Pass(password);
                localUser.IdNavigation = fUser;

                RegiXClientContext.Users.Add(user);
                RegiXClientContext.FederationUsers.Add(fUser);
                RegiXClientContext.LocalUsers.Add(localUser);

                if (!string.IsNullOrEmpty(identifier) && !string.IsNullOrEmpty(identifierType))
                {
                    UsersEAuth uEAuth = new UsersEAuth();
                    uEAuth.Identifier = identifier;
                    uEAuth.IdentifierType = identifierType;
                    uEAuth.IdNavigation = fUser;
                    RegiXClientContext.UsersEAuth.Add(uEAuth);
                }

                //find all admins for specific administrationID and send email notification to them
                var adminsUserNames =
                    RegiXClientContext.Set<Users>()
                        .AsNoTracking()
                        .Include(u => u.FederationUsers)
                        .Include(u => u.UsersToRoles)
                        .Where(u => ((int?) u.FederationUsers.UserAuthorityId == administrationID) &&
                                    u.UsersToRoles.Select(x => x.Role.RoleType).Contains(2))//admin == roleType (2) 
                        .Select(u => u.UserName)
                        .ToArray();
               
                RegiXClientContext.SaveChanges();
                if (adminsUserNames.Length > 0)
                {
                    //TODO: adminsUserNames insted of bbotev and fix userNames to be Emails
                   // this.emailService.SendClientAppUserRegistrationNotificationMessage(new[] { "bbotev@technologica.com" }, email, administrationName);
                }
                return new UserRegistrationResult() { Succeeded = true };
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message;
                if (ex.InnerException.Message.Contains(@"Violation of UNIQUE KEY constraint 'UQ__USERS__USER_NAME'")||
                    ex.InnerException.Message.Contains(@"Violation of UNIQUE KEY constraint 'UQ__USERS__EMAIL'"))
                {
                    errorMsg = "Този Email е зает!";
                }
               
                return new UserRegistrationResult()
                {
                    Succeeded = false,
                    Errors = new List<UserRegistrationError>() {
                        new UserRegistrationError() {
                            Code = ex.GetType().Name,
                            Description = errorMsg
                        }
                    }
                };
            }
        }

        public Task SignOutAsync()
        {
            // No implementation needed
            return Task.CompletedTask;
        }

        public async Task<bool> ChangePassword(string scheme, string username, string password, string newPassword)
        {
            var result = await ValidateCredentials(scheme, username, password);
            if (result)
            {
                var user = RegiXClientContext.Users.Where(u => u.UserName == username).FirstOrDefault();
                
                if (user.UserType == UserTypeEnum.LOCAL)
                {
                    var localUser = RegiXClientContext.LocalUsers.Find(user.Id);

                    string hashedPassword = PassUtil.CreateSHA256Pass(newPassword);
                    localUser.Password = hashedPassword;
                    RegiXClientContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SendPasswordResetTokenAsync(string scheme, string baseAddress, string email)
        {
            var user =
             RegiXClientContext
             .Users
             .Where(u => u.Email == email)
             .FirstOrDefault();

            if (user != null)
            {
                var now = DateTime.UtcNow;

                var token = RegiXClientContext
                    .Users
                    .Where(u => u.Email == email && u.PswdVerTokenExpirationDate > now)
                    .Select(u =>
                    new
                    {
                        u.PswdVerificationToken
                    }
                    )
                    .FirstOrDefault()?.PswdVerificationToken;
                if (string.IsNullOrEmpty(token))
                {
                    using (var prng = new RNGCryptoServiceProvider())
                    {
                        token = GenerateToken(prng);
                    }
                    user.PswdVerificationToken = token;
                    user.PswdVerTokenExpirationDate = DateTime.UtcNow.AddMinutes(1440);
                    RegiXClientContext.SaveChanges();
                }

                MailMessage message = new MailMessage(_smtpSettings.From, email);
                message.Subject = Resources.ResetPasswordSubejct;
                Attachment att = new Attachment("logo.png");
                att.ContentDisposition.Inline = true;
                message.IsBodyHtml = true;
                message.Attachments.Add(att);
                message.Body =
                    string.Format(
                        Resources.ResetPasswordBody,
                        att.ContentId,
                        $"{baseAddress}?clientId={WebUtility.UrlEncode(ClientId)}" +
                        $"&resetToken={WebUtility.UrlEncode(token)}" +
                        $"&eMail={WebUtility.UrlEncode(email)}"
                    );
                await emailService.SendMailAsync(message);
                return true;
            }
            else
            {
                return false;
            }
        }

        private const int TokenSizeInBytes = 16;

        internal static string GenerateToken(RandomNumberGenerator generator)
        {
            byte[] tokenBytes = new byte[TokenSizeInBytes];
            generator.GetBytes(tokenBytes);
            return UrlTokenEncode(tokenBytes);
        }

        private static string UrlTokenEncode(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (input.Length < 1)
                return String.Empty;
            char[] base64Chars = null;

            ////////////////////////////////////////////////////////
            // Step 1: Do a Base64 encoding
            string base64Str = Convert.ToBase64String(input);
            if (base64Str == null)
                return null;

            int endPos;
            ////////////////////////////////////////////////////////
            // Step 2: Find how many padding chars are present in the end
            for (endPos = base64Str.Length; endPos > 0; endPos--)
            {
                if (base64Str[endPos - 1] != '=') // Found a non-padding char!
                {
                    break; // Stop here
                }
            }

            ////////////////////////////////////////////////////////
            // Step 3: Create char array to store all non-padding chars,
            //      plus a char to indicate how many padding chars are needed
            base64Chars = new char[endPos + 1];
            base64Chars[endPos] = (char)((int)'0' + base64Str.Length - endPos); // Store a char at the end, to indicate how many padding chars are needed

            ////////////////////////////////////////////////////////
            // Step 3: Copy in the other chars. Transform the "+" to "-", and "/" to "_"
            for (int iter = 0; iter < endPos; iter++)
            {
                char c = base64Str[iter];

                switch (c)
                {
                    case '+':
                        base64Chars[iter] = '-';
                        break;

                    case '/':
                        base64Chars[iter] = '_';
                        break;

                    case '=':
                        Debug.Assert(false);
                        base64Chars[iter] = c;
                        break;

                    default:
                        base64Chars[iter] = c;
                        break;
                }
            }
            return new string(base64Chars);
        }

        public async Task<ResetPasswordResult> ResetPasswordAsync(string scheme, string email, string token, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentException("Argument {0} cannot be empty!", "newPassword");
            }
            var now = DateTime.UtcNow;
            var user =
             RegiXClientContext
             .Users
             .Where(u => u.Email == email && u.PswdVerificationToken == token && u.PswdVerTokenExpirationDate > now)
             .FirstOrDefault();

            if (user != null)
            {
                var localUser = RegiXClientContext.LocalUsers.Find(user.Id);
                var encodedPassword = PassUtil.CreateSHA256Pass(newPassword);
                localUser.Password = encodedPassword;
                localUser.IsPasswordMigrated = true;
                user.PswdVerificationToken = null;
                user.PswdVerTokenExpirationDate = null;
                RegiXClientContext.SaveChanges();
                return new ResetPasswordResult() { Succeeded = true };
            }
            else
            {
                var result = new ResetPasswordResult()
                {
                    Succeeded = false
                };
                var errors = new List<ResetPasswordError>();
                errors.Add(
                    new ResetPasswordError()
                    {
                        Code = "TokenExpiredOrNotFound",
                        Description = Resources.TokenExpiredOrNotFound
                    }
                );
                result.Errors = errors;
                return result;
            }
        }

        /// <summary>
        /// Converts a hexadecimal string to a byte array. Used to convert encryption key values from the configuration.
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
    }


    public class CitizensClientProfileService : ClientProfileService
    {
        public override string ClientId => "regixclientcitizensangular";

        protected override string AugmentedUsername(string scheme, string username)
        {
            if (scheme == "EAuthHandlerV2" || scheme == "EAuthHandler")
            {
                if (username.StartsWith("PI:BG-"))
                {
                    string identifier = username.Replace("PI:BG-", "");
                    return $"public-user-PNF-{identifier}";
                }
                else
                {
                    return $"public-user-EGN-{username}";
                }
            }
            else
            {
                return username;
            }
        }

        public CitizensClientProfileService(
            RegiXClientCitizensContext regiXClientContext, 
            IConfiguration configuration,
            IMailService emailService) : base(regiXClientContext, configuration, emailService)
        {
        }

        public async override Task<UserRegistrationResult> RegisterUser(string scheme, string name, string userName, string email, string password, Dictionary<string, string> additionalAttributes)
        {
            switch (scheme)
            {
                case TechnoLogica.Authentication.EDelivery.EDeliveryDefaults.AuthenticationScheme:
                {
                    var identifier = additionalAttributes["eDeliveryIdentifier"];
                    var idType = additionalAttributes["eDeliveryIdType"];
                    return await RegisterPublicUser(idType, identifier);
                }
                case "EAuthHandlerV2":
                {
                    var idType = "EGN";
                    var identifier = userName;
                    if (userName.StartsWith("PI:BG-"))
                    {
                        idType = "PNF";
                        identifier = userName.Replace("PI:BG-", "");
                    }
                    return await RegisterPublicUser(idType, identifier);
                }
                default:
                {
                    return await base.RegisterUser(scheme, name, userName, email, password, additionalAttributes);
                }
            }
        }

        private async Task<UserRegistrationResult> RegisterPublicUser(string idType, string identifier)
        {
            int administrationId, roleId = 0;
            try
            {
                administrationId = RegiXClientContext
                    .Administrations
                    .Where(a => a.Code == PublicClientSettings.PublicAdministrationCode)
                    .Select(a => a.Id)
                    .First();

                roleId = RegiXClientContext
                    .Roles
                    .Where(
                        a => a.AuthorityId.HasValue &&
                             a.AuthorityId.Value == administrationId &&
                             a.Name == PublicClientSettings.PublicRoleName).Select(a => a.Id)
                    .First();
            }
            catch (Exception ex)
            {
                return new UserRegistrationResult()
                {
                    Succeeded = false,
                    Errors = new List<UserRegistrationError>() {
                        new UserRegistrationError() {
                            Code = "PUBLIC_SETTINGS_ERROR",
                            Description = "Грешка при извличане на настройки за публична роля и пулична администрация"
                        }
                    }
                };
            }


            try
            {
                var user = new Users();
                user.Name = identifier;
                user.UserType = UserTypeEnum.PUBLIC;
                user.UserName = $"public-user-{idType}-{identifier}";
                user.IsActive = true;
                user.CreatedOn = DateTime.Now;
                user.CreatedBy = "identity-server";

                var usersToRoles = new UsersToRoles();
                usersToRoles.User = user;
                usersToRoles.RoleId = roleId;
                usersToRoles.CreatedOn = DateTime.Now;
                usersToRoles.CreatedBy = "identity-server";

                RegiXClientContext.Users.Add(user);
                RegiXClientContext.UsersToRoles.Add(usersToRoles);
                RegiXClientContext.SaveChanges();
                return new UserRegistrationResult() { Succeeded = true };
            }
            catch (Exception ex)
            {
                return new UserRegistrationResult()
                {
                    Succeeded = false,
                    Errors = new List<UserRegistrationError>() {
                        new UserRegistrationError() {
                            Code = ex.GetType().Name,
                            Description = ex.Message
                        }
                    }
                };
            }
        }
    }


    /// <summary>
    /// For Test purposes
    /// </summary>
    public class LocalClientProfileService : ClientProfileService
    {
        public override string ClientId => "regixlocalclientangular";

        public LocalClientProfileService(
            RegiXClientContext regiXClientContext,
            IConfiguration configuration,
            IMailService emailService) : base(regiXClientContext, configuration, emailService)
        {
        }
    }

    public enum UserTypeEnum
    {
        NONE = 0,
        PUBLIC = 1,
        LOCAL = 2,
        FEDERATION = 3
    }

    public class PassUtil
    {
        private const int SALT_LENGTH = 24;

        public static string CreateSHA256Pass(string regularPass, bool generateWithSalt = true)
        {
            if (generateWithSalt)
            {
                return CreateSHA256Pass(regularPass, GenerateSalt());
            }
            else
            {
                return CreateSHA256Pass(regularPass);
            }
        }

        private static string CreateSHA256Pass(string regularPass)
        {
            if (regularPass != null && regularPass != string.Empty)
            {
                SHA256Managed crypt = new SHA256Managed();

                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(regularPass), 0, Encoding.UTF8.GetByteCount(regularPass));

                return ConvertToHEX(crypto);
            }
            else
            {
                return null;
            }
        }

        private static string GenerateSalt()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            Random rand = new Random();
            int startIndex = rand.Next(0, guid.Length - 1);
            if ((startIndex + SALT_LENGTH) > guid.Length)
            {
                startIndex = startIndex - ((startIndex + SALT_LENGTH) - guid.Length);
            }

            string salt = guid.Substring(startIndex, SALT_LENGTH);
            return salt;
        }

        private static string CreateSHA256Pass(string regularPass, string salt)
        {
            string hash = null;
            if (!string.IsNullOrEmpty(regularPass) && !string.IsNullOrEmpty(salt))
            {
                var hmac = HMAC.Create("HMACSHA1");

                hmac.Key = Encoding.UTF8.GetBytes(salt);
                byte[] buffer = Encoding.UTF8.GetBytes(regularPass);
                buffer = hmac.ComputeHash(buffer);
                hash = salt + ConvertToHEX(buffer);
            }
            return hash;
        }

        public static bool VerifyPassword(string expectedPassword, string password)
        {
            string salt = GetSaltPart(expectedPassword);
            return CreateSHA256Pass(password, salt) == expectedPassword;
        }

        private static string ConvertToHEX(byte[] array)
        {
            StringBuilder hash = new StringBuilder();
            foreach (byte theByte in array)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static string GetSaltPart(string hashedPassword)
        {
            string salt = hashedPassword.Substring(0, SALT_LENGTH);
            return salt;
        }
    }
}
