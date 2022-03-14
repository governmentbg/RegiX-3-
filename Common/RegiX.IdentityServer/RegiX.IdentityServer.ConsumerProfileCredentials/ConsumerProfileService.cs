using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RegiX.IdentityServer.ConsumerProfileCredentials.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using TechnoLogica.Authentication.Common;
using TechnoLogica.Common;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.Reporting;

[assembly: InternalsVisibleTo("RegiX.IdentityServer.ConsumerProfileCredentials.Tests")]

namespace RegiX.IdentityServer.ConsumerProfileCredentials
{
    public class ConsumerProfileService : IProfileClientService
    {
        public virtual string ClientId => "regixconsumerprofileangular";

        private readonly IMailService _mailService;
        private readonly SMTPSettings _smtpSettings;
        private readonly SignInManager<ConsumerProfileUsers> _signInManager;
        private readonly UserManager<ConsumerProfileUsers> _userManager;
        private readonly ConsumerProfilesContext _context;
        private readonly IReportingService _reportingService;
        private readonly ConsumerProfileSettings _consumerProfileSettings;
        ILogger<ConsumerProfileService> _consumerProfileServiceLogger;

        public ConsumerProfileService(
            IMailService emailService,
            ILogger<ConsumerProfileService> consumerProfileServiceLogger,
            SignInManager<ConsumerProfileUsers> signInManager,
            UserManager<ConsumerProfileUsers> userManager,
            ConsumerProfilesContext context,
            IConfiguration configuration,
            IReportingService reportingService)
        {
            _mailService = emailService;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _consumerProfileServiceLogger = consumerProfileServiceLogger;
            _smtpSettings = configuration.GetSettings<SMTPSettings>();
            _consumerProfileSettings = configuration.GetSettings<ConsumerProfileSettings>();
            _reportingService = reportingService;
        }

        public async Task<UserInfo> FindByUsername(string scheme, string username)
        {
            if (scheme == SchemaConstants.EAuth ||
                scheme == SchemaConstants.EAuthV2)
            {
                var user =
                    _context.
                    ConsumerProfileUsers.
                    Where(
                        u => u.Identifier == username
                        && u.IdentifierType == 1 // 1 - ЕГН, 2 - ЛНЧ
                    )
                    .Select(
                        u =>
                        new UserInfo()
                        {
                            Username = u.UserName,
                            Name = u.Name,
                            Active = u.IsActive,
                            SubjectId = u.Id.ToString()
                        }
                    ).SingleOrDefault();
                return user;
            }
            else
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
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var sub = Convert.ToDecimal(context.Subject.GetSubjectId());
                //var user = await _userManager.FindByIdAsync(sub);      
                var user = _context.ConsumerProfileUsers.Find(sub);
                var claims = new List<Claim>();
                claims.Add(new Claim(JwtClaimTypes.GivenName, user.Name));
                claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
                claims.Add(new Claim("ConsumerProfileId", user.ConsumerProfileId.ToString()));
                claims.Add(new Claim("UserName", user.UserName));

                context.IssuedClaims = claims;
            }
            catch (Exception ex)
            {
                _consumerProfileServiceLogger.LogError(ex, "Error in GetProfileDataAsync");
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = Convert.ToDecimal(context.Subject.GetSubjectId());
            var user = _context.ConsumerProfileUsers.FirstOrDefault(u => u.Id == sub); // await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null && user.IsActive;
        }

        public async Task<UserRegistrationResult> RegisterUser(string scheme, string name, string userName, string email, string password, Dictionary<string, string> additionalAttributes)
        {
            if (additionalAttributes.ContainsKey("profileIdentifier"))
            {
                var user =
                    new ConsumerProfileUsers
                    {
                        UserName = userName,
                        Name = name,
                        Email = email,
                        Identifier = additionalAttributes["consumerUserIdentifier"],
                        IdentifierType = Convert.ToInt32(additionalAttributes["consumerUserIdentifierType"]),
                        PhoneNumber = additionalAttributes["consumerUserPhoneNumber"],
                        Position = additionalAttributes["userPosition"],

                    };

                var consumerProfile = _context.ConsumerProfiles.FirstOrDefault(p => p.Identifier == additionalAttributes["profileIdentifier"]);

                //Only GLOBAL_ADMINS have the right to approve consumers and their representatives

                if (consumerProfile != null)
                {
                    user.ConsumerProfileId = consumerProfile.ConsumerProfileId;
                    var result = await _userManager.CreateAsync(user, password);

                    await SendNewConsumerProfileUserMessage(email, consumerProfile);
                    await SendConsumerUserMessageWithPDFReport(email, consumerProfile);
                    return
                        new UserRegistrationResult()
                        {
                            Succeeded = true
                        };
                }
                else if (additionalAttributes.ContainsKey("profileName"))
                {
                    consumerProfile = new ConsumerProfiles()
                    {
                        AcceptedEula = Convert.ToBoolean(additionalAttributes["profileAcceptedEULA"]),
                        Identifier = additionalAttributes["profileIdentifier"],
                        IdentifierType = Convert.ToInt32(additionalAttributes["profileIdentifierType"]),
                        Name = additionalAttributes["profileName"],
                        Address = additionalAttributes["profileAddress"],
                        Status = 0,
                    };
                    var profileStatus = new ConsumerProfileStatus
                    {
                        OldStatus = 0,
                        NewStatus = 0,
                        ConsumerProfile = consumerProfile,
                        Date = DateTime.Now,
                        Comment = Resources.ConsumerProfileStatusNew
                    };
                    user.ConsumerProfile = consumerProfile;
                    _context.ConsumerProfileStatus.Add(profileStatus);
                    _context.ConsumerProfiles.Add(consumerProfile);
                    _context.ConsumerProfileUsers.Add(user);

                    var result = await _userManager.CreateAsync(user, password);

                    if (!result.Succeeded)
                    {
                        return new UserRegistrationResult()
                        {
                            Succeeded = false,
                            Errors =
                                result
                                .Errors
                                .Select(
                                    e =>
                                        new UserRegistrationError()
                                        {
                                            Code = e.Code,
                                            Description = e.Description
                                        }
                                ).ToList()
                        };
                    }
                    else
                    {
                        await SendNewConsumerProfileMessage(email, additionalAttributes["profileName"]);
                        await SendConsumerProfileMessageWithPDFReport(email, consumerProfile);

                        return new UserRegistrationResult()
                        {
                            Succeeded = true,
                        };
                    }
                }
                else
                {
                    return new UserRegistrationResult()
                    {
                        Succeeded = false,
                        Errors = new UserRegistrationError[]
                        {
                            new UserRegistrationError()
                            {
                                Code = "ArgumentException",
                                Description = "Not known identifier"
                            }
                        }
                    };
                }
            }
            else
            {
                return new UserRegistrationResult()
                {
                    Succeeded = false,
                    Errors = new UserRegistrationError[]
                    {
                        new UserRegistrationError() {
                            Code = "ArgumentException",
                            Description = "Identifier key argument in additionalAttributes should be specified"
                        }
                    }
                };
            }
        }

        private async Task SendConsumerUserMessageWithPDFReport(string email, ConsumerProfiles consumerProfile) { 
            var message = new MailMessage(_smtpSettings.From, email);
            message.Subject = string.Format(Resources.ConsumerProfileMessageWithPDFReportSubject, consumerProfile.Name);
            PrepareBody(message, Resources.ConsumerProfileMessageWithPDFReportBody, consumerProfile.Name, email);

            var report = await _reportingService.RunConsumerProfileUserRegistration(email);
            Stream stream = new MemoryStream(report);
            Attachment file = new Attachment(stream, "FormRequest.pdf", "application/pdf");
            message.Attachments.Add(file);

            await _mailService.SendMailAsync(message);        
        }

        private async Task SendConsumerProfileMessageWithPDFReport(string email, ConsumerProfiles consumerProfile)
        {
            var message = new MailMessage(_smtpSettings.From, email);
            message.Subject = string.Format(Resources.ConsumerProfileMessageWithPDFReportSubject, consumerProfile.Name);
            PrepareBody(message, Resources.ConsumerProfileMessageWithPDFReportBody, consumerProfile.Name, email);

            var report = await _reportingService.RunConsumerProfileUserRegistration(email);
            Stream stream = new MemoryStream(report);
            Attachment file = new Attachment(stream, "FormRequest.pdf", "application/pdf");
            message.Attachments.Add(file);

            await _mailService.SendMailAsync(message);
        }

        private async Task SendNewConsumerProfileUserMessage(string email, ConsumerProfiles consumerProfile)
        {
            var message = new MailMessage(_smtpSettings.From, _consumerProfileSettings.AdministrationMail);
            message.Subject = string.Format(Resources.ConsumerProfileUserSubejct, consumerProfile.Name);
            PrepareBody(message, Resources.ConsumerProfileUserBody, email, consumerProfile.Name);
            await _mailService.SendMailAsync(message);
        }

        private async Task SendNewConsumerProfileMessage(string email, string consumerProfileName)
        {
            var newConsumerProfileUserMessage = new MailMessage(_smtpSettings.From, _consumerProfileSettings.AdministrationMail);
            newConsumerProfileUserMessage.Subject = string.Format(Resources.ConsumerProfileUserSubejct, consumerProfileName);
            PrepareBody(newConsumerProfileUserMessage, Resources.ConsumerProfileUserBody, email, consumerProfileName);
            await _mailService.SendMailAsync(newConsumerProfileUserMessage);
        }

        internal static void PrepareBody(MailMessage newConsumerProfileUserMessage, string body, params string[] args)
        {
            Attachment att = new Attachment("logo.png");
            att.ContentDisposition.Inline = true;
            newConsumerProfileUserMessage.IsBodyHtml = true;
            newConsumerProfileUserMessage.Attachments.Add(att);
            List<object> arguments = new List<object>();
            arguments.Add(att.ContentId);
            arguments.AddRange(args);
            newConsumerProfileUserMessage.Body = string.Format(body, arguments.ToArray());
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> ValidateCredentials(string scheme, string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (_userManager.SupportsUserLockout && await _userManager.IsLockedOutAsync(user))
            {
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
                    new ResetPasswordError() {
                        Code = "UserNotFound",
                        Description = Resources.UserNotFound
                    }
                );
                result.Errors = errors;
                return result;
            }
        }
    }

    public class LocalConsumerProfileService : ConsumerProfileService
    {
        public override string ClientId => "regixlocalconsumerprofileangular";
        public LocalConsumerProfileService(IMailService emailService,
            ILogger<ConsumerProfileService> consumerProfileServiceLogger,
            SignInManager<ConsumerProfileUsers> signInManager,
            UserManager<ConsumerProfileUsers> userManager,
            ConsumerProfilesContext context,
            IConfiguration configuration,
            IReportingService reportingService) : 
            base(
                emailService, 
                consumerProfileServiceLogger, 
                signInManager, 
                userManager, 
                context, 
                configuration,
                reportingService
            ) {}
    }
}
