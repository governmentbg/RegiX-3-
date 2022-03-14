using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.DataContracts.DTO.ConsumerProfile
{
    public class ConsumerProfileInDto
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }        
        public bool AcceptedEula { get; set; }        
    }
}
