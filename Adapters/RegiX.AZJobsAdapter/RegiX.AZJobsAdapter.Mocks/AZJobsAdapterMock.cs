using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.AZJobsAdapter.AdapterService;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.AZJobsAdapter.Mocks
{
    public class AZJobsAdapterMock : BaseAdapterServiceProxy<IAZJobsAdapter>
    {
        static AZJobsAdapterMock()
        {
            RegisterResolver<EmployerFreeJobPositionsRequestType, EmployerFreeJobPositionsResponse>(
                (i, r, a, o) => i.GetEmployerFreeJobPositions(r, a, o),
                (r) => ResolveGetEmployerFreeJobPositionsFileName(r));

            RegisterResolver<EmploymentMeasureContractRequestType, EmploymentMeasureContractResponse>(
                (i, r, a, o) => i.GetEmploymentMeasureContract(r, a, o),
                (r) => ResolveGetEmploymentMeasureContractFileName(r));

            RegisterResolver<EmploymentProgramContractRequestType, EmploymentProgramContractResponse>(
                (i, r, a, o) => i.GetEmploymentProgramContract(r, a, o),
                (r) => ResolveGetEmploymentProgramContractFileName(r));

            RegisterResolver<JobSeekerContractsRequestType, JobSeekerContractsData>(
                (i, r, a, o) => i.GetJobSeekerContracts(r, a, o),
                (r) => ResolveGetJobSeekerContractsFileName(r));

            RegisterResolver<JobSeekerDirectionsRequestType, JobSeekerDirectionsData>(
                (i, r, a, o) => i.GetJobSeekerDirections(r, a, o),
                (r) => ResolveGetJobSeekerDirectionsFileName(r));

            RegisterResolver<JobSeekerHistoryRegistrationsRequestType, JobSeekerHistoryData>(
                (i, r, a, o) => i.GetJobSeekerHistoryRegistrations(r, a, o),
                (r) => ResolveGetJobSeekerHistoryRegistrationsFileName(r));

            RegisterResolver<JobSeekerStatusRequestType, JobSeekerStatusData>(
                (i, r, a, o) => i.GetJobSeekerStatus(r, a, o),
                (r) => ResolveGetJobSeekerStatusFileName(r));

            RegisterResolver<JobSeekerTrainingsRequestType, JobSeekerTrainingsData>(
                (i, r, a, o) => i.GetJobSeekerTrainings(r, a, o),
                (r) => ResolveGetJobSeekerTrainingsFileName(r));
        }

        private static string ResolveGetEmployerFreeJobPositionsFileName(EmployerFreeJobPositionsRequestType r)
        {
            if (r?.EntityID != null)
            {
                return $"{DataFolder}GetEmployerFreeJobPositionsTest.xml";
            }
            else
            {
                return $"{DataFolder}GetEmployerFreeJobPositionsNULLTest.xml";
            }
        }

        private static string ResolveGetEmploymentMeasureContractFileName(EmploymentMeasureContractRequestType r)
        {
            if (r?.EntityID != null)
            {
                return $"{DataFolder}GetEmploymentMeasureContractTest.xml";
            }
            else
            {
                return $"{DataFolder}GetEmploymentMeasureContractNULLTest.xml";
            }
        }

        private static string ResolveGetEmploymentProgramContractFileName(EmploymentProgramContractRequestType r)
        {
            if (r?.EntityID != null)
            {
                return $"{DataFolder}GetEmploymentProgramContractTest.xml";
            }
            else
            {
                return $"{DataFolder}GetEmploymentProgramContractNULLTest.xml";
            }
        }

        private static string ResolveGetJobSeekerContractsFileName(JobSeekerContractsRequestType r)
        {
            if (r?.PersonalID != null)
            {
                return $"{DataFolder}GetJobSeekerContractsTest.xml";
            }
            else
            {
                return $"{DataFolder}GetJobSeekerContractsNULLTest.xml";
            }
        }

        private static string ResolveGetJobSeekerDirectionsFileName(JobSeekerDirectionsRequestType r)
        {
            if (r?.PersonalID != null)
            {
                return $"{DataFolder}GetJobSeekerDirectionsTest.xml";
            }
            else
            {
                return $"{DataFolder}GetJobSeekerDirectionsNULLTest.xml";
            }
        }

        private static string ResolveGetJobSeekerHistoryRegistrationsFileName(JobSeekerHistoryRegistrationsRequestType r)
        {
            if (r?.PersonalID != null)
            {
                return $"{DataFolder}GetJobSeekerHistoryRegistrationsTest.xml";
            }
            else
            {
                return $"{DataFolder}GetJobSeekerHistoryRegistrationsNULLTest.xml";
            }
        }

        private static string ResolveGetJobSeekerStatusFileName(JobSeekerStatusRequestType r)
        {
            if (r?.PersonalID != null)
            {
                return $"{DataFolder}GetJobSeekerStatusTest.xml";
            }
            else
            {
                return $"{DataFolder}GetJobSeekerStatusNULLTest.xml";
            }
        }

        private static string ResolveGetJobSeekerTrainingsFileName(JobSeekerTrainingsRequestType r)
        {
            if (r?.PersonalID != null)
            {
                return $"{DataFolder}GetJobSeekerTrainingsTest.xml";
            }
            else
            {
                return $"{DataFolder}GetJobSeekerTrainingsNULLTest.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(AZJobsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(AZJobsAdapterMock), typeof(IAdapterService))]
        public static IAZJobsAdapter MockExport
        {
            get
            {
                return new AZJobsAdapterMock().Create();
            }
        }
    }
}
