using System;

namespace RegiX.IdentityServer.ConsumerProfileCredentials.Context
{
    public class Users
    {
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public decimal? FailedPswdAtmpCount { get; set; }
        public DateTime? FailedPswdAtmpWdwStart { get; set; }
        public decimal? FailedPswdAnsAtmpCount { get; set; }
        public DateTime? FailedPswdAnsAtmpWdwStart { get; set; }
        public string UserComment { get; set; }
        public decimal? AdministrationId { get; set; }
        public bool IsAdmin { get; set; }
        public string PswdVerificationToken { get; set; }
        public DateTime? PswdVerTokenExpirationDate { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        //public virtual Administrations Administration { get; set; }
    }
}