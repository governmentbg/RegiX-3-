using System;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.BaseDtos;

namespace TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations
{
    public class AsyncReportExecutionsOutDto : BaseOutDto
    {
        public decimal ApiServiceCallId { get; set; }
        public string VerificationCode { get; set; }
        public int AdapterOperationId { get; set; }
        public string AdapterOperationDisplayName { get; set; }
        public int UserId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime? ReceivedOn { get; set; }
        public string Result { get; set; }
    }
}