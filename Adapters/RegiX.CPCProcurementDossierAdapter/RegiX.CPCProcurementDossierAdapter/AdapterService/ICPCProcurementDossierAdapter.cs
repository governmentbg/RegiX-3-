using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Text;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.CPCProcurementDossierAdapter;

namespace RegiX.CPCProcurementDossierAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за извличане на данни от Регистър на жалби по ЗОП")]
    public interface ICPCProcurementDossierAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за жалби по ЗОП")]
        CommonSignedResponse<GetProcurementDossierRequest, GetProcurementDossierResponse> GetProcurementDossier(GetProcurementDossierRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);

    }
}
