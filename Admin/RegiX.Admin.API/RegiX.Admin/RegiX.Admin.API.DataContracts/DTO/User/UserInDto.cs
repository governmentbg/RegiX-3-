using System;
using System.ComponentModel.DataAnnotations;

public class UserInDto
{
    [Required] public string UserName { get; set; }

    [Required] public string Email { get; set; }

    [Required] public string Name { get; set; }

    public decimal? AdministrationId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsAdmin { get; set; }

    public DateTime? CreatedOn { get; set; } = DateTime.Now;
}