//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TechnoLogica.RegiX.NRAEmploymentContractsAdapter
//{
//    public partial class EContract
//    {
//        public bool ShouldSerializeContractorBulstat()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractorBulstat);

//            if (!haveSomeValue)
//            {
//                this.ContractorBulstat = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeContractorName()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractorName);

//            if (!haveSomeValue)
//            {
//                this.ContractorName = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeIndividualEIK()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.IndividualEIK);

//            if (!haveSomeValue)
//            {
//                this.IndividualEIK = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeIndividualNames()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.IndividualNames);

//            if (!haveSomeValue)
//            {
//                this.IndividualNames = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeEcoCode()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.EcoCode);

//            if (!haveSomeValue)
//            {
//                this.EcoCode = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeProfessionCode()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ProfessionCode);

//            if (!haveSomeValue)
//            {
//                this.ProfessionCode = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class IdentityType
//    {
//        public bool ShouldSerializeID()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ID);

//            if (!haveSomeValue)
//            {
//                this.ID = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class ResponseIdentityType
//    {
//        public bool ShouldSerializeID()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.ID);

//            if (!haveSomeValue)
//            {
//                this.ID = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class StatusType
//    {
//        public bool ShouldSerializeMessage()
//        {
//            bool haveSomeValue = !string.IsNullOrEmpty(this.Message);

//            if (!haveSomeValue)
//            {
//                this.Message = null;
//            }

//            return haveSomeValue;
//        }
//    }
//    public partial class EmploymentContractsResponse
//    {
//        public bool ShouldSerializeIdentity()
//        {
//            bool haveSomeValue = this.Identity != null &&
//                (
//                this.Identity.TYPESpecified != default(Boolean) ||
//                this.Identity.ShouldSerializeID()
//                );

//            if (!haveSomeValue)
//            {
//                this.Identity = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeEContracts()
//        {
//            //Here removing the empty elements from the array or collection
//            if (this.EContracts != null)
//            {
//                this.EContracts = this.EContracts.Where(x => x != default(EContract)).ToList();
//            }

//            bool haveSomeValue = this.EContracts != null &&
//                this.EContracts.Count() != 0 &&
//                (
//                this.EContracts[0].StartDate != default(DateTime) ||
//                this.EContracts[0].StartDateSpecified != default(Boolean) ||
//                this.EContracts[0].LastAmendDate != default(DateTime) ||
//                this.EContracts[0].LastAmendDateSpecified != default(Boolean) ||
//                this.EContracts[0].EndDate != default(DateTime) ||
//                this.EContracts[0].EndDateSpecified != default(Boolean) ||
//                this.EContracts[0].ReasonSpecified != default(Boolean) ||
//                this.EContracts[0].TimeLimit != default(DateTime) ||
//                this.EContracts[0].TimeLimitSpecified != default(Boolean) ||
//                this.EContracts[0].RemunerationSpecified != default(Boolean) ||
//                this.EContracts[0].ShouldSerializeContractorBulstat() ||
//                this.EContracts[0].ShouldSerializeContractorName() ||
//                this.EContracts[0].ShouldSerializeIndividualEIK() ||
//                this.EContracts[0].ShouldSerializeIndividualNames() ||
//                this.EContracts[0].ShouldSerializeEcoCode() ||
//                this.EContracts[0].ShouldSerializeProfessionCode()
//                );

//            if (!haveSomeValue)
//            {
//                this.EContracts = null;
//            }

//            return haveSomeValue;
//        }

//        public bool ShouldSerializeStatus()
//        {
//            bool haveSomeValue = this.Status != null &&
//                (
//                this.Status.Code != default(Int32) ||
//                this.Status.CodeSpecified != default(Boolean) ||
//                this.Status.ShouldSerializeMessage()
//                );

//            if (!haveSomeValue)
//            {
//                this.Status = null;
//            }

//            return haveSomeValue;
//        }
//    }
//}
