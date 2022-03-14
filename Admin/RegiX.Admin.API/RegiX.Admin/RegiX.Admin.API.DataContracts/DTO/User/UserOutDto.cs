using System;
using TechnoLogica.API.DataContracts;

public class UserOutDto
{
    public decimal Id { get; set; }

    public string UserName { get; set; }

    public string Name { get; set; }

    public bool? Active { get; set; }

    public bool? IsAnonymous { get; set; }

    public DateTime? LastActivityDate { get; set; }

    public string Email { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsLockedOut { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }

    public DateTime? LastLockoutDate { get; set; }

    public int? FailedPswdAtmpCount { get; set; }

    public DateTime? FailedPswdAtmpWdwStart { get; set; }

    public string UserComment { get; set; }

    public DisplayValue Administration { get; set; }

    public bool? IsAdmin { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string UpdatedBy { get; set; }
}