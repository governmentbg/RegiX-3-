using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.MyProfile
{
    public class MyProfileInDto
    {
        [Required]
        public decimal Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public UsersEauthDto UsersEauth { get; set; }
    }
}
