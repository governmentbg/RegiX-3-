using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumer
{
    public class ElementConsumerInDto
    {
        public string ConsumerDescription { get; set; }
        public decimal? consumerAdministrationId { get; set; }
        public decimal? consumerId { get; set; }
        public decimal? certificateId { get; set; }
        public decimal? administrationId { get; set; }
        public decimal? registerId { get; set; }
        public decimal? adapterId { get; set; }
        public decimal? operationId { get; set; }
    }
}
