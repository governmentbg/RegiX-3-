using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleOperationAccess
{
    public class ConsumerRoleOperationAccessOutDto
    {
        public decimal Id { get; set; }
        public bool HasAccess { get; set; }
        public DisplayValue ConsumerRole { get; set; }
        public int AdapterOperationId { get; set; }
        public string AdministrationDisplayName { get; set; }
        public string RegisterDisplayName { get; set; }
        public string AdapterDisplayName { get; set; }
        public string AdapterOperationDisplayName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}