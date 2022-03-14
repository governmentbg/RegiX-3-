//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Data;
//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.Common.DataContracts;
//using TechnoLogica.RegiX.WebServiceAdapterService;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;

//namespace TechnoLogica.RegiX.PvPatentsAdapter.AdapterService
//{
//    public class PvPatentsAdapter : SoapServiceBaseAdapterService, IPvPatentsAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//            //new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/PvPatents/PvPatentsService.svc")
//                      new ParameterInfo<string>("http://93.152.159.78:6668/bpo.register.ws.provider/services/BPOPatentsSearchServiceDefaultPort")
//              {
//                  Key = Constants.WebServiceUrlParameterKeyName,
//                  Description = "Web Service Url",
//                  OwnerAssembly = typeof(PvPatentsAdapter).Assembly
//              };
        
//        public CommonSignedResponse<getPatentByAppNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_App_Number(getPatentByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvPatentsServiceReference.BPOPatentsSearchClient serviceClient = new PvPatentsServiceReference.BPOPatentsSearchClient("BPOPatentsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvPatentsServiceReference.getPatentByAppNumType arg = new PvPatentsServiceReference.getPatentByAppNumType();
//                arg.appnum = argument.AppNum;
//                PvPatentsServiceReference.PatentType[] serviceResult = serviceClient.getPatentByAppNum(arg);
//                ObjectMapper<PvPatentsServiceReference.PatentType[], REG_UM_PATENT_PatentDetails_Response> mapper = CreateMapper(accessMatrix);
//                REG_UM_PATENT_PatentDetails_Response searchResults = new REG_UM_PATENT_PatentDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<PvPatentsServiceReference.PatentType[], REG_UM_PATENT_PatentDetails_Response> CreateMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<PvPatentsServiceReference.PatentType[], REG_UM_PATENT_PatentDetails_Response> mapper = new ObjectMapper<PvPatentsServiceReference.PatentType[], REG_UM_PATENT_PatentDetails_Response>(accessMatrix);

//            mapper.AddCollectionMap<PvPatentsServiceReference.PatentType[]>((o) => o.PatentDetails, (c) => c);

//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails, (c) => c[0].ApplicantDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant, (c) => c[0].ApplicantDetails.Applicant);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddFunctionMap<PvPatentsServiceReference.ApplicantType, List<string>>((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantIdentifier, (c) => (c.ApplicantIdentifier == null) ? null : c.ApplicantIdentifier.ToList());
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantNationalityCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantNationalityCode);
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicationDate, (c) => c[0].ApplicationDate);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ApplicationNumber, (c) => c[0].ApplicationNumber);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails, (c) => c[0].ExhibitionPriorityDetails);
//            mapper.AddCollectionMap<PvPatentsServiceReference.PatentType[]>((o) => o.PatentDetails[0].ExhibitionPriorityDetails, (c) => c[0].ExhibitionPriorityDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].Comment, (c) => c[0].ExhibitionPriorityDetails[0].Comment);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].Comment.languageCode, (c) => c[0].ExhibitionPriorityDetails[0].Comment.languageCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber, (c) => c[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].Comment.Value, (c) => c[0].ExhibitionPriorityDetails[0].Comment.Value);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].ExhibitionCityName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCityName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].ExhibitionDate, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionDate);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExhibitionPriorityDetails[0].ExhibitionName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].ExpiryDate, (c) => c[0].ExpiryDate);
//            mapper.AddCollectionMap<PvPatentsServiceReference.PatentType[]>((o) => o.PatentDetails[0].InventorDetails, (c) => c[0].InventorDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook, (c) => c[0].InventorDetails[0].InventorAddressBook);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails, (c) => c[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress);
//            mapper.AddCollectionMap<PvPatentsServiceReference.PatentType[]>((o) => o.PatentDetails[0].InventorDetails, (c) => c[0].InventorDetails);
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());
//            mapper.AddObjectMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorLegalEntity, (c) => c[0].InventorDetails[0].InventorLegalEntity);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].InventorDetails[0].InventorNationalityCode, (c) => c[0].InventorDetails[0].InventorNationalityCode);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].IPCClassDetails, (c) => c[0].IPCClassDetails);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentCurrentStatusCode, c => c[0].PatentCurrentStatusCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentCurrentStatusDate, (c) => c[0].PatentCurrentStatusDate);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentKind, c => c[0].PatentKind);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].PatentDescription, (c) => c[0].PatentDescription);
//            mapper.AddFunctionMap<PvPatentsServiceReference.PatentTypeIPCClassDetails, List<string>>((o) => o.PatentDetails[0].IPCClassDetails.IPCClass, (c) => (c.IPCClass == null) ? null : c.IPCClass.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.PatentTypeIPCClassDetails, List<string>>((o) => o.PatentDetails[0].IPCClassDetails.IPCName, (c) => (c.IPCName == null) ? null : c.IPCName.ToList());
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentDescription.languageCode, (c) => c[0].PatentDescription.languageCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentDescription.sequenceNumber, (c) => c[0].PatentDescription.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentDescription.Value, (c) => c[0].PatentDescription.Value);
//            mapper.AddCollectionMap<PvPatentsServiceReference.PatentType[]>((o) => o.PatentDetails[0].PatentRepresentationSheetDetails, (c) => c[0].PatentRepresentationSheetDetails);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentRepresentationSheetDetails[0].ViewBinary, (c) => c[0].PatentRepresentationSheetDetails[0].ViewBinary);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentRepresentationSheetDetails[0].ViewFileFormat, (c) => c[0].PatentRepresentationSheetDetails[0].ViewFileFormat);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentRepresentationSheetDetails[0].ViewIdentifier, (c) => c[0].PatentRepresentationSheetDetails[0].ViewIdentifier);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].PatentRepresentationSheetDetails[0].ViewTitle, (c) => c[0].PatentRepresentationSheetDetails[0].ViewTitle);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentRepresentationSheetDetails[0].ViewTitle.languageCode, (c) => c[0].PatentRepresentationSheetDetails[0].ViewTitle.languageCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentRepresentationSheetDetails[0].ViewTitle.sequenceNumber, (c) => c[0].PatentRepresentationSheetDetails[0].ViewTitle.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentRepresentationSheetDetails[0].ViewTitle.Value, (c) => c[0].PatentRepresentationSheetDetails[0].ViewTitle.Value);
//            mapper.AddCollectionMap<PvPatentsServiceReference.PatentType[]>((o) => o.PatentDetails[0].PriorityDetails, (c) => c[0].PriorityDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].PatentTitle, (c) => c[0].PatentTitle);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentTitle.languageCode, (c) => c[0].PatentTitle.languageCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentTitle.sequenceNumber, (c) => c[0].PatentTitle.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PatentTitle.Value, (c) => c[0].PatentTitle.Value);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PriorityDetails[0].PriorityCountryCode, (c) => c[0].PriorityDetails[0].PriorityCountryCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PriorityDetails[0].PriorityDate, (c) => c[0].PriorityDetails[0].PriorityDate);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PriorityDetails[0].PriorityNumber, (c) => c[0].PriorityDetails[0].PriorityNumber);
//            mapper.AddCollectionMap<PvPatentsServiceReference.PatentType[]>((o) => o.PatentDetails[0].PublicationDetails, (c) => c[0].PublicationDetails);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PublicationDetails[0].PublicationDate, (c) => c[0].PublicationDetails[0].PublicationDate);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PublicationDetails[0].PublicationIdentifier, (c) => c[0].PublicationDetails[0].PublicationIdentifier);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PublicationDetails[0].PublicationSection, (c) => c[0].PublicationDetails[0].PublicationSection);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].PublicationDetails[0].PublicationSubsection, (c) => c[0].PublicationDetails[0].PublicationSubsection);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RegistrationDate, (c) => c[0].RegistrationDate);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RegistrationNumber, (c) => c[0].RegistrationNumber);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails, (c) => c[0].RepresentativeDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative, (c) => c[0].RepresentativeDetails.Representative);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddObjectMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvPatentsServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeIdentifier, (c) => c[0].RepresentativeDetails.Representative.RepresentativeIdentifier);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeLegalEntity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeLegalEntity);
//            mapper.AddPropertyMap((o) => o.PatentDetails[0].RepresentativeDetails.Representative.RepresentativeNationalityCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeNationalityCode);

//            return mapper;
//        }

//        public CommonSignedResponse<getPatentsByNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Name(getPatentsByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvPatentsServiceReference.BPOPatentsSearchClient serviceClient = new PvPatentsServiceReference.BPOPatentsSearchClient("BPOPatentsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvPatentsServiceReference.getPatentsByNameType arg = new PvPatentsServiceReference.getPatentsByNameType();
//                arg.patentname = argument.PatentName;
//                PvPatentsServiceReference.PatentType[] serviceResult = serviceClient.getPatentsByName(arg);

//                ObjectMapper<PvPatentsServiceReference.PatentType[], REG_UM_PATENT_PatentDetails_Response> mapper = CreateMapper(accessMatrix);
//                REG_UM_PATENT_PatentDetails_Response searchResults = new REG_UM_PATENT_PatentDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<getPatentByOwnersNameType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Patent_Owner(getPatentByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvPatentsServiceReference.BPOPatentsSearchClient serviceClient = new PvPatentsServiceReference.BPOPatentsSearchClient("BPOPatentsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvPatentsServiceReference.getPatentByOwnersNameType arg = new PvPatentsServiceReference.getPatentByOwnersNameType();
//                arg.fname = argument.FirstName;
//                arg.lname = argument.LastName;
//                arg.sname = argument.Surname;
//                PvPatentsServiceReference.PatentType[] serviceResult = serviceClient.getPatentByOwnersName(arg);

//                ObjectMapper<PvPatentsServiceReference.PatentType[], REG_UM_PATENT_PatentDetails_Response> mapper = CreateMapper(accessMatrix);
//                REG_UM_PATENT_PatentDetails_Response searchResults = new REG_UM_PATENT_PatentDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<getPatentByRegNumType, REG_UM_PATENT_PatentDetails_Response> GetREG_PATENT_Reg_Number(getPatentByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvPatentsServiceReference.BPOPatentsSearchClient serviceClient = new PvPatentsServiceReference.BPOPatentsSearchClient("BPOPatentsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvPatentsServiceReference.getPatentByRegNumType arg = new PvPatentsServiceReference.getPatentByRegNumType();
//                arg.regnum = argument.RegNum;
//                PvPatentsServiceReference.PatentType[] serviceResult = serviceClient.getPatentByRegNum(arg);

//                ObjectMapper<PvPatentsServiceReference.PatentType[], REG_UM_PATENT_PatentDetails_Response> mapper = CreateMapper(accessMatrix);
//                REG_UM_PATENT_PatentDetails_Response searchResults = new REG_UM_PATENT_PatentDetails_Response();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        searchResults,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }
//    }
//}
