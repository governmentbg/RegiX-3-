using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter
{
    public partial class DeniedEntryAdministratorResponse
    {
        public bool ShouldSerializePDCDeniedEntryData()
        {
            bool haveSomeValue = this.PDCDeniedEntryData != null &&
                (
                this.PDCDeniedEntryData.ShouldSerializeIdentifier() ||
                this.PDCDeniedEntryData.ShouldSerializeName() ||
                this.PDCDeniedEntryData.ShouldSerializeLegalForm() ||
                this.PDCDeniedEntryData.ShouldSerializeLocation() ||
                this.PDCDeniedEntryData.ShouldSerializeAddress() ||
                this.PDCDeniedEntryData.ShouldSerializeLocationCode()
                );

            if (!haveSomeValue)
            {
                this.PDCDeniedEntryData = null;
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
