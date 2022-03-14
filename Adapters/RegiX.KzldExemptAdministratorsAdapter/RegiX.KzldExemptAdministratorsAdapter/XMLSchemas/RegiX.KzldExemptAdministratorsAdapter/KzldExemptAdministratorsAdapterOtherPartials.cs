using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.KzldExemptAdministratorsAdapter
{
    public partial class ExemptRegistrationAdministratorResponse
    {
        public bool ShouldSerializePDCExemptRegistrationData()
        {
            bool haveSomeValue = this.PDCExemptRegistrationData != null &&
                (
                this.PDCExemptRegistrationData.ShouldSerializeIdentifier() ||
                this.PDCExemptRegistrationData.ShouldSerializeName() ||
                this.PDCExemptRegistrationData.ShouldSerializeLegalForm() ||
                this.PDCExemptRegistrationData.ShouldSerializeLocation() ||
                this.PDCExemptRegistrationData.ShouldSerializeAddress() ||
                this.PDCExemptRegistrationData.ShouldSerializeLocationCode()
                );

            if (!haveSomeValue)
            {
                this.PDCExemptRegistrationData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLegalBasis()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LegalBasis);

            if (!haveSomeValue)
            {
                this.LegalBasis = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeProtocol()
        {
            bool haveSomeValue = this.Protocol != null &&
                (
                this.Protocol.ProtocolDate != default(DateTime) ||
                this.Protocol.ProtocolDateSpecified != default(Boolean) ||
                this.Protocol.ShouldSerializeProtocolNumber()
                );

            if (!haveSomeValue)
            {
                this.Protocol = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ProtocolType
    {
        public bool ShouldSerializeProtocolNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ProtocolNumber);

            if (!haveSomeValue)
            {
                this.ProtocolNumber = null;
            }

            return haveSomeValue;
        }
    }
    public partial class PersonalDataControllerData
    {
        public bool ShouldSerializeIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Identifier);

            if (!haveSomeValue)
            {
                this.Identifier = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Name);

            if (!haveSomeValue)
            {
                this.Name = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLegalForm()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LegalForm);

            if (!haveSomeValue)
            {
                this.LegalForm = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLocation()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Location);

            if (!haveSomeValue)
            {
                this.Location = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAddress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Address);

            if (!haveSomeValue)
            {
                this.Address = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLocationCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LocationCode);

            if (!haveSomeValue)
            {
                this.LocationCode = null;
            }

            return haveSomeValue;
        }
    }
}
