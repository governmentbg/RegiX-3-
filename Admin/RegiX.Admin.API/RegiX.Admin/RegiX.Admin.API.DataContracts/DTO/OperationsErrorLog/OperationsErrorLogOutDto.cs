using System;
using TechnoLogica.API.DataContracts;
namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationsErrorLog
{
    public class OperationsErrorLogOutDto
    {
        public decimal Id { get; set; }
        public DateTime LogTime { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorContent { get; set; }

        public DisplayValue AdapterOperation { get; set; }
        public DisplayValue ApiServiceConsumer { get; set; }
        public DisplayValue ConsumerCertificate { get; set; }
        public DisplayValue Administration { get; set; }
        public DisplayValue ApiServiceCall { get; set; }
        public DisplayValue ApiServiceOperations { get; set; }
    }
}