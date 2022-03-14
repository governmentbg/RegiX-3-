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

//namespace TechnoLogica.RegiX.PvSpcAdapter.AdapterService
//{
//    public class PvSpcAdapter : SoapServiceBaseAdapterService, IPvSpcAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(PvSpcAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> WebServiceUrl =
//            //new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/PvSpc/PvSpcService.svc")
//              new ParameterInfo<string>("http://93.152.159.78:6668/bpo.register.ws.provider/services/BPOSPCSearchServiceDefaultPort")
//           {
//               Key = Constants.WebServiceUrlParameterKeyName,
//               Description = "Web Service Url",
//               OwnerAssembly = typeof(PvSpcAdapter).Assembly
//           };
        
//        public CommonSignedResponse<getSPCByPatentAppNumType, SPCDetailsType> GetREG_SPC_App_Number(getSPCByPatentAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvSpcServiceReference.BPOSPCSearchClient serviceClient = new PvSpcServiceReference.BPOSPCSearchClient("BPOSPCSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvSpcServiceReference.getSPCByPatentAppNumType arg = new PvSpcServiceReference.getSPCByPatentAppNumType();
//                arg.pat_appnum = argument.PatAppnum;
//                PvSpcServiceReference.SPCType[] serviceResult = serviceClient.getSPCByAppNum(arg);

//                ObjectMapper<PvSpcServiceReference.SPCType[], SPCDetailsType> mapper = CreateMapper(accessMatrix);
//                SPCDetailsType searchResults = new SPCDetailsType();
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

//        private static ObjectMapper<PvSpcServiceReference.SPCType[], SPCDetailsType> CreateMapper(AccessMatrix accessMatrix)
//        {
//            ObjectMapper<PvSpcServiceReference.SPCType[], SPCDetailsType> mapper = new ObjectMapper<PvSpcServiceReference.SPCType[], SPCDetailsType>(accessMatrix);

//            mapper.AddCollectionMap<PvSpcServiceReference.SPCType[]>((o) => o.SPC, (c) => c);

//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails, (c) => c[0].ApplicantDetails);
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant, (c) => c[0].ApplicantDetails.Applicant);
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook);
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails);

//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
//            mapper.AddFunctionMap<PvSpcServiceReference.SPCType[], List<string>>((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantIdentifier, (c) => (c[0].ApplicantDetails.Applicant.ApplicantIdentifier == null) ? null : c[0].ApplicantDetails.Applicant.ApplicantIdentifier.ToList());
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicantDetails.Applicant.ApplicantNationalityCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantNationalityCode);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicationDate, (c) => c[0].ApplicationDate);
//            mapper.AddPropertyMap((o) => o.SPC[0].ApplicationNumber, (c) => c[0].ApplicationNumber);
//            mapper.AddPropertyMap((o) => o.SPC[0].ExpiryDate, (c) => c[0].ExpiryDate);
//            mapper.AddPropertyMap((o) => o.SPC[0].ExpiryDateSpecified, (c) => c[0].ExpiryDateSpecified);
//            mapper.AddPropertyMap((o) => o.SPC[0].ExpiryDateSpecified, c => c[0].ExpiryDateSpecified);

//            mapper.AddCollectionMap<PvSpcServiceReference.SPCType[]>((o) => o.SPC[0].InventorDetails, c => c[0].InventorDetails);
//            mapper.AddObjectMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook, c => c[0].InventorDetails[0].InventorAddressBook);
//            mapper.AddObjectMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails, c => c[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails);
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Email, c => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Fax, c => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.OtherElectronicAddress, c => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.Phone, c => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.ContactInformationDetails.URL, c => (c.URL == null) ? null : c.URL.ToList());

//            mapper.AddObjectMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);

//            mapper.AddObjectMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName, c => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].InventorDetails[0].InventorAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);

//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorLegalEntity, (c) => c[0].InventorDetails[0].InventorLegalEntity);
//            mapper.AddPropertyMap((o) => o.SPC[0].InventorDetails[0].InventorNationalityCode, (c) => c[0].InventorDetails[0].InventorNationalityCode);

//            mapper.AddObjectMap((o) => o.SPC[0].IPCClassDetails, c => c[0].IPCClassDetails);
//            mapper.AddFunctionMap<PvSpcServiceReference.SPCType[], List<string>>((o) => o.SPC[0].IPCClassDetails.IPCClass, c => (c[0].IPCClassDetails.IPCClass == null) ? null : c[0].IPCClassDetails.IPCClass.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.SPCType[], List<string>>((o) => o.SPC[0].IPCClassDetails.IPCName, c => (c[0].IPCClassDetails.IPCName == null) ? null : c[0].IPCClassDetails.IPCName.ToList());

//            mapper.AddCollectionMap<PvSpcServiceReference.SPCType[]>((o) => o.SPC[0].PublicationDetails, c => c[0].PublicationDetails);
//            mapper.AddPropertyMap((o) => o.SPC[0].PublicationDetails[0].PublicationDate, (c) => c[0].PublicationDetails[0].PublicationDate);
//            mapper.AddPropertyMap((o) => o.SPC[0].PublicationDetails[0].PublicationIdentifier, (c) => c[0].PublicationDetails[0].PublicationIdentifier);
//            mapper.AddPropertyMap((o) => o.SPC[0].PublicationDetails[0].PublicationSection, (c) => c[0].PublicationDetails[0].PublicationSection);
//            mapper.AddPropertyMap((o) => o.SPC[0].PublicationDetails[0].PublicationSubsection, (c) => c[0].PublicationDetails[0].PublicationSubsection);
//            mapper.AddPropertyMap((o) => o.SPC[0].PublicationDetails[0].PublicationDateSpecified, (c) => c[0].PublicationDetails[0].PublicationDateSpecified);

//            mapper.AddPropertyMap((o) => o.SPC[0].RegistrationDate, c => c[0].RegistrationDate);
//            mapper.AddPropertyMap((o) => o.SPC[0].RegistrationDateSpecified, c => c[0].RegistrationDateSpecified);

//            mapper.AddPropertyMap((o) => o.SPC[0].RelPatAppNumber, (c) => c[0].RelPatAppNumber);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails, (c) => c[0].RepresentativeDetails);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative, (c) => c[0].RepresentativeDetails.Representative);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails);
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
//            mapper.AddFunctionMap<PvSpcServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name);
//            mapper.AddObjectMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeIdentifier, (c) => c[0].RepresentativeDetails.Representative.RepresentativeIdentifier);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeLegalEntity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeLegalEntity);
//            mapper.AddPropertyMap((o) => o.SPC[0].RepresentativeDetails.Representative.RepresentativeNationalityCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeNationalityCode);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCCurrentStatusCode, (c) => c[0].SPCCurrentStatusCode);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCCurrentStatusDate, (c) => c[0].SPCCurrentStatusDate);
//            mapper.AddObjectMap((o) => o.SPC[0].SPCDescription, (c) => c[0].SPCDescription);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCDescription.languageCode, (c) => c[0].SPCDescription.languageCode);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCDescription.sequenceNumber, (c) => c[0].SPCDescription.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCDescription.Value, (c) => c[0].SPCDescription.Value);
//            mapper.AddObjectMap((o) => o.SPC[0].SPCTitle, (c) => c[0].SPCTitle);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCTitle.languageCode, (c) => c[0].SPCTitle.languageCode);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCTitle.sequenceNumber, (c) => c[0].SPCTitle.sequenceNumber);
//            mapper.AddPropertyMap((o) => o.SPC[0].SPCTitle.Value, (c) => c[0].SPCTitle.Value);

//            return mapper;
//        }

//        public CommonSignedResponse<getSPCByOwnersNameType, SPCDetailsType> GetREG_SPC_Owner(getSPCByOwnersNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvSpcServiceReference.BPOSPCSearchClient serviceClient = new PvSpcServiceReference.BPOSPCSearchClient("BPOSPCSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvSpcServiceReference.getSPCByOwnersNameType arg = new PvSpcServiceReference.getSPCByOwnersNameType();
//                arg.fname = argument.FirstName;
//                arg.lname = argument.LastName;
//                arg.sname = argument.Surname;
//                PvSpcServiceReference.SPCType[] serviceResult = serviceClient.getSPCByOwnersName(arg);

//                ObjectMapper<PvSpcServiceReference.SPCType[], SPCDetailsType> mapper = CreateMapper(accessMatrix);
//                SPCDetailsType searchResults = new SPCDetailsType();
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

//        public CommonSignedResponse<getSPCByAppNumType, SPCDetailsType> GetREG_SPC_Reg_Number(getSPCByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                PvSpcServiceReference.BPOSPCSearchClient serviceClient = new PvSpcServiceReference.BPOSPCSearchClient("BPOSPCSearchServiceDefaultPort", WebServiceUrl.Value);
//                PvSpcServiceReference.getSPCByRegNumType arg = new PvSpcServiceReference.getSPCByRegNumType();
//                arg.appnum = argument.AppNum;
//                PvSpcServiceReference.SPCType[] serviceResult = serviceClient.getSPCByRegNum(arg);

//                ObjectMapper<PvSpcServiceReference.SPCType[], SPCDetailsType> mapper = CreateMapper(accessMatrix);
//                SPCDetailsType searchResults = new SPCDetailsType();
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

//        //public SPCDetailsType GetREG_SPC_Stat_App_Date(SPCDetailsType argument, AccessMatrix accessMatrix)
//        //{
//        //    PvSpcServiceReference.BPOSPCSearchClient serviceClient = new PvSpcServiceReference.BPOSPCSearchClient("BPOSPCSearchServiceDefaultPort", ServiceUrl.Value);
//        //    PvSpcServiceReference.SPCType[] serviceResult = serviceClient.(argument);

//        //    ObjectMapper<PvSpcServiceReference.SPCType[], SPCDetailsType> mapper = CreateMapper(accessMatrix);
//        //    SPCDetailsType searchResults = new SPCDetailsType();
//        //    mapper.Map(serviceResult, searchResults);
//        //    return searchResults;
//        //}
//    }
//}
