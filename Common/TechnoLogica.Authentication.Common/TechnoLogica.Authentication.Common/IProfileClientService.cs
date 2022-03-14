using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.Authentication.Common
{
    public interface IProfileClientService : IProfileService
    {
        string ClientId { get; }
        Task<bool> ValidateCredentials(string scheme, string username, string password);
        Task<bool> ChangePassword(string scheme, string username, string password, string newPassword);
        Task<bool> SendPasswordResetTokenAsync(string scheme, string baseAddress, string email);
        Task<ResetPasswordResult> ResetPasswordAsync(string scheme, string email, string token, string newPassword);
        Task<UserInfo> FindByUsername(string scheme, string username);
        Task<UserRegistrationResult> RegisterUser(string scheme, string name, string userName, string email, string password, Dictionary<string, string> additionalAttributes);
        Task SignOutAsync();
    }
}
