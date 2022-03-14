using System;
using TechnoLogica.RegiX.RDSOAdapter.RDSOService;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.WebServiceAdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.RDSOAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(RDSOAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(RDSOAdapter), typeof(IAdapterService))]
    public class RDSOAdapter : SoapServiceBaseAdapterService, IRDSOAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(RDSOAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
           new ParameterInfo<string>("http://egov/MockRegisters/RDSO/MOMNWebServiceMock.asmx")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Web Service Url",
               OwnerAssembly = typeof(RDSOAdapter).Assembly
           };

        public CommonSignedResponse<DiplomaSearchType, DiplomaDocumentsType> GetDiplomaInfo(DiplomaSearchType diplomaSearch, Common.ObjectMapping.AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {

            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = diplomaSearch.Serialize(), Guid = id });
            try
            {
                RDSOService.wsSoapClient serviceClient = new RDSOService.wsSoapClient("wsSoap", WebServiceUrl.Value);
            int idType = 1;
            switch (diplomaSearch.IDType)
            {
                case IdentifierType.EGN:
                    idType = 1;
                    break;
                case IdentifierType.LNCh:
                    idType = 2;
                    break;
                case IdentifierType.IDN:
                    idType = 3;
                    break;
            }
            RDSOService.DiplomaDocument[] response = serviceClient.getStudentFromAdminRD(diplomaSearch.StudentID, diplomaSearch.DocumentNumber, idType);
            ObjectMapper<RDSOService.DiplomaDocument[], DiplomaDocumentsType> diplomaMapper = CreateDiplomaMapper(accessMatrix);
            DiplomaDocumentsType searchResults = new DiplomaDocumentsType();
            diplomaMapper.Map(response, searchResults);

             return SigningUtils.CreateAndSign(
                        diplomaSearch,
                        searchResults,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }

            //foreach (DiplomaDocument respDiplom in response)
            //{
            //    DiplomaDocumentsDiplomaDocument diplomObject = new DiplomaDocumentsDiplomaDocument();
            //    diplomObject.boolGender = respDiplom.boolGender;
            //    diplomObject.codeNationality = respDiplom.codeNationality;
            //    diplomObject.dtRegDate = respDiplom.dtRegDate;
            //    diplomObject.intBPlaceE = respDiplom.intBPlaceE;
            //    diplomObject.intClassType = respDiplom.intClassType;
            //    diplomObject.intDocumentType = respDiplom.intDocumentType;
            //    diplomObject.intEdForm = respDiplom.intEdForm;
            //    diplomObject.intEKATTE = respDiplom.intEKATTE;
            //    diplomObject.intID = respDiplom.intID;
            //    diplomObject.intMeanMark = respDiplom.intMeanMark;
            //    diplomObject.intSchoolID = respDiplom.intSchoolID;
            //    diplomObject.intStudentID = respDiplom.intStudentID;
            //    diplomObject.intVETGroupIdent = respDiplom.intVETGroupIdent;
            //    diplomObject.intVETLevel = respDiplom.intVETLevel;
            //    diplomObject.intVETSpeciality = respDiplom.intVETSpeciality;
            //    diplomObject.intYearGraduated = respDiplom.intYearGraduated;
            //    diplomObject.vcClassTypeName = respDiplom.vcClassTypeName;
            //    diplomObject.vcDocumentName = respDiplom.vcDocumentName;
            //    diplomObject.vcEdFormName = respDiplom.vcEdFormName;
            //    diplomObject.vcEducAreaName = respDiplom.vcEducAreaName;
            //    diplomObject.vcIDNumberText = respDiplom.vcIDNumberText;
            //    diplomObject.vcName1 = respDiplom.vcName1;
            //    diplomObject.vcName2 = respDiplom.vcName2;
            //    diplomObject.vcName3 = respDiplom.vcName3;
            //    diplomObject.vcPrnNo = respDiplom.vcPrnNo;
            //    diplomObject.vcPrnSer = respDiplom.vcPrnSer;
            //    diplomObject.vcRegNo1 = respDiplom.vcRegNo1;
            //    diplomObject.vcRegNo2 = respDiplom.vcRegNo2;
            //    diplomObject.vcSchoolName = respDiplom.vcSchoolName;
            //    diplomObject.vcVETLevelName = respDiplom.vcVETLevelName;
            //    diplomObject.vcVETSpecialityName = respDiplom.vcVETSpecialityName;
            //    diplomObject.DocumentImages = respDiplom.documentImages;
            //    searchResults.DiplomaDocument.Add(diplomObject);
            //}
            //return searchResults;
        }

        public CommonSignedResponse<CertifiedDocumentsSearchType, CertifiedDocumentsType> GetCertifiedDiplomaInfo(CertifiedDocumentsSearchType diplomaSearch, Common.ObjectMapping.AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = diplomaSearch.Serialize(), Guid = id });
            try
        {
            RDSOService.wsSoapClient serviceClient = new RDSOService.wsSoapClient("wsSoap", WebServiceUrl.Value);
            int idType = 1;
            switch (diplomaSearch.IDType)
            {
                case IdentifierType.EGN:
                    idType = 1;
                    break;
                case IdentifierType.LNCh:
                    idType = 2;
                    break;
                case IdentifierType.IDN:
                    idType = 3;
                    break;
            }
            RDSOService.CertifiedDocument[] response = serviceClient.getStudentFromAdminRDC(diplomaSearch.StudentID, diplomaSearch.DocumentNumber, idType);
            ObjectMapper<RDSOService.CertifiedDocument[], CertifiedDocumentsType> diplomaMapper = CreateCertifiedDiplomaMapper(accessMatrix);
            CertifiedDocumentsType searchResults = new CertifiedDocumentsType();
            diplomaMapper.Map(response, searchResults);

            return SigningUtils.CreateAndSign(
                        diplomaSearch,
                        searchResults,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static ObjectMapper<RDSOService.DiplomaDocument[], DiplomaDocumentsType> CreateDiplomaMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<RDSOService.DiplomaDocument[], DiplomaDocumentsType> mapper = new ObjectMapper<RDSOService.DiplomaDocument[], DiplomaDocumentsType>(accessMatrix);

            RDSOService.DiplomaDocument[] d = new DiplomaDocument[] { };
            mapper.AddCollectionMap<RDSOService.DiplomaDocument[]>((o) => o.DiplomaDocument, c => c);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].boolGender, (c) => c[0].boolGender);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].codeNationality, (c) => c[0].codeNationality);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].dtRegDate, (c) => c[0].dtRegDate);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intBPlaceE, (c) => c[0].intBPlaceE);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intClassType, (c) => c[0].intClassType);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intDocumentType, (c) => c[0].intDocumentType);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intEdForm, (c) => c[0].intEdForm);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intEKATTE, (c) => c[0].intEKATTE);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intID, (c) => c[0].intID);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intMeanMark, (c) => c[0].intMeanMark);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intSchoolID, (c) => c[0].intSchoolID);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intStudentID, (c) => c[0].intStudentID);
            mapper.AddFunctionMap<RDSOService.DiplomaDocument, IdentifierType>(
                (o) => o.DiplomaDocument[0].IDType,
                (c) =>
                {
                    switch (c.IDType)
                    {
                        case 1:
                            return IdentifierType.EGN;
                        case 2:
                            return IdentifierType.LNCh;
                        case 3:
                            return IdentifierType.IDN;
                        default:
                            return IdentifierType.EGN;
                    }
                }
           );
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intVETGroupIdent, (c) => c[0].intVETGroupIdent);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intVETLevel, (c) => c[0].intVETLevel);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intVETSpeciality, (c) => c[0].intVETSpeciality);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].intYearGraduated, (c) => c[0].intYearGraduated);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcClassTypeName, (c) => c[0].vcClassTypeName);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcDocumentName, (c) => c[0].vcDocumentName);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcEdFormName, (c) => c[0].vcEdFormName);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcEducAreaName, (c) => c[0].vcEducAreaName);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcName1, (c) => c[0].vcName1);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcName2, (c) => c[0].vcName2);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcName3, (c) => c[0].vcName3);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcPrnNo, (c) => c[0].vcPrnNo);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcPrnSer, (c) => c[0].vcPrnSer);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcRegNo1, (c) => c[0].vcRegNo1);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcRegNo2, (c) => c[0].vcRegNo2);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcSchoolName, (c) => c[0].vcSchoolName);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcVETLevelName, (c) => c[0].vcVETLevelName);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].vcVETSpecialityName, (c) => c[0].vcVETSpecialityName);
            mapper.AddPropertyMap((o) => o.DiplomaDocument[0].DocumentImages, (c) => c[0].documentImages);

            return mapper;
        }

        private static ObjectMapper<RDSOService.CertifiedDocument[], CertifiedDocumentsType> CreateCertifiedDiplomaMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<RDSOService.CertifiedDocument[], CertifiedDocumentsType> mapper = new ObjectMapper<RDSOService.CertifiedDocument[], CertifiedDocumentsType>(accessMatrix);

            RDSOService.CertifiedDocument[] d = new CertifiedDocument[] { };
            mapper.AddCollectionMap<RDSOService.CertifiedDocument[]>((o) => o.CertifiedDocument, c => c);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].intDocumentType, (c) => c[0].intDocumentType);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].intID, (c) => c[0].intID);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].intStudentID, (c) => c[0].intStudentID);
            mapper.AddFunctionMap<RDSOService.CertifiedDocument, IdentifierType>(
                (o) => o.CertifiedDocument[0].IDType,
                (c) =>
                {
                    switch (c.IDType)
                    {
                        case 1:
                            return IdentifierType.EGN;
                        case 2:
                            return IdentifierType.LNCh;
                        case 3:
                            return IdentifierType.IDN;
                        default:
                            return IdentifierType.EGN;
                    }
                }
           );
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].vcDocumentName, (c) => c[0].vcDocumentName);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].vcName1, (c) => c[0].vcName1);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].vcName2, (c) => c[0].vcName2);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].vcName3, (c) => c[0].vcName3);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].vcPrnNo, (c) => c[0].vcPrnNo);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].vcPrnSer, (c) => c[0].vcPrnSer);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].vcRegNo, (c) => c[0].vcRegNo);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].dtCertDate, (c) => c[0].dtCertDate);
            mapper.AddPropertyMap((o) => o.CertifiedDocument[0].DocumentImages, (c) => c[0].documentImages);

            return mapper;
        }
    }
}
