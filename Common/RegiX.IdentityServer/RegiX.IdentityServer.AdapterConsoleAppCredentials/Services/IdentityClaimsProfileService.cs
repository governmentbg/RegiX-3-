using AuthServer.Infrastructure.Data.Identity;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Common;
using TechnoLogica.Mail;

namespace RegiX.IdentityServer.AdapterConsoleAppCredentials.Services
{
    public class IdentityClaimsProfileService : IProfileClientService
    {
        public virtual string ClientId => "regixadapterconsoleangular";

        private const string ROLE_ADMIN = "Admin";
        private const string ROLE_REGULAR_USER = "RegularUser";

        private readonly IMailService _mailService;
        private readonly SMTPSettings _smtpSettings;
        private readonly IUserClaimsPrincipalFactory<AppUser> _claimsFactory;
        private readonly AppIdentityDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;


        public IdentityClaimsProfileService(
            IMailService emailService,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager, 
            IUserClaimsPrincipalFactory<AppUser> claimsFactory,
            AppIdentityDbContext context,
            IConfiguration configuration)
        {
            _mailService = emailService;
            _signInManager = signInManager;
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _context = context;
            _smtpSettings = configuration.GetSettings<SMTPSettings>();
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
                var sub = int.Parse(context.Subject.GetSubjectId());

                var user = _context.Users.Find(sub);

                var roleIds = 
                    _context.UserRoles
                        .Where(x => x.UserId == sub)
                        .Select(x => x.RoleId);

                var roleNames = 
                    _context.Roles
                        .Where(x => roleIds.Contains(x.Id))
                        .Select(x => x.Name)
                        .ToList();

                 var claims = new List<Claim>();
                 claims.Add(new Claim(JwtClaimTypes.GivenName, user.Name));
                 claims.Add(new Claim(JwtClaimTypes.Role, SetRole(roleNames)));
                 claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));

                if (roleNames.Count > 0)
                {
                    foreach (var role in roleNames)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }
                // note: to dynamically add roles (ie. for users other than consumers - simply look them up by sub id
                // need this for role-based authorization - https://stackoverflow.com/questions/40844310/role-based-authorization-with-identityserver4
                context.IssuedClaims = claims;
        }

        private string SetRole(IList<string> roles)
        {
            return roles.Contains(ROLE_ADMIN) ? ROLE_ADMIN : ROLE_REGULAR_USER;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }

        public async Task<bool> ValidateCredentials(string scheme, string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (_userManager.SupportsUserLockout && await _userManager.IsLockedOutAsync(user)) {
                return false;
            }
            else
            {
                if (await this._userManager.CheckPasswordAsync(user, password))
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                    return true;
                }
                else
                {
                    if (_userManager.SupportsUserLockout && await _userManager.GetLockoutEnabledAsync(user))
                    {
                        await _userManager.AccessFailedAsync(user);
                    }
                    return false;
                }
            }
        }

        public async Task<UserInfo> FindByUsername(string scheme, string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return new UserInfo()
                {
                    Username = user.UserName,
                    Name = user.Name,
                    Active = user.IsActive,
                    SubjectId = user.Id.ToString()
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<UserRegistrationResult> RegisterUser(string scheme, string name, string userName, string email, string password, Dictionary<string, string> additionalAttributes)
        {
            var user = new AppUser { UserName = userName, Name = name, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var addedResult = await _userManager.FindByNameAsync(user.UserName);
                await _userManager.AddToRoleAsync(addedResult, "RegularUser");
                return 
                    new UserRegistrationResult() {
                        Succeeded = true 
                    };
            }
            else
            {
                return new UserRegistrationResult()
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(
                        e => new UserRegistrationError(){
                            Code = e.Code, 
                            Description = e.Description 
                        }).ToList()
                };
            }
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> ChangePassword(string scheme, string username, string password, string newPassword)
        {
            var isValid = await ValidateCredentials(scheme, username, password);
            if (isValid)
            {
                var user = await _userManager.FindByNameAsync(username);
                var result = await _userManager.ChangePasswordAsync(user, password, newPassword);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    throw new ApplicationException(string.Join(Environment.NewLine, result.Errors.Select(er => er.Description).ToList()));
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SendPasswordResetTokenAsync(string scheme, string baseAddress, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
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
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
                return new ResetPasswordResult()
                {
                    Succeeded = result.Succeeded,
                    Errors = result.Errors.Select(e => new ResetPasswordError() { Code = e.Code, Description = e.Description })
                };
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
                        Code = "UserNotFound",
                        Description = Resources.UserNotFound
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
    public class LocalIdentityClaimsProfileService : IdentityClaimsProfileService
    {
        public override string ClientId => "regixlocaladapterconsoleangular";

        public LocalIdentityClaimsProfileService(
            IMailService emailService,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IUserClaimsPrincipalFactory<AppUser> claimsFactory,
            AppIdentityDbContext context,
            IConfiguration configuration) : 
            base(
                emailService,
                signInManager, 
                userManager, 
                claimsFactory, 
                context,
                configuration)
        {
        }
    }
}
