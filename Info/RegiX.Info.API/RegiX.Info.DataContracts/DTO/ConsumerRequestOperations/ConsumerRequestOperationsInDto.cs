using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.DataContracts;

namespace RegiX.Info.DataContracts.DTO.ConsumerRequestOperations
{
    public class ConsumerRequestOperationsInDto
    {
        public decimal Id { get; set; }
        public decimal[] ApprovedRequestElementIds { get; set; }
        public int ConsumerAccessRequestStatus { get; set; }
        public string Comment { get; set; }
        public virtual DisplayValueStatus ConsumerAccessRequest { get; set; }
        public virtual DisplayValueAdapterOperation AdapterOperation { get; set; }
    }

    public class DisplayValueStatus
    {
        public decimal Id { get; set; }
        public int Status { get; set; }
    }

    public class DisplayValueAdapterOperation : DisplayValue
    {
        public decimal? RegisterObjectId { get; set; }
        public string Description { get; set; }
    }
}
