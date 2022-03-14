using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.IAMASeafarersAdapter.AdapterService;

namespace TechnoLogica.RegiX.IAMASeafarersAdapter.APIService
{
    [ExportFullName(typeof(ISeafarersAPI), typeof(IAPIService))]
    [Export(typeof(IAPIService))]
    public class SeafarersAPI : BaseAPIService<ISeafarersAPI>, ISeafarersAPI
    {
        public ServiceResultDataSigned<SeafarersLicensesRequestType, SeafarersLicensesResponseType> SeafarersLicensesSearch(ServiceRequestData<SeafarersLicensesRequestType> argument)
        {
            return  AdapterClient.Execute<ISeafarersAdapter, SeafarersLicensesRequestType, SeafarersLicensesResponseType>(
                        (i, r, a, o) => i.SeafarersLicensesSearch(r, a, o),
                        argument);
        }
    }
}
