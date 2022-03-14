using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.KzldAdministratorsAdapter
{
    public partial class PersonalDataControllerRegister
    {
        public bool ShouldSerializeIndividualsCount()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.IndividualsCount);

            if (!haveSomeValue)
            {
                this.IndividualsCount = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegisterName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegisterName);

            if (!haveSomeValue)
            {
                this.RegisterName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeIndividualsCountText()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.IndividualsCountText);

            if (!haveSomeValue)
            {
                this.IndividualsCountText = null;
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
    public partial class RegisteredAdministratorByIDResponse
    {
        public bool ShouldSerializePDCData()
        {
            bool haveSomeValue = this.PDCData != null &&
                (
                this.PDCData.ShouldSerializeIdentifier() ||
                this.PDCData.ShouldSerializeName() ||
                this.PDCData.ShouldSerializeLegalForm() ||
                this.PDCData.ShouldSerializeLocation() ||
                this.PDCData.ShouldSerializeAddress() ||
                this.PDCData.ShouldSerializeLocationCode()
                );

            if (!haveSomeValue)
            {
                this.PDCData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePDSRegisters()
        {
            //Here removing the empty elements from the array or collection
            if (this.PDSRegisters != null)
            {
                this.PDSRegisters = this.PDSRegisters.Where(x => x != default(PersonalDataControllerRegister)).ToList();
            }

            bool haveSomeValue = this.PDSRegisters != null &&
                this.PDSRegisters.Count() != 0 &&
                (
                this.PDSRegisters[0].UpdateDate != default(DateTime) ||
                this.PDSRegisters[0].UpdateDateSpecified != default(Boolean) ||
                this.PDSRegisters[0].ShouldSerializeIndividualsCount() ||
                this.PDSRegisters[0].ShouldSerializeRegisterName() ||
                this.PDSRegisters[0].ShouldSerializeIndividualsCountText()
                );

            if (!haveSomeValue)
            {
                this.PDSRegisters = null;
            }

            return haveSomeValue;
        }
    }
    public partial class RegisteredAdministratorByNumberResponse
    {
        public bool ShouldSerializePDCRegisterNumer()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PDCRegisterNumer);

            if (!haveSomeValue)
            {
                this.PDCRegisterNumer = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePDCData()
        {
            bool haveSomeValue = this.PDCData != null &&
                (
                this.PDCData.ShouldSerializeIdentifier() ||
                this.PDCData.ShouldSerializeName() ||
                this.PDCData.ShouldSerializeLegalForm() ||
                this.PDCData.ShouldSerializeLocation() ||
                this.PDCData.ShouldSerializeAddress() ||
                this.PDCData.ShouldSerializeLocationCode()
                );

            if (!haveSomeValue)
            {
                this.PDCData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePDSRegisters()
        {
            //Here removing the empty elements from the array or collection
            if (this.PDSRegisters != null)
            {
                this.PDSRegisters = this.PDSRegisters.Where(x => x != default(PersonalDataControllerRegister)).ToList();
            }

            bool haveSomeValue = this.PDSRegisters != null &&
                this.PDSRegisters.Count() != 0 &&
                (
                this.PDSRegisters[0].UpdateDate != default(DateTime) ||
                this.PDSRegisters[0].UpdateDateSpecified != default(Boolean) ||
                this.PDSRegisters[0].ShouldSerializeIndividualsCount() ||
                this.PDSRegisters[0].ShouldSerializeRegisterName() ||
                this.PDSRegisters[0].ShouldSerializeIndividualsCountText()
                );

            if (!haveSomeValue)
            {
                this.PDSRegisters = null;
            }

            return haveSomeValue;
        }
    }
}
