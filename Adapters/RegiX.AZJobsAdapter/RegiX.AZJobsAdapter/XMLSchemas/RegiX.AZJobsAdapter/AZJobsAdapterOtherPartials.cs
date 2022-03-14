using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.AZJobsAdapter
{
    public partial class EntityData
    {
        public bool ShouldSerializeEntityID()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EntityID);

            if (!haveSomeValue)
            {
                this.EntityID = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEntityName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EntityName);

            if (!haveSomeValue)
            {
                this.EntityName = null;
            }

            return haveSomeValue;
        }
    }
    public partial class PersonData
    {
        public bool ShouldSerializePersonalID()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PersonalID);

            if (!haveSomeValue)
            {
                this.PersonalID = null;
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

        public bool ShouldSerializeMiddleName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.MiddleName);

            if (!haveSomeValue)
            {
                this.MiddleName = null;
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

        public bool ShouldSerializeRegistrationNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationNumber);

            if (!haveSomeValue)
            {
                this.RegistrationNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationDBT()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationDBT);

            if (!haveSomeValue)
            {
                this.RegistrationDBT = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationStatus);

            if (!haveSomeValue)
            {
                this.RegistrationStatus = null;
            }

            return haveSomeValue;
        }
    }
    public partial class EmployerFreeJobPositionsResponse
    {
        public bool ShouldSerializeEmployerData()
        {
            bool haveSomeValue = this.EmployerData != null &&
                (
                this.EmployerData.ShouldSerializeEntityID() ||
                this.EmployerData.ShouldSerializeEntityName()
                );

            if (!haveSomeValue)
            {
                this.EmployerData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFreeJobPositions()
        {
            //Here removing the empty elements from the array or collection
            if (this.FreeJobPositions != null)
            {
                this.FreeJobPositions = this.FreeJobPositions.Where(x => x != default(FreeJobPosition)).ToList();
            }

            bool haveSomeValue = this.FreeJobPositions != null &&
                this.FreeJobPositions.Count() != 0 &&
                (
                this.FreeJobPositions[0].DateFrom != default(DateTime) ||
                this.FreeJobPositions[0].DateFromSpecified != default(Boolean) ||
                this.FreeJobPositions[0].DateTo != default(DateTime) ||
                this.FreeJobPositions[0].DateToSpecified != default(Boolean) ||
                this.FreeJobPositions[0].AnnouncedFreeJobsCount != default(Int32) ||
                this.FreeJobPositions[0].AnnouncedFreeJobsCountSpecified != default(Boolean) ||
                this.FreeJobPositions[0].JobSeekersDirectedCount != default(Int32) ||
                this.FreeJobPositions[0].JobSeekersDirectedCountSpecified != default(Boolean) ||
                this.FreeJobPositions[0].VacantJobsCount != default(Int32) ||
                this.FreeJobPositions[0].VacantJobsCountSpecified != default(Boolean) ||
                this.FreeJobPositions[0].ShouldSerializeJobPosition() ||
                this.FreeJobPositions[0].ShouldSerializeMinucipality() ||
                this.FreeJobPositions[0].ShouldSerializeArea() ||
                this.FreeJobPositions[0].ShouldSerializeTown() ||
                this.FreeJobPositions[0].ShouldSerializeDistrict() ||
                this.FreeJobPositions[0].ShouldSerializeAddress() ||
                this.FreeJobPositions[0].ShouldSerializeEducationRequirements() ||
                this.FreeJobPositions[0].ShouldSerializeLanguageSkillsRequirements() ||
                this.FreeJobPositions[0].ShouldSerializeComputerSkillsRequirements()
                );

            if (!haveSomeValue)
            {
                this.FreeJobPositions = null;
            }

            return haveSomeValue;
        }
    }
    public partial class FreeJobPosition
    {
        public bool ShouldSerializeJobPosition()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.JobPosition);

            if (!haveSomeValue)
            {
                this.JobPosition = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMinucipality()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Minucipality);

            if (!haveSomeValue)
            {
                this.Minucipality = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeArea()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Area);

            if (!haveSomeValue)
            {
                this.Area = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTown()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Town);

            if (!haveSomeValue)
            {
                this.Town = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDistrict()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.District);

            if (!haveSomeValue)
            {
                this.District = null;
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

        public bool ShouldSerializeEducationRequirements()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EducationRequirements);

            if (!haveSomeValue)
            {
                this.EducationRequirements = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLanguageSkillsRequirements()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LanguageSkillsRequirements);

            if (!haveSomeValue)
            {
                this.LanguageSkillsRequirements = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeComputerSkillsRequirements()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ComputerSkillsRequirements);

            if (!haveSomeValue)
            {
                this.ComputerSkillsRequirements = null;
            }

            return haveSomeValue;
        }
    }
    public partial class EmploymentMeasureContractResponse
    {
        public bool ShouldSerializeEmployerData()
        {
            bool haveSomeValue = this.EmployerData != null &&
                (
                this.EmployerData.ShouldSerializeEntityID() ||
                this.EmployerData.ShouldSerializeEntityName()
                );

            if (!haveSomeValue)
            {
                this.EmployerData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmploymentMeasureContracts()
        {
            //Here removing the empty elements from the array or collection
            if (this.EmploymentMeasureContracts != null)
            {
                this.EmploymentMeasureContracts = this.EmploymentMeasureContracts.Where(x => x != default(EmploymentMeasureContract)).ToList();
            }

            bool haveSomeValue = this.EmploymentMeasureContracts != null &&
                this.EmploymentMeasureContracts.Count() != 0 &&
                (
                this.EmploymentMeasureContracts[0].ContractDate != default(DateTime) ||
                this.EmploymentMeasureContracts[0].ContractDateSpecified != default(Boolean) ||
                this.EmploymentMeasureContracts[0].ShouldSerializeContractNumber() ||
                this.EmploymentMeasureContracts[0].ShouldSerializeEmploymentMeasureName() ||
                this.EmploymentMeasureContracts[0].ShouldSerializeContractStatus()
                );

            if (!haveSomeValue)
            {
                this.EmploymentMeasureContracts = null;
            }

            return haveSomeValue;
        }
    }
    public partial class EmploymentMeasureContract
    {
        public bool ShouldSerializeContractNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractNumber);

            if (!haveSomeValue)
            {
                this.ContractNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmploymentMeasureName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EmploymentMeasureName);

            if (!haveSomeValue)
            {
                this.EmploymentMeasureName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeContractStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractStatus);

            if (!haveSomeValue)
            {
                this.ContractStatus = null;
            }

            return haveSomeValue;
        }
    }
    public partial class EmploymentProgramContractResponse
    {
        public bool ShouldSerializeEmployerData()
        {
            bool haveSomeValue = this.EmployerData != null &&
                (
                this.EmployerData.ShouldSerializeEntityID() ||
                this.EmployerData.ShouldSerializeEntityName()
                );

            if (!haveSomeValue)
            {
                this.EmployerData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmploymentProgramContracts()
        {
            //Here removing the empty elements from the array or collection
            if (this.EmploymentProgramContracts != null)
            {
                this.EmploymentProgramContracts = this.EmploymentProgramContracts.Where(x => x != default(EmploymentProgramContract)).ToList();
            }

            bool haveSomeValue = this.EmploymentProgramContracts != null &&
                this.EmploymentProgramContracts.Count() != 0 &&
                (
                this.EmploymentProgramContracts[0].ContractDate != default(DateTime) ||
                this.EmploymentProgramContracts[0].ContractDateSpecified != default(Boolean) ||
                this.EmploymentProgramContracts[0].ShouldSerializeContractNumber() ||
                this.EmploymentProgramContracts[0].ShouldSerializeEmploymentProgramName() ||
                this.EmploymentProgramContracts[0].ShouldSerializeContractStatus()
                );

            if (!haveSomeValue)
            {
                this.EmploymentProgramContracts = null;
            }

            return haveSomeValue;
        }
    }
    public partial class EmploymentProgramContract
    {
        public bool ShouldSerializeContractNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractNumber);

            if (!haveSomeValue)
            {
                this.ContractNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmploymentProgramName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EmploymentProgramName);

            if (!haveSomeValue)
            {
                this.EmploymentProgramName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeContractStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractStatus);

            if (!haveSomeValue)
            {
                this.ContractStatus = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerContractsData
    {
        public bool ShouldSerializeJobSeekerPersonData()
        {
            bool haveSomeValue = this.JobSeekerPersonData != null &&
                (
                this.JobSeekerPersonData.RegistrationDate != default(DateTime) ||
                this.JobSeekerPersonData.RegistrationDateSpecified != default(Boolean) ||
                this.JobSeekerPersonData.ShouldSerializePersonalID() ||
                this.JobSeekerPersonData.ShouldSerializeFirstName() ||
                this.JobSeekerPersonData.ShouldSerializeMiddleName() ||
                this.JobSeekerPersonData.ShouldSerializeLastName() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationNumber() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationDBT() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationStatus()
                );

            if (!haveSomeValue)
            {
                this.JobSeekerPersonData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeContracts()
        {
            bool haveSomeValue = this.Contracts != null &&
                (
                this.Contracts.ShouldSerializeContract()
                );

            if (!haveSomeValue)
            {
                this.Contracts = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerContractsDataJobSeekerPersonData
    {
        public bool ShouldSerializePersonalID()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PersonalID);

            if (!haveSomeValue)
            {
                this.PersonalID = null;
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

        public bool ShouldSerializeMiddleName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.MiddleName);

            if (!haveSomeValue)
            {
                this.MiddleName = null;
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

        public bool ShouldSerializeRegistrationNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationNumber);

            if (!haveSomeValue)
            {
                this.RegistrationNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationDBT()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationDBT);

            if (!haveSomeValue)
            {
                this.RegistrationDBT = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationStatus);

            if (!haveSomeValue)
            {
                this.RegistrationStatus = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ContractData
    {
        public bool ShouldSerializeContractNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractNumber);

            if (!haveSomeValue)
            {
                this.ContractNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMeasure()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Measure);

            if (!haveSomeValue)
            {
                this.Measure = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeContractStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ContractStatus);

            if (!haveSomeValue)
            {
                this.ContractStatus = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerContractsDataContracts
    {
        public bool ShouldSerializeContract()
        {
            //Here removing the empty elements from the array or collection
            if (this.Contract != null)
            {
                this.Contract = this.Contract.Where(x => x != default(ContractData)).ToList();
            }

            bool haveSomeValue = this.Contract != null &&
                this.Contract.Count() != 0 &&
                (
                this.Contract[0].ShouldSerializeContractNumber() ||
                this.Contract[0].ShouldSerializeMeasure() ||
                this.Contract[0].ShouldSerializeContractStatus()
                );

            if (!haveSomeValue)
            {
                this.Contract = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerDirectionsData
    {
        public bool ShouldSerializeDirections()
        {
            bool haveSomeValue = this.Directions != null &&
                (
                this.Directions.ShouldSerializeDirection()
                );

            if (!haveSomeValue)
            {
                this.Directions = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeJobSeekerPersonData()
        {
            bool haveSomeValue = this.JobSeekerPersonData != null &&
                (
                this.JobSeekerPersonData.RegistrationDate != default(DateTime) ||
                this.JobSeekerPersonData.RegistrationDateSpecified != default(Boolean) ||
                this.JobSeekerPersonData.ShouldSerializePersonalID() ||
                this.JobSeekerPersonData.ShouldSerializeFirstName() ||
                this.JobSeekerPersonData.ShouldSerializeMiddleName() ||
                this.JobSeekerPersonData.ShouldSerializeLastName() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationNumber() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationDBT() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationStatus()
                );

            if (!haveSomeValue)
            {
                this.JobSeekerPersonData = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerDirectionsDataDirections
    {
        public bool ShouldSerializeDirection()
        {
            //Here removing the empty elements from the array or collection
            if (this.Direction != null)
            {
                this.Direction = this.Direction.Where(x => x != default(DirectionData)).ToList();
            }

            bool haveSomeValue = this.Direction != null &&
                this.Direction.Count() != 0 &&
                (
                this.Direction[0].ResultDate != default(DateTime) ||
                this.Direction[0].ResultDateSpecified != default(Boolean) ||
                this.Direction[0].ShouldSerializeRegistrationNumber() ||
                this.Direction[0].ShouldSerializeFreeWorkPlace() ||
                this.Direction[0].ShouldSerializeEmployer() ||
                this.Direction[0].ShouldSerializeJobPosition() ||
                this.Direction[0].ShouldSerializeState()
                );

            if (!haveSomeValue)
            {
                this.Direction = null;
            }

            return haveSomeValue;
        }
    }
    public partial class DirectionData
    {
        public bool ShouldSerializeRegistrationNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationNumber);

            if (!haveSomeValue)
            {
                this.RegistrationNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFreeWorkPlace()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FreeWorkPlace);

            if (!haveSomeValue)
            {
                this.FreeWorkPlace = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmployer()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Employer);

            if (!haveSomeValue)
            {
                this.Employer = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeJobPosition()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.JobPosition);

            if (!haveSomeValue)
            {
                this.JobPosition = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeState()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.State);

            if (!haveSomeValue)
            {
                this.State = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerHistoryData
    {
        public bool ShouldSerializeJobSeekerPersonData()
        {
            bool haveSomeValue = this.JobSeekerPersonData != null &&
                (
                this.JobSeekerPersonData.RegistrationDate != default(DateTime) ||
                this.JobSeekerPersonData.RegistrationDateSpecified != default(Boolean) ||
                this.JobSeekerPersonData.ShouldSerializePersonalID() ||
                this.JobSeekerPersonData.ShouldSerializeFirstName() ||
                this.JobSeekerPersonData.ShouldSerializeMiddleName() ||
                this.JobSeekerPersonData.ShouldSerializeLastName() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationNumber() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationDBT() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationStatus()
                );

            if (!haveSomeValue)
            {
                this.JobSeekerPersonData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeHistoryOfRegistrations()
        {
            bool haveSomeValue = this.HistoryOfRegistrations != null &&
                (
                this.HistoryOfRegistrations.ShouldSerializeHistoryOfRegistration()
                );

            if (!haveSomeValue)
            {
                this.HistoryOfRegistrations = null;
            }

            return haveSomeValue;
        }
    }
    public partial class RegistrationHistoryData
    {
        public bool ShouldSerializeActivity()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Activity);

            if (!haveSomeValue)
            {
                this.Activity = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationNumber);

            if (!haveSomeValue)
            {
                this.RegistrationNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationGroup()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationGroup);

            if (!haveSomeValue)
            {
                this.RegistrationGroup = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeReason()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Reason);

            if (!haveSomeValue)
            {
                this.Reason = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationDBT()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationDBT);

            if (!haveSomeValue)
            {
                this.RegistrationDBT = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerHistoryDataHistoryOfRegistrations
    {
        public bool ShouldSerializeHistoryOfRegistration()
        {
            //Here removing the empty elements from the array or collection
            if (this.HistoryOfRegistration != null)
            {
                this.HistoryOfRegistration = this.HistoryOfRegistration.Where(x => x != default(RegistrationHistoryData)).ToList();
            }

            bool haveSomeValue = this.HistoryOfRegistration != null &&
                this.HistoryOfRegistration.Count() != 0 &&
                (
                this.HistoryOfRegistration[0].RegistrationDate != default(DateTime) ||
                this.HistoryOfRegistration[0].RegistrationDateSpecified != default(Boolean) ||
                this.HistoryOfRegistration[0].ShouldSerializeActivity() ||
                this.HistoryOfRegistration[0].ShouldSerializeRegistrationNumber() ||
                this.HistoryOfRegistration[0].ShouldSerializeRegistrationGroup() ||
                this.HistoryOfRegistration[0].ShouldSerializeReason() ||
                this.HistoryOfRegistration[0].ShouldSerializeRegistrationDBT()
                );

            if (!haveSomeValue)
            {
                this.HistoryOfRegistration = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerStatusData
    {
        public bool ShouldSerializeRegistrationGroup()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationGroup);

            if (!haveSomeValue)
            {
                this.RegistrationGroup = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeJobSeekerPersonData()
        {
            bool haveSomeValue = this.JobSeekerPersonData != null &&
                (
                this.JobSeekerPersonData.RegistrationDate != default(DateTime) ||
                this.JobSeekerPersonData.RegistrationDateSpecified != default(Boolean) ||
                this.JobSeekerPersonData.ShouldSerializePersonalID() ||
                this.JobSeekerPersonData.ShouldSerializeFirstName() ||
                this.JobSeekerPersonData.ShouldSerializeMiddleName() ||
                this.JobSeekerPersonData.ShouldSerializeLastName() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationNumber() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationDBT() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationStatus()
                );

            if (!haveSomeValue)
            {
                this.JobSeekerPersonData = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerTrainingsData
    {
        public bool ShouldSerializeJobSeekerPersonData()
        {
            bool haveSomeValue = this.JobSeekerPersonData != null &&
                (
                this.JobSeekerPersonData.RegistrationDate != default(DateTime) ||
                this.JobSeekerPersonData.RegistrationDateSpecified != default(Boolean) ||
                this.JobSeekerPersonData.ShouldSerializePersonalID() ||
                this.JobSeekerPersonData.ShouldSerializeFirstName() ||
                this.JobSeekerPersonData.ShouldSerializeMiddleName() ||
                this.JobSeekerPersonData.ShouldSerializeLastName() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationNumber() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationDBT() ||
                this.JobSeekerPersonData.ShouldSerializeRegistrationStatus()
                );

            if (!haveSomeValue)
            {
                this.JobSeekerPersonData = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTrainings()
        {
            bool haveSomeValue = this.Trainings != null &&
                (
                this.Trainings.ShouldSerializeTraining()
                );

            if (!haveSomeValue)
            {
                this.Trainings = null;
            }

            return haveSomeValue;
        }
    }
    public partial class TrainingData
    {
        public bool ShouldSerializeRegistrationNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationNumber);

            if (!haveSomeValue)
            {
                this.RegistrationNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTrainingType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.TrainingType);

            if (!haveSomeValue)
            {
                this.TrainingType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMeasure()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Measure);

            if (!haveSomeValue)
            {
                this.Measure = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTrainingName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.TrainingName);

            if (!haveSomeValue)
            {
                this.TrainingName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeResult()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Result);

            if (!haveSomeValue)
            {
                this.Result = null;
            }

            return haveSomeValue;
        }
    }
    public partial class JobSeekerTrainingsDataTrainings
    {
        public bool ShouldSerializeTraining()
        {
            //Here removing the empty elements from the array or collection
            if (this.Training != null)
            {
                this.Training = this.Training.Where(x => x != default(TrainingData)).ToList();
            }

            bool haveSomeValue = this.Training != null &&
                this.Training.Count() != 0 &&
                (
                this.Training[0].DateFrom != default(DateTime) ||
                this.Training[0].DateFromSpecified != default(Boolean) ||
                this.Training[0].DateTo != default(DateTime) ||
                this.Training[0].DateToSpecified != default(Boolean) ||
                this.Training[0].ShouldSerializeRegistrationNumber() ||
                this.Training[0].ShouldSerializeTrainingType() ||
                this.Training[0].ShouldSerializeMeasure() ||
                this.Training[0].ShouldSerializeTrainingName() ||
                this.Training[0].ShouldSerializeResult()
                );

            if (!haveSomeValue)
            {
                this.Training = null;
            }

            return haveSomeValue;
        }
    }
}
