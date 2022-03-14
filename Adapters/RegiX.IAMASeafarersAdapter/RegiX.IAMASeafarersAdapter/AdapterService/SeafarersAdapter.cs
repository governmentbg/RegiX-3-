using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.IAMASeafarersAdapter.SeamanCertificatesService;

namespace TechnoLogica.RegiX.IAMASeafarersAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(SeafarersAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(SeafarersAdapter), typeof(IAdapterService))]
    public class SeafarersAdapter : WebServiceAdapterService.SoapServiceBaseAdapterService, ISeafarersAdapter, IAdapterService
    {

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(SeafarersAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            new ParameterInfo<string>("http://egov.ad.tlogica.com/MockRegisters/IAMAVessels/VesselsService.asmx")
            {
                Key = Constants.WebServiceUrlParameterKeyName,
                Description = "Connection String for SOAP Web Service",
                OwnerAssembly = typeof(SeafarersAdapter).Assembly
            };

        //public override ConnectionStatusInfo CheckRegisterConnection()
        //{
        //    return new ConnectionStatusInfo()
        //    {
        //        Description = "Connection is OK!",
        //        status = ConnectionStatus.OK
        //    };
        //}

        private static ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType> CreateMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType> mapper = new ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType>(accessMatrix);

            mapper.AddPropertyMap((o) => o.EGN, (c) => c.EGN);

            mapper.AddPropertyMap((o) => o.Name, (c) => c.Name);
            mapper.AddPropertyMap((o) => o.Surname, (c) => c.Surname);
            mapper.AddPropertyMap((o) => o.FamilyName, (c) => c.FamilyName);

            mapper.AddCollectionMap<SeamanCertificates>((o) => o.Certificates, c => c.Certificates);
            mapper.AddPropertyMap((o) => o.Certificates[0].CertificateType, (c) => c.Certificates[0].CertificateType);
            mapper.AddPropertyMap((o) => o.Certificates[0].Id, (c) => c.Certificates[0].Id);
            mapper.AddPropertyMap((o) => o.Certificates[0].IssueDate, (c) => c.Certificates[0].IssueDate);
            mapper.AddPropertyMap((o) => o.Certificates[0].UniqueNumber, (c) => c.Certificates[0].UniqueNumber);
            mapper.AddPropertyMap((o) => o.Certificates[0].ValidDate, (c) => c.Certificates[0].ValidDate);
            mapper.AddFunctionMap<TechnoLogica.RegiX.IAMASeafarersAdapter.SeamanCertificatesService.Certificate, List<string>>((o) => o.Certificates[0].Duty, (c) => new List<string>(c.Duty));
            mapper.AddFunctionMap<TechnoLogica.RegiX.IAMASeafarersAdapter.SeamanCertificatesService.Certificate, List<string>>((o) => o.Certificates[0].Qualification, (c) => new List<string>(c.Qualification));

            return mapper;
        }

        public CommonSignedResponse<SeafarersLicensesRequestType, SeafarersLicensesResponseType> SeafarersLicensesSearch(SeafarersLicensesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                VesselsServiceSoapClient serviceClient = new VesselsServiceSoapClient("SeamanCertificatesServiceEndpoint", WebServiceUrl.Value);

                SeamanCertificates serviceResult = serviceClient.GetCertificatesByEGN(argument.EGN);

                ObjectMapper<SeamanCertificates, SeafarersLicensesResponseType> mapper = CreateMapper(accessMatrix);
                SeafarersLicensesResponseType searchResults = new SeafarersLicensesResponseType();
                mapper.Map(serviceResult, searchResults);
                return SigningUtils.CreateAndSign(argument,
                    searchResults,
                    accessMatrix,
                    additionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }
    }
}