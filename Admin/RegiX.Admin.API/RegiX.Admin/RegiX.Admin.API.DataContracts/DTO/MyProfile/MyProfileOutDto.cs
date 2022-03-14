using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.MyProfile
{
    public class MyProfileOutDto
    {
        public decimal Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public UsersEauthDto UsersEauth { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
