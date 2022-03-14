using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService;

namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.Mocks
{
    public class GitPenalProvisionsAdapterMock : BaseAdapterServiceProxy<IGitPenalProvisionsAdapter>
    {
        static GitPenalProvisionsAdapterMock()
        {
            RegisterResolver<PenalProvisionForPeriodRequest, PenalProvisionForPeriodResponse>(
                (i, r, a, o) => i.GetPenalProvisionForPeriod(r, a, o),
                (r) => ResolveGetPenalProvisionForPeriodFileName(r));
            RegisterResolver<PenalProvisionMediatorActType, PenalProvisionMediatorActResponse>(
                (i, r, a, o) => i.GetPenalProvisionMediatorAct(r, a, o),
                (r) => ResolveGetPenalProvisionMediatorActFileName(r));
            RegisterResolver<PenalProvisionUnpaidFeeType, PenalProvisionUnpaidFeeResponse>(
                (i, r, a, o) => i.GetPenalProvisionUnpaidFee(r, a, o),
                (r) => ResolveGetPenalProvisionUnpaidFeeFileName(r));
        }

        private static string ResolveGetPenalProvisionForPeriodFileName(PenalProvisionForPeriodRequest r)
        {
            if (r!= null && r.IntruderIdentifier != null && r.IntruderIdentifier.StartsWith("9"))
            {
                return $"{DataFolder}GetPenalProvisionForPeriodTest.xml";
            }
            else
            {
                return $"{DataFolder}GetPenalProvisionForPeriodNullTest.xml";
            }
        }

        private static string ResolveGetPenalProvisionMediatorActFileName(PenalProvisionMediatorActType r)
        {
            if (r != null && r.PenalProvisionRelation != null && r.PenalProvisionRelation.StartsWith("T"))
            {
                return $"{DataFolder}GetPenalProvisionMediatorActTest.xml";
            }
            else
            {
                return $"{DataFolder}GetPenalProvisionMediatorActNullTest.xml";
            }
        }

        private static string ResolveGetPenalProvisionUnpaidFeeFileName(PenalProvisionUnpaidFeeType r)
        {
            if (r != null && r.IntruderIdentifier != null && r.IntruderIdentifier.StartsWith("9"))
            {
                return $"{DataFolder}GetPenalProvisionUnpaidFeeTest.xml";
            }
            else
            {
                return $"{DataFolder}GetPenalProvisionUnpaidFeeNullTest.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(GitPenalProvisionsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(GitPenalProvisionsAdapterMock), typeof(IAdapterService))]
        public static IGitPenalProvisionsAdapter MockExport
        {
            get
            {
                return new GitPenalProvisionsAdapterMock().Create();
            }
        }
    }
}
