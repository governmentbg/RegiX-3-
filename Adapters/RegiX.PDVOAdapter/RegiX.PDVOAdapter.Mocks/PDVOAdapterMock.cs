using RegiX.Adapters.Mocks;
using System;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PDVOAdapter.AdapterService;

namespace TechnoLogica.RegiX.PDVOAdapter.Mock
{
    public class PDVOAdapterMock : BaseAdapterServiceProxy<IPDVOAdapter>
    {
        static PDVOAdapterMock()
        {
            RegisterResolver<AcademicRecognitionRequestType, AcademicRecognitionResponseType>(
                (i,r, a, o) => i.GetAcademicRecognition(r,a,o),
                (r) => ResolveGetAcademicRecognitionFileName(r));
                
        }

        private static string ResolveGetAcademicRecognitionFileName(AcademicRecognitionRequestType r)
        {
            if (r != null && r.InternalAppNum != null && r.InternalAppNum.StartsWith("6"))
            {
                return $"{DataFolder}GetAcademicRecognition.xml";
            }
            else
            {
                return $"{DataFolder}GetAcademicRecognition.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(PDVOAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(PDVOAdapterMock), typeof(IAdapterService))]
        public static IPDVOAdapter MockExport
        {
            get
            {
                return new PDVOAdapterMock().Create();
            }
        }
    }
}

