using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.WebServiceAdapterService;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PvUmAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(PvUmAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(PvUmAdapter), typeof(IAdapterService))]
    public class PvUmAdapter : SoapServiceBaseAdapterService, IPvUmAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(PvUmAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            //new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/PvUm/PvUmService.svc")
           new ParameterInfo<string>("https://testportal.bpo.bg/bpo.register.ws.provider/services/BPOUMsSearchServiceDefaultPort")
           {
               Key = Constants.WebServiceUrlParameterKeyName,
               Description = "Web Service Url",
               OwnerAssembly = typeof(PvUmAdapter).Assembly
           };

        private static ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType> CreateMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType> mapper = new ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType>(accessMatrix);

            mapper.AddCollectionMap<PvUmServiceReference.PatentType[]>((o) => o.Patent, c => c);

            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails, c => c[0].ApplicantDetails);
            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant, c => c[0].ApplicantDetails.Applicant);
            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook, c => c[0].ApplicantDetails.Applicant.ApplicantAddressBook);
            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails, c => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails);

            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Email, c => (c.Email == null) ? null : c.Email.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Fax, c => (c.Fax == null) ? null : c.Fax.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.OtherElectronicAddress, c => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Phone, c => (c.Phone == null) ? null : c.Phone.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.URL, c => (c.URL == null) ? null : c.URL.ToList());

            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress, c => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress);
            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address, c => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address);
            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress, c => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress);

            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);

            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name, c => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name);
            mapper.AddObjectMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName, c => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName);

            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);

            mapper.AddFunctionMap<PvUmServiceReference.PatentType[], List<string>>((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantIdentifier, c => (c[0].ApplicantDetails.Applicant.ApplicantIdentifier != null) ? c[0].ApplicantDetails.Applicant.ApplicantIdentifier.ToList() : null);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicantDetails.Applicant.ApplicantNationalityCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantNationalityCode);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicationDate, (c) => c[0].ApplicationDate);
            mapper.AddPropertyMap((o) => o.Patent[0].ApplicationNumber, (c) => c[0].ApplicationNumber);

            mapper.AddCollectionMap<PvUmServiceReference.PatentType[]>((o) => o.Patent[0].ExhibitionPriorityDetails, c => c[0].ExhibitionPriorityDetails);
            mapper.AddObjectMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].Comment, c => c[0].ExhibitionPriorityDetails[0].Comment);
            mapper.AddPropertyMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].Comment.languageCode, (c) => c[0].ExhibitionPriorityDetails[0].Comment.languageCode);
            mapper.AddPropertyMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber, (c) => c[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber);
            mapper.AddPropertyMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].Comment.Value, (c) => c[0].ExhibitionPriorityDetails[0].Comment.Value);
            mapper.AddPropertyMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].ExhibitionCityName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCityName);
            mapper.AddPropertyMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode);
            mapper.AddPropertyMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].ExhibitionDate, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionDate);
            mapper.AddPropertyMap((o) => o.Patent[0].ExhibitionPriorityDetails[0].ExhibitionName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionName);
            mapper.AddPropertyMap((o) => o.Patent[0].ExpiryDate, (c) => c[0].ExpiryDate);
            mapper.AddPropertyMap((o) => o.Patent[0].ExpiryDateSpecified, (c) => c[0].ExpiryDateSpecified);

            mapper.AddCollectionMap<PvUmServiceReference.PatentType[]>((o) => o.Patent[0].InventorDetails, c => c[0].InventorDetails);
            mapper.AddObjectMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook, c => c[0].InventorDetails[0].InventorAddressBook);
            mapper.AddObjectMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails, c => c[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails);
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Email, c => (c.Email == null) ? null : c.Email.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Fax, c => (c.Fax == null) ? null : c.Fax.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.OtherElectronicAddress, c => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Phone, c => (c.Phone == null) ? null : c.Phone.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.URL, c => (c.URL == null) ? null : c.URL.ToList());

            mapper.AddObjectMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress);
            mapper.AddObjectMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address);
            mapper.AddObjectMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);

            mapper.AddObjectMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name);
            mapper.AddObjectMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorLegalEntity, (c) => c[0].InventorDetails[0].InventorLegalEntity);
            mapper.AddPropertyMap((o) => o.Patent[0].InventorDetails[0].InventorNationalityCode, (c) => c[0].InventorDetails[0].InventorNationalityCode);

            mapper.AddObjectMap((o) => o.Patent[0].IPCClassDetails, c => c[0].IPCClassDetails);
            mapper.AddFunctionMap<PvUmServiceReference.PatentType[], List<string>>((o) => o.Patent[0].IPCClassDetails.IPCClass, c => (c[0].IPCClassDetails.IPCClass == null) ? null : c[0].IPCClassDetails.IPCClass.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.PatentType[], List<string>>((o) => o.Patent[0].IPCClassDetails.IPCName, c => (c[0].IPCClassDetails.IPCName == null) ? null : c[0].IPCClassDetails.IPCName.ToList());
         //   mapper.AddFunctionMap<PvUmServiceReference.PatentType[], PatentCurrentStatusCodeType>((o) => o.Patent[0].PatentCurrentStatusCode, (c) => (PatentCurrentStatusCodeType)Enum.Parse(typeof(PatentCurrentStatusCodeType), c[0].PatentCurrentStatusCode));
            mapper.AddPropertyMap((o) => o.Patent[0].PatentCurrentStatusDate, c => c[0].PatentCurrentStatusDate);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentCurrentStatusDateSpecified, c => c[0].PatentCurrentStatusDateSpecified);

            mapper.AddObjectMap((o) => o.Patent[0].PatentDescription, c => c[0].PatentDescription);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentDescription.languageCode, (c) => c[0].PatentDescription.languageCode);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentDescription.sequenceNumber, (c) => c[0].PatentDescription.sequenceNumber);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentDescription.Value, (c) => c[0].PatentDescription.Value);
           // mapper.AddFunctionMap<PvUmServiceReference.PatentType[], PatentKindType>((o) => o.Patent[0].PatentKind, (c) => (PatentKindType)Enum.Parse(typeof(PatentKindType), c[0].PatentKind));

            mapper.AddCollectionMap<PvUmServiceReference.PatentType[]>((o) => o.Patent[0].PatentRepresentationSheetDetails, c => c[0].PatentRepresentationSheetDetails);
            mapper.AddFunctionMap<PvUmServiceReference.PatentType[], byte[]>((o) => o.Patent[0].PatentRepresentationSheetDetails[0].ViewBinary, c => c[0].PatentRepresentationSheetDetails[0].ViewBinary);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentRepresentationSheetDetails[0].ViewFileFormat, (c) => c[0].PatentRepresentationSheetDetails[0].ViewFileFormat);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentRepresentationSheetDetails[0].ViewIdentifier, (c) => c[0].PatentRepresentationSheetDetails[0].ViewIdentifier);
            mapper.AddObjectMap((o) => o.Patent[0].PatentRepresentationSheetDetails[0].ViewTitle, c => c[0].PatentRepresentationSheetDetails[0].ViewTitle);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentRepresentationSheetDetails[0].ViewTitle.languageCode, (c) => c[0].PatentRepresentationSheetDetails[0].ViewTitle.languageCode);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentRepresentationSheetDetails[0].ViewTitle.sequenceNumber, (c) => c[0].PatentRepresentationSheetDetails[0].ViewTitle.sequenceNumber);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentRepresentationSheetDetails[0].ViewTitle.Value, (c) => c[0].PatentRepresentationSheetDetails[0].ViewTitle.Value);

            mapper.AddObjectMap((o) => o.Patent[0].PatentTitle, c => c[0].PatentTitle);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentTitle.languageCode, (c) => c[0].PatentTitle.languageCode);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentTitle.sequenceNumber, (c) => c[0].PatentTitle.sequenceNumber);
            mapper.AddPropertyMap((o) => o.Patent[0].PatentTitle.Value, (c) => c[0].PatentTitle.Value);

            mapper.AddCollectionMap<PvUmServiceReference.PatentType[]>((o) => o.Patent[0].PriorityDetails, c => c[0].PriorityDetails);
            mapper.AddPropertyMap((o) => o.Patent[0].PriorityDetails[0].PriorityCountryCode, (c) => c[0].PriorityDetails[0].PriorityCountryCode);
            mapper.AddPropertyMap((o) => o.Patent[0].PriorityDetails[0].PriorityDate, (c) => c[0].PriorityDetails[0].PriorityDate);
            mapper.AddPropertyMap((o) => o.Patent[0].PriorityDetails[0].PriorityNumber, (c) => c[0].PriorityDetails[0].PriorityNumber);
            mapper.AddPropertyMap((o) => o.Patent[0].PriorityDetails[0].PriorityDateSpecified, c => c[0].PriorityDetails[0].PriorityDateSpecified);

            mapper.AddCollectionMap<PvUmServiceReference.PatentType[]>((o) => o.Patent[0].PublicationDetails, c => c[0].PublicationDetails);
            mapper.AddPropertyMap((o) => o.Patent[0].PublicationDetails[0].PublicationDate, (c) => c[0].PublicationDetails[0].PublicationDate);
            mapper.AddPropertyMap((o) => o.Patent[0].PublicationDetails[0].PublicationIdentifier, (c) => c[0].PublicationDetails[0].PublicationIdentifier);
            mapper.AddPropertyMap((o) => o.Patent[0].PublicationDetails[0].PublicationSection, (c) => c[0].PublicationDetails[0].PublicationSection);
            mapper.AddPropertyMap((o) => o.Patent[0].PublicationDetails[0].PublicationSubsection, (c) => c[0].PublicationDetails[0].PublicationSubsection);
            mapper.AddPropertyMap((o) => o.Patent[0].PublicationDetails[0].PublicationDateSpecified, (c) => c[0].PublicationDetails[0].PublicationDateSpecified);

            mapper.AddPropertyMap((o) => o.Patent[0].RegistrationDate, (c) => c[0].RegistrationDate);
            mapper.AddPropertyMap((o) => o.Patent[0].RegistrationDateSpecified, c => c[0].RegistrationDateSpecified);
            mapper.AddPropertyMap((o) => o.Patent[0].RegistrationNumber, (c) => c[0].RegistrationNumber);

            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails, c => c[0].RepresentativeDetails);
            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative, c => c[0].RepresentativeDetails.Representative);
            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook, c => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook);
            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails, c => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails);
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Email, c => (c.Email == null) ? null : c.Email.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Fax, c => (c.Fax == null) ? null : c.Fax.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.OtherElectronicAddress, c => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Phone, c => (c.Phone == null) ? null : c.Phone.ToList());
            mapper.AddFunctionMap<PvUmServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.URL, c => (c.URL == null) ? null : c.URL.ToList());

            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress, c => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress);
            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address, c => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address);
            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress, c => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);

            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name, c => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name);
            mapper.AddObjectMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName, c => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);

            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeIdentifier, (c) => c[0].RepresentativeDetails.Representative.RepresentativeIdentifier);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeLegalEntity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeLegalEntity);
            mapper.AddPropertyMap((o) => o.Patent[0].RepresentativeDetails.Representative.RepresentativeNationalityCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeNationalityCode);

            return mapper;
        }

        public CommonSignedResponse<getUtilityModelByAppNumType, PatentDetailsType> GetREG_UM_App_Number(getUtilityModelByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvUmServiceReference.BPOUMsSearchClient serviceClient = new PvUmServiceReference.BPOUMsSearchClient("BPOUMsSearchServiceDefaultPort", WebServiceUrl.Value);
                PvUmServiceReference.getUtilityModelByAppNumType arg = new PvUmServiceReference.getUtilityModelByAppNumType();
                arg.appnum = argument.AppNum;
                PvUmServiceReference.PatentType[] serviceResult = serviceClient.getUMByAppNum(arg);

                ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType> mapper = CreateMapper(accessMatrix);
                PatentDetailsType searchResults = new PatentDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                    SigningUtils.CreateAndSign(
                        argument,
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

        public CommonSignedResponse<getUtilityModelByNameType, PatentDetailsType> GetREG_UM_Name(getUtilityModelByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvUmServiceReference.BPOUMsSearchClient serviceClient = new PvUmServiceReference.BPOUMsSearchClient("BPOUMsSearchServiceDefaultPort", WebServiceUrl.Value);
                PvUmServiceReference.getUtilityModelByNameType arg = new PvUmServiceReference.getUtilityModelByNameType();
                arg.umodelname = argument.UmodelName;
                PvUmServiceReference.PatentType[] serviceResult = serviceClient.getUMsByName(arg);

                ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType> mapper = CreateMapper(accessMatrix);
                PatentDetailsType searchResults = new PatentDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                    SigningUtils.CreateAndSign(
                        argument,
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

        public CommonSignedResponse<getUtilityModelByOwnersNameType, PatentDetailsType> GetREG_UM_Owner_Name(getUtilityModelByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvUmServiceReference.BPOUMsSearchClient serviceClient = new PvUmServiceReference.BPOUMsSearchClient("BPOUMsSearchServiceDefaultPort", WebServiceUrl.Value);
                PvUmServiceReference.getUtilityModelByOwnersNameType arg = new PvUmServiceReference.getUtilityModelByOwnersNameType();
                arg.fname = argument.FirstName;
                arg.lname = argument.LastName;
                arg.sname = argument.Surname;
                PvUmServiceReference.PatentType[] serviceResult = serviceClient.getUMByOwnersName(arg);

                ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType> mapper = CreateMapper(accessMatrix);
                PatentDetailsType searchResults = new PatentDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                    SigningUtils.CreateAndSign(
                        argument,
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

        public CommonSignedResponse<getUtilityModelByRegNumType, PatentDetailsType> GetREG_UM_Reg_Number(getUtilityModelByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvUmServiceReference.BPOUMsSearchClient serviceClient = new PvUmServiceReference.BPOUMsSearchClient("BPOUMsSearchServiceDefaultPort", WebServiceUrl.Value);
                PvUmServiceReference.getUtilityModelByRegNumType arg = new PvUmServiceReference.getUtilityModelByRegNumType();
                arg.regnum = argument.RegNum;
                PvUmServiceReference.PatentType[] serviceResult = serviceClient.getUMByRegNum(arg);

                ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType> mapper = CreateMapper(accessMatrix);
                PatentDetailsType searchResults = new PatentDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                    SigningUtils.CreateAndSign(
                        argument,
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

        //TODO: in service reference there isn't method getUMByRegNum
        //public PatentDetailsType GetREG_UM_Stat_App_Date(getUtilityModelByRegNumType argument, AccessMatrix accessMatrix)
        //{
        //    PvUmServiceReference.BPOUMsSearchClient serviceClient = new PvUmServiceReference.BPOUMsSearchClient("BPOUMsSearchServiceDefaultPort", ServiceUrl.Value);
        //    PvUmServiceReference.PatentType[] serviceResult = serviceClient.getUMByRegNum(argument);
        //
        //    ObjectMapper<PvUmServiceReference.PatentType[], PatentDetailsType> mapper = CreateRegUmStatAppDateMapper(accessMatrix);
        //    PatentDetailsType searchResults = new PatentDetailsType();
        //    mapper.Map(serviceResult, searchResults);
        //    return searchResults;
        //}

    }
}
