using System;
using System.Collections.Generic;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.User
{
    public class UserOutDto : ABaseOutDto
    {
        public string UserName { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LockoutEndDate { get; set; }

        public int AccessFailedCount { get; set; }
        
        public string Position { get; set; }

        public int UserType { get; set; }

        public DisplayValue Authority { get; set; }

        public int AuthorityId { get; set; }

        public IEnumerable<string> UserRoles { get; set; }
    }
}