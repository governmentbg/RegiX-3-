using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.IaosREGProtectedAreasAdapter
{
    public partial class REG_PAPZ_Protected_Area_Category_Response
    {
        public bool ShouldSerializeProtectedArea()
        {
            //Here removing the empty elements from the array or collection
            if (this.ProtectedArea != null)
            {
                this.ProtectedArea = this.ProtectedArea.Where(x => x != default(ProtectedAreaType)).ToList();
            }

            bool haveSomeValue = this.ProtectedArea != null &&
                this.ProtectedArea.Count() != 0 &&
                (
                this.ProtectedArea[0].ShouldSerializeAreaCode() ||
                this.ProtectedArea[0].ShouldSerializeAreaName() ||
                this.ProtectedArea[0].ShouldSerializeDistName() ||
                this.ProtectedArea[0].ShouldSerializePopName() ||
                this.ProtectedArea[0].ShouldSerializeRegimeDescription() ||
                this.ProtectedArea[0].ShouldSerializeRegimeNumber() ||
                this.ProtectedArea[0].ShouldSerializeTerName()
                );

            if (!haveSomeValue)
            {
                this.ProtectedArea = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ProtectedAreaType
    {
        public bool ShouldSerializeAreaCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaCode);

            if (!haveSomeValue)
            {
                this.AreaCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAreaName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaName);

            if (!haveSomeValue)
            {
                this.AreaName = null;
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

        public bool ShouldSerializePopName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PopName);

            if (!haveSomeValue)
            {
                this.PopName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegimeDescription()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegimeDescription);

            if (!haveSomeValue)
            {
                this.RegimeDescription = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegimeNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegimeNumber);

            if (!haveSomeValue)
            {
                this.RegimeNumber = null;
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
    public partial class REG_PAPZ_Protected_Area_Location_Response
    {
        public bool ShouldSerializeProtectedAreaLocation()
        {
            //Here removing the empty elements from the array or collection
            if (this.ProtectedAreaLocation != null)
            {
                this.ProtectedAreaLocation = this.ProtectedAreaLocation.Where(x => x != default(ProtectedAreaLocationType)).ToList();
            }

            bool haveSomeValue = this.ProtectedAreaLocation != null &&
                this.ProtectedAreaLocation.Count() != 0 &&
                (
                this.ProtectedAreaLocation[0].ShouldSerializeAreaCode() ||
                this.ProtectedAreaLocation[0].ShouldSerializeAreaName() ||
                this.ProtectedAreaLocation[0].ShouldSerializeAreaSize() ||
                this.ProtectedAreaLocation[0].ShouldSerializeAreaType() ||
                this.ProtectedAreaLocation[0].ShouldSerializeRIOSV()
                );

            if (!haveSomeValue)
            {
                this.ProtectedAreaLocation = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ProtectedAreaLocationType
    {
        public bool ShouldSerializeAreaCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaCode);

            if (!haveSomeValue)
            {
                this.AreaCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAreaName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaName);

            if (!haveSomeValue)
            {
                this.AreaName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAreaSize()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaSize);

            if (!haveSomeValue)
            {
                this.AreaSize = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAreaType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaType);

            if (!haveSomeValue)
            {
                this.AreaType = null;
            }

            return haveSomeValue;
        }

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
    public partial class REG_PAPZ_Protected_Area_Size_Response
    {
        public bool ShouldSerializeProtectedAreaSize()
        {
            bool haveSomeValue = this.ProtectedAreaSize != null &&
                (
                this.ProtectedAreaSize.ShouldSerializeAreaName() ||
                this.ProtectedAreaSize.ShouldSerializeAreaSize() ||
                this.ProtectedAreaSize.ShouldSerializeDistName() ||
                this.ProtectedAreaSize.ShouldSerializePopName() ||
                this.ProtectedAreaSize.ShouldSerializeTerName()
                );

            if (!haveSomeValue)
            {
                this.ProtectedAreaSize = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ProtectedAreaSizeType
    {
        public bool ShouldSerializeAreaName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaName);

            if (!haveSomeValue)
            {
                this.AreaName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAreaSize()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AreaSize);

            if (!haveSomeValue)
            {
                this.AreaSize = null;
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
