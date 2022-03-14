using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NelkEismeAdapter;
using TechnoLogica.RegiX.NelkEismeAdapter.AdapterService;
using TechnoLogica.RegiX.NelkEismeAdapter.XMLSchemas;

namespace TechnoLogica.RegiX.NelkEismeAdapter.Mock
{    
    public class NelkEismeAdapterMock : BaseAdapterServiceProxy<INelkEismeAdapter>
    {
        static NelkEismeAdapterMock()
        {
            RegisterResolver<GetAllExpertDecisionsByIdentifierRequest, ExpertDecisionsResponse>(
                (i,r,a,o) => i.GetAllExpertDecisionsByIdentifier(r,a,o),
                (r) => ResolveGetAllExpertDecisionsByIdentifierFileName(r));
            RegisterResolver<GetLastExpertDecisionByIdentifierRequest, ExpertDecisionsResponse>(
                (i, r, a, o) => i.GetLastExpertDecisionByIdentifier(r, a, o),
                (r) => ResolveGetLastExpertDecisionByIdentifierFileName(r));
            RegisterResolver<GetAllExpertDecisionsByPeriodRequest, ExpertDesisionShortInfoForPeriodList>(
                (i, r, a, o) => i.GetAllExpertDecisionsByPeriod(r, a, o),
                (r) => ResolveGetAllExpertDecisionsByPeriodFileName(r));
        }

        private static string ResolveGetAllExpertDecisionsByIdentifierFileName(GetAllExpertDecisionsByIdentifierRequest r)
        {
            string fileName = $"{DataFolder}GetAllExpertDecisionsByIdentifier{Path.AltDirectorySeparatorChar}{r?.Identifier}.xml";
            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetAllExpertDecisionsByIdentifier{Path.AltDirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetLastExpertDecisionByIdentifierFileName(GetLastExpertDecisionByIdentifierRequest r)
        {
            string fileName = $"{DataFolder}GetLastExpertDecisionByIdentifier{Path.AltDirectorySeparatorChar}{r?.Identifier}.xml";
            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetLastExpertDecisionByIdentifier{Path.AltDirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetAllExpertDecisionsByPeriodFileName(GetAllExpertDecisionsByPeriodRequest r)
        {
            string fileName = $"{DataFolder}GetAllExpertDecisionsByPeriod{Path.AltDirectorySeparatorChar}{r?.DateFrom.ToString("yyyy-MM-dd")}.xml";

            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}GetAllExpertDecisionsByPeriod{Path.AltDirectorySeparatorChar}default.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NelkEismeAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NelkEismeAdapterMock), typeof(IAdapterService))]
        public static INelkEismeAdapter MockExport
        {
            get
            {
                return new NelkEismeAdapterMock().Create();
            }
        }
    }
}

