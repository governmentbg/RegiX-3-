using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.REZMAAdapter;
using TechnoLogica.RegiX.REZMAAdapter.AdapterService;

namespace TechnoLogica.RegiX.REZMAAdapter.Mock
{    
    public class REZMAAdapterMock : BaseAdapterServiceProxy<IREZMAAdapter>
    {
        static REZMAAdapterMock()
        {
            RegisterResolver<CustomsObligationsRequestType, CustomsObligationsResponseType>(
                (i,r,a,o) => i.GetCustomsObligations(r,a,o),
                (r) => ResolveGetCustomsObligationsFileName(r));
            RegisterResolver<ExciseObligationsRequestType, ExciseObligationsResponseType>(
                (i, r, a, o) => i.GetExciseObligations(r, a, o),
                (r) => ResolveGetExciseObligationsFileName(r));
            RegisterResolver<CheckObligationsRequestType, CheckObligationsResponseType>(
                (i, r, a, o) => i.CheckObligations(r, a, o),
                (r) => ResolveCheckObligationsFileName(r));
        }


        private static string ResolveGetCustomsObligationsFileName(CustomsObligationsRequestType r)
        {            
            string fileName = $"{DataFolder}customObligationsResponse{Path.DirectorySeparatorChar}{r?.Identifier}.xml";
            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}customObligationsResponse{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveGetExciseObligationsFileName(ExciseObligationsRequestType r)
        {
            string fileName = $"{DataFolder}exciseObligationsResponse{Path.DirectorySeparatorChar}{r?.Identifier}.xml";
            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}exciseObligationsResponse{Path.DirectorySeparatorChar}default.xml";
            }
        }

        private static string ResolveCheckObligationsFileName(CheckObligationsRequestType r)
        {
            string fileName = $"{DataFolder}checkObligations{Path.DirectorySeparatorChar}{r?.Identifier}.xml";
            if (File.Exists(fileName))
            {
                return fileName;
            }
            else
            {
                return $"{DataFolder}checkObligations{Path.DirectorySeparatorChar}default.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(REZMAAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(REZMAAdapterMock), typeof(IAdapterService))]
        public static IREZMAAdapter MockExport
        {
            get
            {
                return new REZMAAdapterMock().Create();
            }
        }
    }
}

