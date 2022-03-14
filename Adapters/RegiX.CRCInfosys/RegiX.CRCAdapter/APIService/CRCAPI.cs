using Infosys.RegiX.CRCAdapter.AdapterService;
using Infosys.RegiX.CRCAdapter.CRC;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace Infosys.RegiX.CRCAdapter.APIService
{
    [ExportFullName(typeof(ICRCAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class CRCAPI : BaseAPIService<ICRCAPI>, ICRCAPI
    {
        public ServiceResultDataSigned<CRCFindAllRequestType, CRCFindAllResponseType> FindAllMeasurements(ServiceRequestData<CRCFindAllRequestType> argument)
        {
            return AdapterClient.Execute<ICRCAdapter, CRCFindAllRequestType, CRCFindAllResponseType>(
                (i, r, a, o) => i.FindAllMeasurements(r, a, o),
                argument);
        }
    }
}
