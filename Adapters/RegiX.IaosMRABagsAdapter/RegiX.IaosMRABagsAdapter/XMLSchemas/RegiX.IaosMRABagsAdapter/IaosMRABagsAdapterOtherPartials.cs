using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.IaosMRABagsAdapter
{
    public partial class MRO_BAGS_Reg_Number_Date_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.DateFrom != default(DateTime) ||
                this.Authorization.DateFromSpecified != default(Boolean) ||
                this.Authorization.DateTo != default(DateTime) ||
                this.Authorization.DateToSpecified != default(Boolean) ||
                this.Authorization.StateSpecified != default(Boolean) ||
                this.Authorization.ShouldSerializeAuthNum() ||
                this.Authorization.ShouldSerializeCompanyName()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }

    public partial class AuthorizationRegNumberDate
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
    }

    public partial class MRO_BAGS_Reg_Number_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.ShouldSerializeAddress() ||
                this.Authorization.ShouldSerializeCompanyName() ||
                this.Authorization.ShouldSerializeDistName() ||
                this.Authorization.ShouldSerializeEIK() ||
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

    public partial class AuthorizationRegNumber
    {
        public bool ShouldSerializeAddress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Address);

            if (!haveSomeValue)
            {
                this.Address = null;
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

        public bool ShouldSerializeEIK()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EIK);

            if (!haveSomeValue)
            {
                this.EIK = null;
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

    public partial class MRO_BAGS_Validity_Check_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.ShouldSerializeAddress() ||
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
        public bool ShouldSerializeAddress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Address);

            if (!haveSomeValue)
            {
                this.Address = null;
            }

            return haveSomeValue;
        }

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
}