using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Text;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.NOIHospotalSheetsAdapter;

namespace TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService
{
    [ServiceContract]
    [Description("Адаптер за извличане на данни за болнични листове")]
    public interface INOIHospitalSheetsAdapter : IAdapterServiceWCF
    {
        [OperationContract]
        [Description("Справка за постъпили данни от издадени/ анулирани болнични листове по ЕГН/ ЛНЧ")]
        CommonSignedResponse<GetHospitalSheetsDataRequestType, GetHospitalSheetsDataResponseType> GetHospitalSheetsData(GetHospitalSheetsDataRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters);
    }
}
