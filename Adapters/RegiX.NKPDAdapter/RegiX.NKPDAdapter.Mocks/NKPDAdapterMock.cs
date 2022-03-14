using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.NKPDAdapter;
using TechnoLogica.RegiX.NKPDAdapter.AdapterService;

namespace TechnoLogica.RegiX.NKPDAdapter.Mock
{    
    public class NKPDAdapterMock : BaseAdapterServiceProxy<INKPDAdapter>
    {
        static NKPDAdapterMock()
        {
            RegisterResolver<AllNKPDDataSearchType, AllNKPDDataType>(
                (i,r,a,o) => i.GetNKPDAllData(r,a,o),
                (r) => ResolveGetNKPDAllDataFileName(r)
                );
            RegisterResolver<NKPDDataSearchType, NKPDDataType>(
                (i, r, a, o) => i.GetNKPDData(r, a, o),
                (r) => ResolveGetNKPDDataFileName(r)
                );
        }

        private static string ResolveGetNKPDAllDataFileName(AllNKPDDataSearchType r)
        {
            if (r != null && r.ValidDate != null && r.ValidDate.CompareTo(DateTime.Now) == 1)
            {
                return $"{DataFolder}AllNKPDData.xml";
            }
            else
            {
                return $"{DataFolder}AllNKPDData.xml";
            }
        }

        private static string ResolveGetNKPDDataFileName(NKPDDataSearchType r)
        {
            if (r?.Code == "1")
            {
                return $"{DataFolder}NKPDData.xml";
            }
            else
            {
                return $"{DataFolder}NKPDData.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NKPDAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NKPDAdapterMock), typeof(IAdapterService))]
        public static INKPDAdapter MockExport
        {
            get
            {
                return new NKPDAdapterMock().Create();
            }
        }
    }
}

