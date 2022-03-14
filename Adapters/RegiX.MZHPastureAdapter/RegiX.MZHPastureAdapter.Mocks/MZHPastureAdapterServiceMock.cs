using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MZHPastureAdapter.AdapterService;

namespace TechnoLogica.RegiX.MZHPastureAdapter.Mock
{
    public class MZHPastureAdapterMock : BaseAdapterServiceProxy<IMZHPastureAdapterService>
    {
        static MZHPastureAdapterMock()
        {
            RegisterResolver<PastureMeadowLandRequestType, PastureMeadowLandResponse>(
                (i, r, a, o) => i.GetPastureMeadowLand(r, a, o),
                (r) => ResolveGetPastureMeadowLandFileName(r));
            RegisterResolver<PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse>(
                (i, r, a, o) => i.GetPastureMeadowLandDetail(r, a, o),
                (r) => ResolveGetPastureMeadowLandDetailFileName(r));
        }

        private static string ResolveGetPastureMeadowLandFileName(PastureMeadowLandRequestType r)
        {
            if (r != null && r.BeneficiaryIdentifier != null && r.BeneficiaryIdentifier.StartsWith("0"))
            {
                return $"{DataFolder}MZHPastureAdapter.xml";
            }
            else
            {
                return $"{DataFolder}MZHPastureAdapterNON.xml";
            }
        }

        private static string ResolveGetPastureMeadowLandDetailFileName(PastureMeadowLandDetailRequestType r)
        {         
            if (r?.BeneficiaryIdentifier != null)
            {
                return $"{DataFolder}MZHPastureDetailResponse.xml";
            }
            else
            {
                return $"{DataFolder}PastureMeadowLandDetailResponseEmpty.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MZHPastureAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MZHPastureAdapterMock), typeof(IAdapterService))]
        public static IMZHPastureAdapterService MockExport
        {
            get
            {
                return new MZHPastureAdapterMock().Create();
            }
        }
    }
}

