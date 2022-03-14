//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter
//{
//    public partial class PenalProvisionForPeriodResponse
//    {
//        public bool ShouldSerializePenalProvisions()
//        {
//            //Here removing the empty elements from the array or collection
//            if (this.PenalProvisions != null)
//            {
//                this.PenalProvisions = this.PenalProvisions.Where(x => x != default(PenalProvision)).ToList();
//            }

//            bool haveSomeValue = this.PenalProvisions != null &&
//                this.PenalProvisions.Count() != 0 &&
//                (
//                this.PenalProvisions[0].IssueDate != default(DateTime) ||
//                this.PenalProvisions[0].IssueDateSpecified != default(Boolean) ||
//                this.PenalProvisions[0].SanctionSize != default(Double) ||
//                this.PenalProvisions[0].SanctionSizeSpecified != default(Boolean) ||
//                this.PenalProvisions[0].PenalProvisionEnforcementDate != default(DateTime) ||
//                this.PenalProvisions[0].PenalProvisionEnforcementDateSpecified != default(Boolean) ||
//                this.PenalProvisions[0].ShouldSerializePenalProvisionNumber() ||
//                this.PenalProvisions[0].ShouldSerializeIntruder() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionType() ||
//                this.PenalProvisions[0].ShouldSerializeDocumentIssuer() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionSizeChanged() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionSizeText() ||
//                this.PenalProvisions[0].ShouldSerializeViolationPart() ||
//                this.PenalProvisions[0].ShouldSerializeViolationChapter() ||
//                this.PenalProvisions[0].ShouldSerializeViolationSection() ||
//                this.PenalProvisions[0].ShouldSerializeViolationText()
//                );

//            if (!haveSomeValue)
//            {
//                this.PenalProvisions = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class PenalProvisionMediatorActResponse
//    {
//        public bool ShouldSerializePenalProvisions()
//        {
//            //Here removing the empty elements from the array or collection
//            if (this.PenalProvisions != null)
//            {
//                this.PenalProvisions = this.PenalProvisions.Where(x => x != default(PenalProvision)).ToList();
//            }

//            bool haveSomeValue = this.PenalProvisions != null &&
//                this.PenalProvisions.Count() != 0 &&
//                (
//                this.PenalProvisions[0].IssueDate != default(DateTime) ||
//                this.PenalProvisions[0].IssueDateSpecified != default(Boolean) ||
//                this.PenalProvisions[0].SanctionSize != default(Double) ||
//                this.PenalProvisions[0].SanctionSizeSpecified != default(Boolean) ||
//                this.PenalProvisions[0].PenalProvisionEnforcementDate != default(DateTime) ||
//                this.PenalProvisions[0].PenalProvisionEnforcementDateSpecified != default(Boolean) ||
//                this.PenalProvisions[0].ShouldSerializePenalProvisionNumber() ||
//                this.PenalProvisions[0].ShouldSerializeIntruder() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionType() ||
//                this.PenalProvisions[0].ShouldSerializeDocumentIssuer() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionSizeChanged() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionSizeText() ||
//                this.PenalProvisions[0].ShouldSerializeViolationPart() ||
//                this.PenalProvisions[0].ShouldSerializeViolationChapter() ||
//                this.PenalProvisions[0].ShouldSerializeViolationSection() ||
//                this.PenalProvisions[0].ShouldSerializeViolationText()
//                );

//            if (!haveSomeValue)
//            {
//                this.PenalProvisions = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class PenalProvisionUnpaidFeeResponse
//    {
//        public bool ShouldSerializePenalProvisions()
//        {
//            //Here removing the empty elements from the array or collection
//            if (this.PenalProvisions != null)
//            {
//                this.PenalProvisions = this.PenalProvisions.Where(x => x != default(PenalProvision)).ToList();
//            }

//            bool haveSomeValue = this.PenalProvisions != null &&
//                this.PenalProvisions.Count() != 0 &&
//                (
//                this.PenalProvisions[0].IssueDate != default(DateTime) ||
//                this.PenalProvisions[0].IssueDateSpecified != default(Boolean) ||
//                this.PenalProvisions[0].SanctionSize != default(Double) ||
//                this.PenalProvisions[0].SanctionSizeSpecified != default(Boolean) ||
//                this.PenalProvisions[0].PenalProvisionEnforcementDate != default(DateTime) ||
//                this.PenalProvisions[0].PenalProvisionEnforcementDateSpecified != default(Boolean) ||
//                this.PenalProvisions[0].ShouldSerializePenalProvisionNumber() ||
//                this.PenalProvisions[0].ShouldSerializeIntruder() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionType() ||
//                this.PenalProvisions[0].ShouldSerializeDocumentIssuer() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionSizeChanged() ||
//                this.PenalProvisions[0].ShouldSerializeSanctionSizeText() ||
//                this.PenalProvisions[0].ShouldSerializeViolationPart() ||
//                this.PenalProvisions[0].ShouldSerializeViolationChapter() ||
//                this.PenalProvisions[0].ShouldSerializeViolationSection() ||
//                this.PenalProvisions[0].ShouldSerializeViolationText()
//                );

//            if (!haveSomeValue)
//            {
//                this.PenalProvisions = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class FinesAndPenaltiesList
//    {
//        public bool ShouldSerializeFinesAndPenalties()
//        {
//            //Here removing the empty elements from the array or collection
//            if (this.FinesAndPenalties != null)
//            {
//                this.FinesAndPenalties = this.FinesAndPenalties.Where(x => x != default(FinesAndPenalties)).ToList();
//            }

//            bool haveSomeValue = this.FinesAndPenalties != null &&
//                this.FinesAndPenalties.Count() != 0; ;

//            if (!haveSomeValue)
//            {
//                this.FinesAndPenalties = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class FinesAndPenalties
//    { }
//    public partial class PenalProvision
//    {
//        public bool ShouldSerializePenalProvisionNumber()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.PenalProvisionNumber);

//            if (!haveSomeValue)
//            {
//                this.PenalProvisionNumber = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeIntruder()
//        {
//            bool haveSomeValue = this.Intruder != null &&
//                (
//                this.Intruder.ShouldSerializeName() ||
//                this.Intruder.ShouldSerializeIdentifier()
//                );

//            if (!haveSomeValue)
//            {
//                this.Intruder = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeSanctionType()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.SanctionType);

//            if (!haveSomeValue)
//            {
//                this.SanctionType = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeDocumentIssuer()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.DocumentIssuer);

//            if (!haveSomeValue)
//            {
//                this.DocumentIssuer = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeSanctionSizeChanged()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.SanctionSizeChanged);

//            if (!haveSomeValue)
//            {
//                this.SanctionSizeChanged = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeSanctionSizeText()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.SanctionSizeText);

//            if (!haveSomeValue)
//            {
//                this.SanctionSizeText = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeViolationPart()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ViolationPart);

//            if (!haveSomeValue)
//            {
//                this.ViolationPart = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeViolationChapter()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ViolationChapter);

//            if (!haveSomeValue)
//            {
//                this.ViolationChapter = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeViolationSection()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ViolationSection);

//            if (!haveSomeValue)
//            {
//                this.ViolationSection = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeViolationText()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ViolationText);

//            if (!haveSomeValue)
//            {
//                this.ViolationText = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class EntityData
//    {
//        public bool ShouldSerializeName()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.Name);

//            if (!haveSomeValue)
//            {
//                this.Name = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeIdentifier()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.Identifier);

//            if (!haveSomeValue)
//            {
//                this.Identifier = null;
//            }

//            return haveSomeValue;
//        }
//    }
//}
