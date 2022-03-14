using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using RegiX.IdentityServer;
using IdentityModel;
using System.Security.Cryptography;
using System.Text;
using TechnoLogica.Authentication.Common;
using Microsoft.Extensions.Configuration;
using TechnoLogica.Mail;
using TechnoLogica.Common;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace TechnoLogica.RegiX.IdentityServer.AdminAppCredentials
{
    public class AdminProfileService : IProfileClientService
    {
        private readonly IMailService _mailService;
        public virtual string ClientId => "regixadminangular";

        private readonly SMTPSettings _smtpSettings;
        protected RegiXAdminContext RegiXAdminContext { get; set; }
        protected AdminAppCredentialsSettings AdminAppCredentialsSettings { get; set; }

        public AdminProfileService(RegiXAdminContext regiXAdminContext, IConfiguration configuration, IMailService emailService)
        {
            _mailService = emailService;
            RegiXAdminContext = regiXAdminContext;
            AdminAppCredentialsSettings = configuration.GetSettings<AdminAppCredentialsSettings>();
            _smtpSettings = configuration.GetSettings<SMTPSettings>();
        }

        public async Task<UserInfo> FindByUsername(string scheme, string username)
        {
            var user =
                RegiXAdminContext
                .Users
                .Where(u => u.UserName == username)
                .Select(u =>
                   new UserInfo()
                   {
                       Username = u.UserName,
                       SubjectId = u.UserId.ToString(),
                       Name = u.Name,
                       Active = u.Active
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
                user = (from u in RegiXAdminContext.Users
                        join ue in RegiXAdminContext.UsersEAuth on u.UserId equals ue.UserId
                        where ue.Identifier == identifier && ue.IdentifierType == identifierType
                        select new UserInfo()
                        {
                            Username = u.UserName,
                            SubjectId = u.UserId.ToString(),
                            Name = u.Name,
                            Active = u.Active
                        })
                       .FirstOrDefault();
            }
            return user;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userID = Convert.ToDecimal((context.Subject.Identity as ClaimsIdentity).Claims.FirstOrDefault(c => c.Type == "sub").Value);
            var user = RegiXAdminContext.Users.Where(u => u.UserId == userID).FirstOrDefault();
            if (user != null)
            {
                context.IssuedClaims.Add(new Claim("FullName", user.Name));
                context.IssuedClaims.Add(new Claim("UserName", user.UserName));
                if (!user.AdministrationId.HasValue && user.IsAdmin)
                {
                    context.IssuedClaims.Add(new Claim(JwtClaimTypes.Role, "GLOBAL_ADMIN"));
                }
                else if (user.AdministrationId.HasValue)
                {
                    context.IssuedClaims.Add(new Claim("AdministrationID", user.AdministrationId.ToString()));
                    context.IssuedClaims.Add(new Claim(JwtClaimTypes.Role, "ADMIN"));
                }
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = Convert.ToDecimal(subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value);
            var user = RegiXAdminContext.Users.Where(u => u.UserId == subjectId).FirstOrDefault();
            context.IsActive = user != null;
        }

        public async Task<bool> ValidateCredentials(string scheme, string username, string password)
        {
            string encodedPassword = GetEncodedPassword(password);
            var user = RegiXAdminContext.Users.Where(u => u.UserName == username).FirstOrDefault();
            return
                user != null &&
                user.Password == encodedPassword;
        }

        private string GetEncodedPassword(string password)
        {
            HMACSHA1 hash = new HMACSHA1 { Key = HexToByte(AdminAppCredentialsSettings.ValidationKey) };
            var encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
            return encodedPassword;
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

        public async Task<UserRegistrationResult> RegisterUser(string scheme, string name, string userName, string email, string password, Dictionary<string, string> additionalAttributes)
        {
            try
            {

                if (!additionalAttributes.ContainsKey("administrationID") ||
                    !Int32.TryParse(additionalAttributes["administrationID"], out int administrationID))
                {
                    throw new ArgumentException("Parameter 'administrationID' should be provided as additional attribute!");
                }
                HMACSHA1 hash = new HMACSHA1 { Key = HexToByte(AdminAppCredentialsSettings.ValidationKey) };
                var encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));

                var now = DateTime.Now;
                var user = new Users
                {
                    Name = name,
                    UserName = userName,
                    Active = false,
                    Password = encodedPassword,
                    IsAnonymous = false,
                    Email = email,
                    IsApproved = true,
                    IsLockedOut = false,
                    IsAdmin = administrationID == 0 ? true : false,
                    AdministrationId = administrationID == 0 ? (decimal?)null : administrationID,
                    CreateDate = now,
                    LastActivityDate = now,
                    LastLoginDate = now,
                    LastPasswordChangedDate = now,
                    LastLockoutDate = now,
                    FailedPswdAnsAtmpWdwStart = now,
                    FailedPswdAtmpWdwStart = now,
                    FailedPswdAnsAtmpCount = 0,
                    FailedPswdAtmpCount = 0
                };
                string identifierType = additionalAttributes.GetValueOrDefault("identifierType");
                string identifier = additionalAttributes.GetValueOrDefault("identifier");
                if (!string.IsNullOrEmpty(identifier) && !string.IsNullOrEmpty(identifierType))
                {
                    UsersEAuth uEAuth = new UsersEAuth();
                    uEAuth.Identifier = identifier;
                    uEAuth.IdentifierType = identifierType;
                    uEAuth.IdNavigation = user;
                    RegiXAdminContext.UsersEAuth.Add(uEAuth);
                }

                RegiXAdminContext.Users.Add(user);
                var allGlobalAdminsEmails =
                        RegiXAdminContext
                            .Users
                            .Where(x => x.AdministrationId == null)
                            .Select(x => x.Email)
                            .ToArray();

                RegiXAdminContext.SaveChanges();
                //TODO: Enable Admin notification
                //string[] testMails = { "bbotev@technologica.com" };//Uncomment to enable mail functionality
                if (allGlobalAdminsEmails.Length > 0)
                {
                    //this.emailService.SendAdminAppUserRegistrationNotificationMessage(testMails, user.UserName, additionalAttributes["administrationName"]);
                }
                return new UserRegistrationResult() { Succeeded = true };
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message;
                if (ex.InnerException != null && ex.InnerException.Message.Contains(@"Violation of UNIQUE KEY constraint 'CK_USER_NAME'"))
                {
                    errorMsg = "Това потребителско име е заето!";
                }
                else if (ex.InnerException != null && ex.InnerException.Message.Contains(@"Violation of UNIQUE KEY constraint 'UQ__USERS__EMAIL'"))
                {
                    errorMsg = "Този Еmail е зает!";
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

        public async Task SignOutAsync()
        {
            // No implementation needed.
        }

        public async Task<bool> ChangePassword(string scheme, string username, string password, string newPassword)
        {
            var result = await ValidateCredentials(scheme, username, password);
            if (result)
            {
                var user = RegiXAdminContext.Users.Where(u => u.UserName == username).FirstOrDefault();
                user.Password = GetEncodedPassword(newPassword);
                RegiXAdminContext.SaveChanges();
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

        public async Task<bool> SendPasswordResetTokenAsync(string scheme, string baseAddress, string email)
        {
            var user =
             RegiXAdminContext
             .Users
             .Where(u => u.Email == email)
             .FirstOrDefault();

            if (user != null)
            {
                var now = DateTime.UtcNow;

                var token = RegiXAdminContext
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
                    RegiXAdminContext.SaveChanges();
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
                await _mailService.SendMailAsync(message);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ResetPasswordResult> ResetPasswordAsync(string scheme, string email, string token, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentException("Argument {0} cannot be empty!", "newPassword");
            }
            var now = DateTime.UtcNow;
            var user =
             RegiXAdminContext
             .Users
             .Where(u => u.Email == email && u.PswdVerificationToken == token && u.PswdVerTokenExpirationDate > now)
             .FirstOrDefault();

            if (user != null)
            {
                HMACSHA1 hash = new HMACSHA1 { Key = HexToByte(AdminAppCredentialsSettings.ValidationKey) };
                var encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(newPassword)));
                user.Password = encodedPassword;
                user.PswdVerificationToken = null;
                user.PswdVerTokenExpirationDate = null;
                RegiXAdminContext.SaveChanges();
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
    }
    /// <summary>
    /// For Test purposes
    /// </summary>
    public class LocalAdminProfileService : AdminProfileService
    {
        public override string ClientId => "regixlocaladminangular";

        public LocalAdminProfileService(RegiXAdminContext regiXAdminContext, IConfiguration configuration, IMailService emailService) : base(regiXAdminContext, configuration, emailService)
        {
        }
    }

    /// <summary>
    /// For Test purposes
    /// </summary>
    public class LocalShortAdminProfileService : AdminProfileService
    {
        public override string ClientId => "regixlocalshortadminangular";

        public LocalShortAdminProfileService(RegiXAdminContext regiXAdminContext, IConfiguration configuration, IMailService emailService) : base(regiXAdminContext, configuration, emailService)
        {
        }
    }
}
