using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceAdapterOperation
{
    public class ApiServiceAdapterOperationOutDto
    {
        public decimal Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public DisplayValue AdapterOperation { get; set; }
        public DisplayValue ApiServiceOperation { get; set; }
    }
}