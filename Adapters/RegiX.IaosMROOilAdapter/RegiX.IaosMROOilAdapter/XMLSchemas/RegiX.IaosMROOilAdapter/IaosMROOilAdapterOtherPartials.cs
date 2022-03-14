using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.IaosMROOilAdapter
{
    public partial class MRO_OIL_Execution_Type_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.MroFulfillmentSpecified != default(Boolean) ||
                this.Authorization.ShouldSerializeAuthNum() ||
                this.Authorization.ShouldSerializeCompanyName() ||
                this.Authorization.ShouldSerializeRecOrgNum() ||
                this.Authorization.ShouldSerializeUonName()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }

    public partial class AuthorizationExecutionType
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

        public bool ShouldSerializeRecOrgNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RecOrgNum);

            if (!haveSomeValue)
            {
                this.RecOrgNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeUonName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.UonName);

            if (!haveSomeValue)
            {
                this.UonName = null;
            }

            return haveSomeValue;
        }
    }

    public partial class MRO_OIL_Trade_Marks_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.ShouldSerializeCompanyName() ||
                this.Authorization.ShouldSerializeEIK() ||
                this.Authorization.ShouldSerializeTradeMarks()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }

    public partial class AuthorizationTradeMarks
    {
        public bool ShouldSerializeCompanyName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CompanyName);

            if (!haveSomeValue)
            {
                this.CompanyName = null;
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

        public bool ShouldSerializeTradeMarks()
        {
            bool haveSomeValue = this.TradeMarks != null &&
                (
                this.TradeMarks.ShouldSerializeTradeMark()
                );

            if (!haveSomeValue)
            {
                this.TradeMarks = null;
            }

            return haveSomeValue;
        }
    }

    public partial class AuthorizationTradeMarksTradeMarks
    {
        public bool ShouldSerializeTradeMark()
        {
            //Here removing the empty elements from the array or collection
            if (this.TradeMark != null)
            {
                this.TradeMark = this.TradeMark.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.TradeMark != null &&
                this.TradeMark.Count() != 0;

            if (!haveSomeValue)
            {
                this.TradeMark = null;
            }

            return haveSomeValue;
        }
    }

    public partial class MRO_OIL_Validity_Check_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.ShouldSerializeAddress() ||
                this.Authorization.ShouldSerializeAuthNum() ||
                this.Authorization.ShouldSerializeCompanyName() ||
                this.Authorization.ShouldSerializeDistName() ||
                this.Authorization.ShouldSerializeFisrtName() ||
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

        public bool ShouldSerializeFisrtName()
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