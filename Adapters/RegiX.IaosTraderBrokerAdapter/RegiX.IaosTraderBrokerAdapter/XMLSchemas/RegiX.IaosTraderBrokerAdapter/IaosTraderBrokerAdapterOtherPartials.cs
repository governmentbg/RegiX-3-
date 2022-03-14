using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.IaosTraderBrokerAdapter
{
    public partial class TRADER_BROKER_Validity_Check_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.AuthTypeSpecified != default(Boolean) ||
                this.Authorization.StateSpecified != default(Boolean) ||
                this.Authorization.ShouldSerializeAuthNum() ||
                this.Authorization.ShouldSerializeCompanyName() ||
                this.Authorization.ShouldSerializeDistName() ||
                this.Authorization.ShouldSerializeFirstName() ||
                this.Authorization.ShouldSerializeLastName() ||
                this.Authorization.ShouldSerializeMidName() ||
                this.Authorization.ShouldSerializePopName() ||
                this.Authorization.ShouldSerializeTerName()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationValidityCheck
    {
        public bool ShouldSerializeAuthNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AuthNum);

            if (!haveSomeValue)
            {
                this.AuthNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCompanyName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CompanyName);

            if (!haveSomeValue)
            {
                this.CompanyName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDistName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.DistName);

            if (!haveSomeValue)
            {
                this.DistName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFirstName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FirstName);

            if (!haveSomeValue)
            {
                this.FirstName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLastName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LastName);

            if (!haveSomeValue)
            {
                this.LastName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMidName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.MidName);

            if (!haveSomeValue)
            {
                this.MidName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePopName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PopName);

            if (!haveSomeValue)
            {
                this.PopName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTerName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.TerName);

            if (!haveSomeValue)
            {
                this.TerName = null;
            }

            return haveSomeValue;
        }
    }
    public partial class TRADER_BROKER_Waste_Codes_By_EIK_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.AuthTypeSpecified != default(Boolean) ||
                this.Authorization.StateSpecified != default(Boolean) ||
                this.Authorization.ShouldSerializeAuthNum() ||
                this.Authorization.ShouldSerializeCompanyName() ||
                this.Authorization.ShouldSerializeWasteCodes()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationWasteCode
    {
        public bool ShouldSerializeAuthNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AuthNum);

            if (!haveSomeValue)
            {
                this.AuthNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCompanyName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CompanyName);

            if (!haveSomeValue)
            {
                this.CompanyName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeWasteCodes()
        {
            bool haveSomeValue = this.WasteCodes != null &&
                (
                this.WasteCodes.ShouldSerializeWasteCode()
                );

            if (!haveSomeValue)
            {
                this.WasteCodes = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationWasteCodeWasteCodes
    {
        public bool ShouldSerializeWasteCode()
        {
            //Here removing the empty elements from the array or collection
            if (this.WasteCode != null)
            {
                this.WasteCode = this.WasteCode.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.WasteCode != null &&
                this.WasteCode.Count() != 0;

            if (!haveSomeValue)
            {
                this.WasteCode = null;
            }

            return haveSomeValue;
        }
    }
}
