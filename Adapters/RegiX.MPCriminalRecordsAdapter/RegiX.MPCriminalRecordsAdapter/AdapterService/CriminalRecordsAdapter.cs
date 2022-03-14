using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.MPCriminalRecordsAdapter.CSCSService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.MPCriminalRecordsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(CriminalRecordsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(CriminalRecordsAdapter), typeof(IAdapterService))]
    public class CriminalRecordsAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, ICriminalRecordsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(CriminalRecordsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/MPCriminalRecords/MPCriminalRecords.svc")
            {
                Key = "WebServiceUrl",
                Description = "Web Service Url",
                OwnerAssembly = typeof(CriminalRecordsAdapter).Assembly
            };
        
        public CommonSignedResponse<BulletinSearchRequestType, BulletinSearchResponseType> BulletinSearch(BulletinSearchRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            CSCSService.CSCSServiceClient serviceClient = new CSCSServiceClient("CSCSService", WebServiceUrl.Value);
            GetBulletinsForPersonRequest req = new GetBulletinsForPersonRequest() { egn = argument.EGN };
            GetBulletinsForPersonResponse serviceResult = serviceClient.GetBulletinsForPerson(req);

            ObjectMapper<GetBulletinsForPersonResponse, BulletinSearchResponseType> mapper = CreateBulletinMapper(accessMatrix);
            BulletinSearchResponseType searchResults = new BulletinSearchResponseType();
            mapper.Map(serviceResult, searchResults);

            return SigningUtils.CreateAndSign(argument,
                searchResults,
                accessMatrix,
                additionalParameters);
        }

        private static ObjectMapper<GetBulletinsForPersonResponse, BulletinSearchResponseType> CreateBulletinMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<GetBulletinsForPersonResponse, BulletinSearchResponseType> mapper = new ObjectMapper<GetBulletinsForPersonResponse, BulletinSearchResponseType>(accessMatrix);

            mapper.AddObjectMap((o) => o.Person, (c) => c.person);
            mapper.AddPropertyMap((o) => o.Person.Egn, (c) => c.person.egn);
            mapper.AddPropertyMap((o) => o.Person.FirstName, (c) => c.person.firstName);
            mapper.AddPropertyMap((o) => o.Person.MiddleName, (c) => c.person.middleName);
            mapper.AddPropertyMap((o) => o.Person.LastName, (c) => c.person.lastName);
            mapper.AddPropertyMap((o) => o.Person.Birthdate, (c) => c.person.birthdate);
            mapper.AddPropertyMap((o) => o.Person.birthplace, (c) => c.person.birthplace);
            mapper.AddPropertyMap((o) => o.Person.RegionalCourtName, (c) => c.person.regionalCourtName);
            mapper.AddPropertyMap((o) => o.Person.PresentCity, (c) => c.person.presentCity);
            mapper.AddPropertyMap((o) => o.Person.PresentAddress, (c) => c.person.presentAddress);
            mapper.AddPropertyMap((o) => o.Person.MothersNames, (c) => c.person.mothersNames);
            mapper.AddPropertyMap((o) => o.Person.FathersNames, (c) => c.person.fathersNames);

            mapper.AddCollectionMap<GetBulletinsForPersonResponse>((o) => o.Bulletins, c => c.bulletins);
            mapper.AddPropertyMap((o) => o.Bulletins[0].BulletinNumber, (c) => c.bulletins[0].bulletinNumber);
            mapper.AddPropertyMap((o) => o.Bulletins[0].RegistrationDate, (c) => c.bulletins[0].registrationDate);
            mapper.AddPropertyMap((o) => o.Bulletins[0].Type, (c) => c.bulletins[0].bulletinType);
            mapper.AddPropertyMap((o) => o.Bulletins[0].CourtPrepared, (c) => c.bulletins[0].courtPrepared);
            mapper.AddPropertyMap((o) => o.Bulletins[0].ActNumber, (c) => c.bulletins[0].actNumber);
            mapper.AddPropertyMap((o) => o.Bulletins[0].ActDate, (c) => c.bulletins[0].actDate);
            mapper.AddPropertyMap((o) => o.Bulletins[0].ActExecuteDate, (c) => c.bulletins[0].actExecuteDate);
            mapper.AddPropertyMap((o) => o.Bulletins[0].ActType, (c) => c.bulletins[0].actType);
            mapper.AddPropertyMap((o) => o.Bulletins[0].CourtOfAct, (c) => c.bulletins[0].courtOfAct);
            mapper.AddPropertyMap((o) => o.Bulletins[0].CaseNumber, (c) => c.bulletins[0].caseNumber);
            mapper.AddPropertyMap((o) => o.Bulletins[0].CaseDate, (c) => c.bulletins[0].caseDate);
            mapper.AddPropertyMap((o) => o.Bulletins[0].CaseType, (c) => c.bulletins[0].caseType);
            mapper.AddPropertyMap((o) => o.Bulletins[0].BulletinDisposition, (c) => c.bulletins[0].bulletinDisposition);
            mapper.AddPropertyMap((o) => o.Bulletins[0].AdditionalInfo, (c) => c.bulletins[0].additionalInfo);


            return mapper;
        }
    }
}
