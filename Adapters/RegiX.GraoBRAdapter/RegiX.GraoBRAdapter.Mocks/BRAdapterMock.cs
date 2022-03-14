using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GraoBRAdapter.AdapterService;

namespace TechnoLogica.RegiX.GraoBRAdapter.Mocks
{
    public class BRAdapterMock : BaseAdapterServiceProxy<IBRAdapter>
    {
        static BRAdapterMock()
        {
            RegisterResolver<MaritalStatusRequestType, MaritalStatusResponseType>(
                (i, r, a, o) => i.MaritalStatusSearch(r, a, o),
                (r) => ResolveMaritalStatusSearchFileName(r),
                (r) => AugmentMaritalStatusSearch(r)
            );

            RegisterResolver<SpouseRequestType, SpouseResponseType>(
                (i, r, a, o) => i.SpouseSearch(r, a, o),
                (r) => ResolveSpouseSearchFileName(r)
            );

            RegisterResolver<MarriageRequestType, MarriageResponseType>(
                (i, r, a, o) => i.MarriageSearch(r, a, o),
                (r) => ResolveMarriageSearchFileName(r)
            );

            RegisterResolver<MaritalStatusSpouseChildrenRequestType, MaritalStatusSpouseChildrenResponseType>(
                (i, r, a, o) => i.MaritalStatusSpouseChildrenSearch(r, a, o),
                (r) => ResolveMaritalStatusSpouseChildrenSearchFileName(r),
                (r) => AugmentMaritalStatusSpouseChildrenSearch(r)
            );
        }

        static string ResolveMaritalStatusSearchFileName(MaritalStatusRequestType r)
        {
            switch (r?.EGN?.Substring(0, 1))
            {
                case "0":
                case "1": return $"{DataFolder}MaritalStatusResponse.xml";
                case "2":
                case "3": return $"{DataFolder}MaritalStatusResponse2.xml"; 
                case "4":
                case "5": return $"{DataFolder}MaritalStatusResponse3.xml";
                case "6":
                case "7": return $"{DataFolder}MaritalStatusResponse4.xml";
                default: return $"{DataFolder}MaritalStatusResponse9.xml";
            };
        }

        static void AugmentMaritalStatusSearch(MaritalStatusResponseType r)
        {
            r.ReportDate = DateTime.Now;
            r.ReportDateSpecified = true;
        }

        static string ResolveSpouseSearchFileName(SpouseRequestType r)
        {
            switch (r?.EGN?.Substring((r.EGN.Length - 2), 1))
            {
                case "0": return $"{DataFolder}SpouseResponse.xml";
                case "2":
                case "4": return $"{DataFolder}SpouseResponse2.xml";
                case "6":
                case "8": return $"{DataFolder}SpouseResponse3.xml";
                case "1":
                case "3": return $"{DataFolder}SpouseResponse4.xml";
                default: return $"{DataFolder}SpouseResponse9.xml";
            };
        }

        static string ResolveMarriageSearchFileName(MarriageRequestType r)
        {
            switch (r?.EGN?.Substring((r.EGN.Length - 2), 1))
            {
                case "0": return $"{DataFolder}MarriageResponse.xml";
                case "2":
                case "4": return $"{DataFolder}MarriageResponse2.xml";
                case "6":
                case "8": return $"{DataFolder}MarriageResponse3.xml";
                case "1":
                case "3": return $"{DataFolder}MarriageResponse4.xml";
                default: return $"{DataFolder}MarriageResponse9.xml";
            };
        }

        static string ResolveMaritalStatusSpouseChildrenSearchFileName(MaritalStatusSpouseChildrenRequestType r)
        {
            return $"{DataFolder}MaritalStatusSpouseChildrenResponse.xml";
        }

        static void AugmentMaritalStatusSpouseChildrenSearch(MaritalStatusSpouseChildrenResponseType r)
        {
            r.ReportDate = DateTime.Now;
            r.ReportDateSpecified = true;
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(BRAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(BRAdapterMock), typeof(IAdapterService))]
        public static IBRAdapter MockExport
        {
            get
            {
                return new BRAdapterMock().Create();
            }
        }
    }
}
