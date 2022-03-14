using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.NOIHospitalSheetsAdapter.AdapterService;
using TechnoLogica.RegiX.NOIHospotalSheetsAdapter;

namespace TechnoLogica.RegiX.NOIHospitalSheetsAdapter.APIService
{
    [ExportFullName(typeof(INOIHospitalSheetsAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class NOIHospitalSheetsAPI: BaseAPIService<INOIHospitalSheetsAPI>, INOIHospitalSheetsAPI
    {
        public ServiceResultDataSigned<GetHospitalSheetsDataRequestType, GetHospitalSheetsDataResponseType> GetHospitalSheetsData(ServiceRequestData<GetHospitalSheetsDataRequestType> argument)
        {
            return AdapterClient.Execute<INOIHospitalSheetsAdapter, GetHospitalSheetsDataRequestType, GetHospitalSheetsDataResponseType>(
                       (i, r, a, o) => i.GetHospitalSheetsData(r, a, o),
                       argument);
        }
    }
}
