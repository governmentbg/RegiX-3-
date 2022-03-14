using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.IaosREG35Adapter
{
    public partial class StageWaste
    {
        public bool ShouldSerializeWasteCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.WasteCode);

            if (!haveSomeValue)
            {
                this.WasteCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeWasteType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.WasteType);

            if (!haveSomeValue)
            {
                this.WasteType = null;
            }

            return haveSomeValue;
        }
    }
    public partial class REG35_Allowed_Waste_Codes_Response
    {
        public bool ShouldSerializeStage()
        {
            bool haveSomeValue = this.Stage != null &&
                (
                this.Stage.StateSpecified != default(Boolean) ||
                this.Stage.ShouldSerializeStageAddress() ||
                this.Stage.ShouldSerializeWasteCode()
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
    public partial class REG35_Licenses_By_EIK_Waste_Code_Waste_Operation_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            //Here removing the empty elements from the array or collection
            if (this.Authorization != null)
            {
                this.Authorization = this.Authorization.Where(x => x != default(AuthorizationWasteCodeWasteOperation)).ToList();
            }

            bool haveSomeValue = this.Authorization != null &&
                this.Authorization.Count() != 0 &&
                (
                this.Authorization[0].AuthTypeSpecified != default(Boolean) ||
                this.Authorization[0].StateSpecified != default(Boolean) ||
                this.Authorization[0].ShouldSerializeAuthNum() ||
                this.Authorization[0].ShouldSerializeStage()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationWasteCodeWasteOperation
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

        public bool ShouldSerializeStage()
        {
            //Here removing the empty elements from the array or collection
            if (this.Stage != null)
            {
                this.Stage = this.Stage.Where(x => x != default(StageWasteNum)).ToList();
            }

            bool haveSomeValue = this.Stage != null &&
                this.Stage.Count() != 0 &&
                (
                this.Stage[0].ShouldSerializeStageAddress() ||
                this.Stage[0].ShouldSerializeStageNum() ||
                this.Stage[0].ShouldSerializeWaste()
                );

            if (!haveSomeValue)
            {
                this.Stage = null;
            }

            return haveSomeValue;
        }
    }
    public partial class StageWasteNum
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

        public bool ShouldSerializeWaste()
        {
            //Here removing the empty elements from the array or collection
            if (this.Waste != null)
            {
                this.Waste = this.Waste.Where(x => x != default(StageWaste)).ToList();
            }

            bool haveSomeValue = this.Waste != null &&
                this.Waste.Count() != 0 &&
                (
                this.Waste[0].ShouldSerializeWasteCode() ||
                this.Waste[0].ShouldSerializeWasteType()
                );

            if (!haveSomeValue)
            {
                this.Waste = null;
            }

            return haveSomeValue;
        }
    }
    public partial class REG35_Stages_By_Auth_Num_Response
    {
        public bool ShouldSerializeAuthorization()
        {
            bool haveSomeValue = this.Authorization != null &&
                (
                this.Authorization.AuthTypeSpecified != default(Boolean) ||
                this.Authorization.StateSpecified != default(Boolean) ||
                this.Authorization.ShouldSerializeStage()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationAuthNum
    {
        public bool ShouldSerializeStage()
        {
            //Here removing the empty elements from the array or collection
            if (this.Stage != null)
            {
                this.Stage = this.Stage.Where(x => x != default(StageAuthNum)).ToList();
            }

            bool haveSomeValue = this.Stage != null &&
                this.Stage.Count() != 0 &&
                (
                this.Stage[0].ShouldSerializeStageAddress() ||
                this.Stage[0].ShouldSerializeStageNum() ||
                this.Stage[0].ShouldSerializeWaste()
                );

            if (!haveSomeValue)
            {
                this.Stage = null;
            }

            return haveSomeValue;
        }
    }
    public partial class StageAuthNum
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

        public bool ShouldSerializeWaste()
        {
            //Here removing the empty elements from the array or collection
            if (this.Waste != null)
            {
                this.Waste = this.Waste.Where(x => x != default(StageWaste)).ToList();
            }

            bool haveSomeValue = this.Waste != null &&
                this.Waste.Count() != 0 &&
                (
                this.Waste[0].ShouldSerializeWasteCode() ||
                this.Waste[0].ShouldSerializeWasteType()
                );

            if (!haveSomeValue)
            {
                this.Waste = null;
            }

            return haveSomeValue;
        }
    }
    public partial class REG35_Stages_Validity_Period_Response
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
                this.Authorization.ShouldSerializeWaste()
                );

            if (!haveSomeValue)
            {
                this.Authorization = null;
            }

            return haveSomeValue;
        }
    }
    public partial class AuthorizationStagesValidityPeriod
    {
        public bool ShouldSerializeWaste()
        {
            //Here removing the empty elements from the array or collection
            if (this.Waste != null)
            {
                this.Waste = this.Waste.Where(x => x != default(StageWaste)).ToList();
            }

            bool haveSomeValue = this.Waste != null &&
                this.Waste.Count() != 0 &&
                (
                this.Waste[0].ShouldSerializeWasteCode() ||
                this.Waste[0].ShouldSerializeWasteType()
                );

            if (!haveSomeValue)
            {
                this.Waste = null;
            }

            return haveSomeValue;
        }
    }
}
