using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.DataContracts.DTO.ConsumerRequestOperations
{
    public class ConsumerRequestOperationsOutDto
    {
        public decimal Id { get; set; }
        public virtual DisplayValueStatus ConsumerAccessRequest { get; set; }
        public virtual DisplayValueAdapterOperation AdapterOperation { get; set; }
    }
}
