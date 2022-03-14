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

//namespace TechnoLogica.RegiX.PvDesignAdapter.AdapterService
//{
//    public class PvDesignAdapter : SoapServiceBaseAdapterService, IPvDesignAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(PvDesignAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//            new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/PvDesign/PvDesignService.svc")
//                    //new ParameterInfo<string>("http://93.152.159.78:6668/bpo.register.ws.provider/services/BPODesignsSearchServiceDefaultPort")
//                    {
//                        Key = Constants.WebServiceUrlParameterKeyName,
//                        Description = "Web Service Url",
//                        OwnerAssembly = typeof(PvDesignAdapter).Assembly
//                    };

//        public CommonSignedResponse<GetDesignByAppNumType, DesignDetailsType> GetREG_DESIGN_App_Number(GetDesignByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PVDesignServiceReference.getDesignByAppNumType arg = new PVDesignServiceReference.getDesignByAppNumType();
//                arg.appnum = argument.AppNum;
//                PVDesignServiceReference.BPODesignsSearchClient serviceClient = new PVDesignServiceReference.BPODesignsSearchClient("BPODesignsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PVDesignServiceReference.DesignType[] serviceResult = serviceClient.getDesignByAppNum(arg);
//                ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType> mapper = CreateMapper(accessMatrix);
//                DesignDetailsType searchResults = new DesignDetailsType();
//                mapper.Map(serviceResult, searchResults);
//                return
//                    SigningUtils.CreateAndSign(
//                    argument,
//                    searchResults,
//                    accessMatrix,
//                    additionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        private static ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType> CreateMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType> mapper = new ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType>(accessMatrix);

//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design, c => c);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails, (c) => c[0].ApplicantDetails);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant, (c) => c[0].ApplicantDetails.Applicant);
//            mapper.AddFunctionMap<PVDesignServiceReference.DesignType[], List<string>>((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantIdentifier, (c) => (c[0].ApplicantDetails.Applicant.ApplicantIdentifier == null) ? null : c[0].ApplicantDetails.Applicant.ApplicantIdentifier.ToList());
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantNationalityCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantNationalityCode);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails);
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());

//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.Item, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.Item.AddressCity, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.Item.AddressCounty, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.Item.AddressPostcode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.Item.AddressState, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.Item.AddressStreet, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.Item.FormattedAddressCountryCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.Item, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.Item.FirstName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.Item.LastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.Item.MiddleName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.Item.NamePrefix, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.Item.OrganizationName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.Item.SecondLastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);

//            mapper.AddPropertyMap((o) => o.Design[0].ApplicationDate, (c) => c[0].ApplicationDate);
//            mapper.AddPropertyMap((o) => o.Design[0].ApplicationNumber, (c) => c[0].ApplicationNumber);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignCurrentStatusCode, (c) => c[0].DesignCurrentStatusCode);

//            mapper.AddPropertyMap((o) => o.Design[0].DesignCurrentStatusDate, (c) => c[0].DesignCurrentStatusDate);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignCurrentStatusDateSpecified, (c) => c[0].DesignCurrentStatusDateSpecified);
//            mapper.AddObjectMap((o) => o.Design[0].DesignDescription, (c) => c[0].DesignDescription);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignDescription.languageCode, (c) => c[0].DesignDescription.languageCode);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignDescription.sequenceNumber, (c) => c[0].DesignDescription.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignDescription.Value, (c) => c[0].DesignDescription.Value);

//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design[0].DesignerDetails, (c) => c[0].DesignerDetails);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerLegalEntity, (c) => c[0].DesignerDetails[0].DesignerLegalEntity);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerNationalityCode, (c) => c[0].DesignerDetails[0].DesignerNationalityCode);
//            mapper.AddObjectMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook, (c) => c[0].DesignerDetails[0].DesignerAddressBook);
//            mapper.AddObjectMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.ContactInformationDetails, (c) => c[0].DesignerDetails[0].DesignerAddressBook.ContactInformationDetails);
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());
//            mapper.AddObjectMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.Item, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.Item.AddressCity, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.Item.AddressCounty, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.Item.AddressPostcode, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.Item.AddressState, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.Item.AddressStreet, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.Item.FormattedAddressCountryCode, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddObjectMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.Item, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.Item.FirstName, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.Item.LastName, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.Item.MiddleName, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.Item.NamePrefix, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.Item.OrganizationName, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.Item.SecondLastName, (c) => c[0].DesignerDetails[0].DesignerAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignKind, (c) => c[0].DesignKind);
//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design[0].DesignRepresentationSheetDetails, (c) => c[0].DesignRepresentationSheetDetails);
//            mapper.AddFunctionMap<PVDesignServiceReference.DesignType[], byte[]>((o) => o.Design[0].DesignRepresentationSheetDetails[0].ViewBinary, (c) => c[0].DesignRepresentationSheetDetails[0].ViewBinary);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignRepresentationSheetDetails[0].ViewFileFormat, (c) => c[0].DesignRepresentationSheetDetails[0].ViewFileFormat);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignRepresentationSheetDetails[0].ViewIdentifier, (c) => c[0].DesignRepresentationSheetDetails[0].ViewIdentifier);
//            mapper.AddObjectMap((o) => o.Design[0].DesignRepresentationSheetDetails[0].ViewTitle, (c) => c[0].DesignRepresentationSheetDetails[0].ViewTitle);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignRepresentationSheetDetails[0].ViewTitle.languageCode, (c) => c[0].DesignRepresentationSheetDetails[0].ViewTitle.languageCode);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignRepresentationSheetDetails[0].ViewTitle.sequenceNumber, (c) => c[0].DesignRepresentationSheetDetails[0].ViewTitle.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignRepresentationSheetDetails[0].ViewTitle.Value, (c) => c[0].DesignRepresentationSheetDetails[0].ViewTitle.Value);
//            mapper.AddObjectMap((o) => o.Design[0].DesignTitle, (c) => c[0].DesignTitle);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignTitle.languageCode, (c) => c[0].DesignTitle.languageCode);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignTitle.sequenceNumber, (c) => c[0].DesignTitle.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.Design[0].DesignTitle.Value, (c) => c[0].DesignTitle.Value);
//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design[0].ExhibitionPriorityDetails, (c) => c[0].ExhibitionPriorityDetails);
//            mapper.AddObjectMap((o) => o.Design[0].ExhibitionPriorityDetails[0].Comment, (c) => c[0].ExhibitionPriorityDetails[0].Comment);
//            mapper.AddPropertyMap((o) => o.Design[0].ExhibitionPriorityDetails[0].Comment.languageCode, (c) => c[0].ExhibitionPriorityDetails[0].Comment.languageCode);
//            mapper.AddPropertyMap((o) => o.Design[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber, (c) => c[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.Design[0].ExhibitionPriorityDetails[0].Comment.Value, (c) => c[0].ExhibitionPriorityDetails[0].Comment.Value);
//            mapper.AddPropertyMap((o) => o.Design[0].ExhibitionPriorityDetails[0].ExhibitionCityName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCityName);
//            mapper.AddPropertyMap((o) => o.Design[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode);
//            mapper.AddPropertyMap((o) => o.Design[0].ExhibitionPriorityDetails[0].ExhibitionDate, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionDate);
//            mapper.AddPropertyMap((o) => o.Design[0].ExhibitionPriorityDetails[0].ExhibitionName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionName);
//            mapper.AddPropertyMap((o) => o.Design[0].ExpiryDate, (c) => c[0].ExpiryDate);
//            mapper.AddPropertyMap((o) => o.Design[0].ExpiryDateSpecified, (c) => c[0].ExpiryDateSpecified);
//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design[0].IndicationProductDetails, (c) => c[0].IndicationProductDetails);
//            mapper.AddPropertyMap((o) => o.Design[0].IndicationProductDetails[0].ClassNumber, (c) => c[0].IndicationProductDetails[0].ClassNumber);
//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design[0].IndicationProductDetails[0].ProductDescription, (c) => c[0].IndicationProductDetails[0].ProductDescription);
//            mapper.AddPropertyMap((o) => o.Design[0].IndicationProductDetails[0].ProductDescription[0].languageCode, (c) => c[0].IndicationProductDetails[0].ProductDescription[0].languageCode);
//            mapper.AddPropertyMap((o) => o.Design[0].IndicationProductDetails[0].ProductDescription[0].sequenceNumber, (c) => c[0].IndicationProductDetails[0].ProductDescription[0].sequenceNumber);
//            mapper.AddPropertyMap((o) => o.Design[0].IndicationProductDetails[0].ProductDescription[0].Value, (c) => c[0].IndicationProductDetails[0].ProductDescription[0].Value);
//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design[0].PriorityDetails, (c) => c[0].PriorityDetails);
//            mapper.AddPropertyMap((o) => o.Design[0].PriorityDetails[0].PriorityCountryCode, (c) => c[0].PriorityDetails[0].PriorityCountryCode);
//            mapper.AddPropertyMap((o) => o.Design[0].PriorityDetails[0].PriorityDate, (c) => c[0].PriorityDetails[0].PriorityDate);
//            mapper.AddPropertyMap((o) => o.Design[0].PriorityDetails[0].PriorityDateSpecified, (c) => c[0].PriorityDetails[0].PriorityDateSpecified);
//            mapper.AddPropertyMap((o) => o.Design[0].PriorityDetails[0].PriorityNumber, (c) => c[0].PriorityDetails[0].PriorityNumber);
//            mapper.AddCollectionMap<PVDesignServiceReference.DesignType[]>((o) => o.Design[0].PublicationDetails, (c) => c[0].PublicationDetails);
//            mapper.AddPropertyMap((o) => o.Design[0].PublicationDetails[0].PublicationDate, (c) => c[0].PublicationDetails[0].PublicationDate);
//            mapper.AddPropertyMap((o) => o.Design[0].PublicationDetails[0].PublicationDateSpecified, (c) => c[0].PublicationDetails[0].PublicationDateSpecified);
//            mapper.AddPropertyMap((o) => o.Design[0].PublicationDetails[0].PublicationIdentifier, (c) => c[0].PublicationDetails[0].PublicationIdentifier);
//            mapper.AddPropertyMap((o) => o.Design[0].PublicationDetails[0].PublicationSection, (c) => c[0].PublicationDetails[0].PublicationSection);
//            mapper.AddPropertyMap((o) => o.Design[0].PublicationDetails[0].PublicationSubsection, (c) => c[0].PublicationDetails[0].PublicationSubsection);
//            mapper.AddPropertyMap((o) => o.Design[0].RegistrationDate, (c) => c[0].RegistrationDate);
//            mapper.AddPropertyMap((o) => o.Design[0].ExpiryDateSpecified, (c) => c[0].ExpiryDateSpecified);
//            mapper.AddPropertyMap((o) => o.Design[0].RegistrationNumber, (c) => c[0].RegistrationNumber);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails, (c) => c[0].RepresentativeDetails);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative, (c) => c[0].RepresentativeDetails.Representative);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails);
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PVDesignServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());

//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.Item, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.Item.AddressCity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.Item.AddressCounty, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.Item.AddressPostcode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.Item.AddressState, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.Item.AddressStreet, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.Item.FormattedAddressCountryCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.Item, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.Item.FirstName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.Item.LastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.Item.MiddleName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.Item.NamePrefix, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.Item.OrganizationName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.Item.SecondLastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeIdentifier, (c) => c[0].RepresentativeDetails.Representative.RepresentativeIdentifier);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeLegalEntity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeLegalEntity);
//            mapper.AddPropertyMap((o) => o.Design[0].RepresentativeDetails.Representative.RepresentativeNationalityCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeNationalityCode);


//            return mapper;
//        }

//        public CommonSignedResponse<GetDesignsByNameType, DesignDetailsType> GetREG_DESIGN_Name(GetDesignsByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PVDesignServiceReference.getDesignsByNameType arg = new PVDesignServiceReference.getDesignsByNameType();
//                arg.dsname = argument.DSName;
//                PVDesignServiceReference.BPODesignsSearchClient serviceClient = new PVDesignServiceReference.BPODesignsSearchClient("BPODesignsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PVDesignServiceReference.DesignType[] serviceResult = serviceClient.getDesignsByName(arg);
//                ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType> mapper = CreateMapper(accessMatrix);
//                DesignDetailsType searchResults = new DesignDetailsType();
//                mapper.Map(serviceResult, searchResults);
//                return SigningUtils.CreateAndSign(
//                    argument,
//                    searchResults,
//                    accessMatrix,
//                    additionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<GetDesignByOwnersNameType, DesignDetailsType> GetREG_DESIGN_Owner_Name(GetDesignByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PVDesignServiceReference.getDesignByOwnersNameType arg = new PVDesignServiceReference.getDesignByOwnersNameType();
//                arg.fname = argument.FName;
//                arg.sname = argument.SName;
//                arg.lname = argument.LName;
//                PVDesignServiceReference.BPODesignsSearchClient serviceClient = new PVDesignServiceReference.BPODesignsSearchClient("BPODesignsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PVDesignServiceReference.DesignType[] serviceResult = serviceClient.getDesignByOwnersName(arg);
//                ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType> mapper = CreateMapper(accessMatrix);
//                DesignDetailsType searchResults = new DesignDetailsType();
//                mapper.Map(serviceResult, searchResults);
//                return SigningUtils.CreateAndSign(
//                    argument,
//                    searchResults,
//                    accessMatrix,
//                    additionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<GetDesignByRegNumType, DesignDetailsType> GetREG_DESIGN_Reg_Number(GetDesignByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PVDesignServiceReference.getDesignByRegNumType arg = new PVDesignServiceReference.getDesignByRegNumType();
//                arg.regnum = argument.RegNum.ToString();
//                PVDesignServiceReference.BPODesignsSearchClient serviceClient = new PVDesignServiceReference.BPODesignsSearchClient("BPODesignsSearchServiceDefaultPort", WebServiceUrl.Value);
//                PVDesignServiceReference.DesignType[] serviceResult = serviceClient.getDesignByRegNum(arg);
//                ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType> mapper = CreateMapper(accessMatrix);
//                DesignDetailsType searchResults = new DesignDetailsType();
//                mapper.Map(serviceResult, searchResults);
//                return SigningUtils.CreateAndSign(
//                    argument,
//                    searchResults,
//                    accessMatrix,
//                    additionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        //TODO:
//        //public DesignDetailsType GetREG_DESIGN_Stat_App_Name(REG_DESIGN_Stat_App_Name_RequestType argument, AccessMatrix accessMatrix)
//        //{
//        //    PVDesignServiceReference.BPODesignsSearchClient serviceClient = new PVDesignServiceReference.BPODesignsSearchClient("BPODesignsSearchServiceDefaultPort", ServiceUrl.Value);
//        //    PVDesignServiceReference.DesignType[] serviceResult = serviceClient.getRegDesignStatAppName(argument.regnum);
//        //    ObjectMapper<PVDesignServiceReference.DesignType[], DesignDetailsType> mapper = CreateRegDesignStatAppNameMapper(accessMatrix);
//        //    DesignDetailsType searchResults = new DesignDetailsType();
//        //    mapper.Map(serviceResult, searchResults);
//        //    return searchResults;
//        //}
//    }
//}
