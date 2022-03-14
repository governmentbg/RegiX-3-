using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.PDVOAdapter.AdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.PDVOAdapter.APIService
{
    [ExportFullName(typeof(IPDVOAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class PDVOAPI : BaseAPIService<IPDVOAPI>, IPDVOAPI
    {
        public ServiceResultDataSigned<AcademicRecognitionRequestType, AcademicRecognitionResponseType> GetAcademicRecognition(ServiceRequestData<AcademicRecognitionRequestType> argument)
        {
            return  AdapterClient.Execute<IPDVOAdapter, AcademicRecognitionRequestType, AcademicRecognitionResponseType>(
                        (i, r, a, o) => i.GetAcademicRecognition(r, a,o),
                        argument);
        }
    }
}
