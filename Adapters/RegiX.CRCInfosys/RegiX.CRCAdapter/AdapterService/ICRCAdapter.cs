using Infosys.RegiX.CRCAdapter.CRC;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace Infosys.RegiX.CRCAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за извличане на данни за 'Извършени измервания на качеството на УДИ'")]
    public interface ICRCAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за извършени измервания измервания по период")]
        CommonSignedResponse<CRCFindAllRequestType, CRCFindAllResponseType> FindAllMeasurements(CRCFindAllRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
