using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectsLog
{
    public class RegisterObjectsLogOutDto
    {
        public decimal Id { get; set; }
        public string RegisterObjectsName { get; set; }
        public string Description { get; set; }
        public string RegisterObjectsFullName { get; set; }
        public decimal RegisterObjectElementId { get; set; }
        public decimal RegisterObjectId { get; set; }
        public string PathToRoot { get; set; }
        public string UserCreated { get; set; }
        public string UserModifyed { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModifyed { get; set; }
        public decimal RegisterAdapterId { get; set; }
    }
}