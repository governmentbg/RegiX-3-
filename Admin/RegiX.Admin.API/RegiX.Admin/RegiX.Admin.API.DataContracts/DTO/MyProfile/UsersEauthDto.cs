using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.MyProfile
{
    public class UsersEauthDto
    {
        public decimal? Id { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }
    }
}
