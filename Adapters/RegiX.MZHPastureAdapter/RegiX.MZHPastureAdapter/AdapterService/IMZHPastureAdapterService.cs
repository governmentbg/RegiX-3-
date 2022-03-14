using System.ComponentModel;
using System.ServiceModel;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MZHPastureAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за комуникация с регистър MZH Pasture meadow land")]
    public interface IMZHPastureAdapterService : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за ползване на пасища, мери и ливади - резултат")]
        CommonSignedResponse<PastureMeadowLandRequestType, PastureMeadowLandResponse> GetPastureMeadowLand(PastureMeadowLandRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);

        [OperationContract]
        [Description("Справка с детайли за ползване на пасища, мери и ливади - резултат")]
        CommonSignedResponse<PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse> GetPastureMeadowLandDetail(PastureMeadowLandDetailRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters);
    }
}
