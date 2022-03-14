using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.IaosRegister67ZOUAdapter
{
    public partial class StageInfo
    {
        public bool ShouldSerializeStageAddress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.StageAddress);

            if (!haveSomeValue)
            {
                this.StageAddress = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeStageNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.StageNum);

            if (!haveSomeValue)
            {
                this.StageNum = null;
            }

            return haveSomeValue;
        }

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
    public partial class REG35_Info_By_EIK_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            //Here removing the empty elements from the array or collection
            if (this.Authorization != null)
            {
                this.Authorization = this.Authorization.Where(x => x != default(AuthorizationRegInfo)).ToList();
            }

            bool haveSomeValue = this.Authorization != null &&
                this.Authorization.Count() != 0 &&
                (
                this.Authorization[0].AuthTypeSpecified != default(Boolean) ||
                this.Authorization[0].StateSpecified != default(Boolean) ||
                this.Authorization[0].ShouldSerializeAuthNum() ||
                this.Authorization[0].ShouldSerializeRiosv()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationRegInfo
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

        public bool ShouldSerializeRiosv()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Riosv);

            if (!haveSomeValue)
            {
                this.Riosv = null;
            }

            return haveSomeValue;
        }
    }
    public partial class REG35_License_Validity_Check_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.AuthTypeSpecified != default(Boolean) ||
                this.Authorization.DateFrom != default(DateTime) ||
                this.Authorization.DateFromSpecified != default(Boolean) ||
                this.Authorization.DateTo != default(DateTime) ||
                this.Authorization.DateToSpecified != default(Boolean) ||
                this.Authorization.StateSpecified != default(Boolean) ||
                this.Authorization.ShouldSerializeRIOSV()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationValidityCheckByDate
    {
        public bool ShouldSerializeRIOSV()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RIOSV);

            if (!haveSomeValue)
            {
                this.RIOSV = null;
            }

            return haveSomeValue;
        }
    }
    public partial class REG35_Stage_Info_By_Pop_Name_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.ShouldSerializeContactPerson() ||
                this.Authorization.ShouldSerializePhone() ||
                this.Authorization.ShouldSerializeStage()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationInfoPopName
    {
        public bool ShouldSerializeContactPerson()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContactPerson);

            if (!haveSomeValue)
            {
                this.ContactPerson = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePhone()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Phone);

            if (!haveSomeValue)
            {
                this.Phone = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeStage()
        {
            //Here removing the empty elements from the array or collection
            if (this.Stage != null)
            {
                this.Stage = this.Stage.Where(x => x != default(StageInfo)).ToList();
            }

            bool haveSomeValue = this.Stage != null &&
                this.Stage.Count() != 0 &&
                (
                this.Stage[0].ShouldSerializeStageAddress() ||
                this.Stage[0].ShouldSerializeStageNum() ||
                this.Stage[0].ShouldSerializeWasteCode()
                );

            if (!haveSomeValue)
            {
                this.Stage = null;
            }

            return haveSomeValue;
        }
    }
    public partial class REG35_Stage_Info_By_Waste_Code_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            //Here removing the empty elements from the array or collection
            if (this.Authorization != null)
            {
                this.Authorization = this.Authorization.Where(x => x != default(AuthorizationByWasteCode)).ToList();
            }

            bool haveSomeValue = this.Authorization != null &&
                this.Authorization.Count() != 0 &&
                (
                //this.Authorization[0].AuthTypeSpecified != default(Boolean) ||
                this.Authorization[0].ShouldSerializeAuthNum() ||
                this.Authorization[0].ShouldSerializeContactPerson() ||
                this.Authorization[0].ShouldSerializePhone() ||
                this.Authorization[0].ShouldSerializeStage()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationByWasteCode
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

        public bool ShouldSerializeContactPerson()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContactPerson);

            if (!haveSomeValue)
            {
                this.ContactPerson = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePhone()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Phone);

            if (!haveSomeValue)
            {
                this.Phone = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeStage()
        {
            //Here removing the empty elements from the array or collection
            if (this.Stage != null)
            {
                this.Stage = this.Stage.Where(x => x != default(StageInfo)).ToList();
            }

            bool haveSomeValue = this.Stage != null &&
                this.Stage.Count() != 0 &&
                (
                this.Stage[0].ShouldSerializeStageAddress() ||
                this.Stage[0].ShouldSerializeStageNum() ||
                this.Stage[0].ShouldSerializeWasteCode()
                );

            if (!haveSomeValue)
            {
                this.Stage = null;
            }

            return haveSomeValue;
        }
    }
    public partial class REG35_Stages_By_Reg_Number_And_Waste_Code_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.ShouldSerializeContactPerson() ||
                this.Authorization.ShouldSerializePhone() ||
                this.Authorization.ShouldSerializeStage()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationRegNumberWasteCode
    {
        public bool ShouldSerializeContactPerson()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContactPerson);

            if (!haveSomeValue)
            {
                this.ContactPerson = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePhone()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Phone);

            if (!haveSomeValue)
            {
                this.Phone = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeStage()
        {
            //Here removing the empty elements from the array or collection
            if (this.Stage != null)
            {
                this.Stage = this.Stage.Where(x => x != default(Stage)).ToList();
            }

            bool haveSomeValue = this.Stage != null &&
                this.Stage.Count() != 0 &&
                (
                this.Stage[0].ShouldSerializeStageAddress() ||
                this.Stage[0].ShouldSerializeStageNum() ||
                this.Stage[0].ShouldSerializeWasteCode()
                );

            if (!haveSomeValue)
            {
                this.Stage = null;
            }

            return haveSomeValue;
        }
    }
    public partial class Stage
    {
        public bool ShouldSerializeStageAddress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.StageAddress);

            if (!haveSomeValue)
            {
                this.StageAddress = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeStageNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.StageNum);

            if (!haveSomeValue)
            {
                this.StageNum = null;
            }

            return haveSomeValue;
        }

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
    public partial class REG35_Validity_Check_By_Reg_Number_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                //this.Authorization.AuthTypeSpecified != default(Boolean) ||
                this.Authorization.DateIssued != default(DateTime) ||
                //this.Authorization.DateIssuedSpecified != default(Boolean) ||
                //this.Authorization.StateSpecified != default(Boolean) ||
                this.Authorization.ShouldSerializeCompanyName() ||
                this.Authorization.ShouldSerializeEIK()
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
    }
}
