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

namespace TechnoLogica.RegiX.PVGeoAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(PVGeoAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(PVGeoAdapter), typeof(IAdapterService))]
    public class PVGeoAdapter : SoapServiceBaseAdapterService, IPVGeoAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(PVGeoAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WebServiceUrl =
            //new ParameterInfo<string>("http://regix2-adapters.regix.tlogica.com/MockRegisters/PvGeo/PvGeoService.svc")
                 new ParameterInfo<string>("https://testportal.bpo.bg/bpo.register.ws.provider/services/BPOGeoSearchServiceDefaultPort")
                 {
                      Key = Constants.WebServiceUrlParameterKeyName,
                      Description = "Web Service Url",
                     OwnerAssembly = typeof(PVGeoAdapter).Assembly
                 };

        public CommonSignedResponse<GetGIByAppNumType, GIDetailsType> GetREG_GEO_App_Num(GetGIByAppNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvGeoServiceReference.BPOGeoSearchClient serviceClient = new PvGeoServiceReference.BPOGeoSearchClient("BPOGeoSearchServiceDefaultPort", WebServiceUrl.Value);
                PvGeoServiceReference.getGIByAppNumType arg = new PvGeoServiceReference.getGIByAppNumType();
                arg.appnum = argument.AppNum;
                PvGeoServiceReference.GIType[] serviceResult = serviceClient.getGIByAppNum(arg);
                ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType> mapper = CreateMapper(accessMatrix);
                GIDetailsType searchResults = new GIDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                   SigningUtils.CreateAndSign(
                   argument,
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

        private static ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType> CreateMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType> mapper = new ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType>(accessMatrix);

            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI, c => c);

            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails, (c) => c[0].ApplicantDetails);
            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant, (c) => c[0].ApplicantDetails.Applicant);
            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook);
            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails);
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());

            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress);
            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address);
            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);

            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name);
            mapper.AddObjectMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].ApplicantDetails.Applicant.ApplicantAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);

            mapper.AddFunctionMap<PvGeoServiceReference.ApplicantType, List<string>>((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantIdentifier, (c) => (c.ApplicantIdentifier == null) ? null : c.ApplicantIdentifier.ToList());
            mapper.AddPropertyMap((o) => o.GI[0].ApplicantDetails.Applicant.ApplicantNationalityCode, (c) => c[0].ApplicantDetails.Applicant.ApplicantNationalityCode);

            mapper.AddPropertyMap((o) => o.GI[0].ApplicationDate, (c) => c[0].ApplicationDate);
            mapper.AddPropertyMap((o) => o.GI[0].ApplicationNumber, (c) => c[0].ApplicationNumber);
            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI[0].ExhibitionPriorityDetails, c => c[0].ExhibitionPriorityDetails == null ? null : c[0].ExhibitionPriorityDetails.ToList());
            mapper.AddObjectMap((o) => o.GI[0].ExhibitionPriorityDetails[0].Comment, (c) => c[0].ExhibitionPriorityDetails[0].Comment);
            mapper.AddPropertyMap((o) => o.GI[0].ExhibitionPriorityDetails[0].Comment.languageCode, (c) => c[0].ExhibitionPriorityDetails[0].Comment.languageCode);
            mapper.AddPropertyMap((o) => o.GI[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber, (c) => c[0].ExhibitionPriorityDetails[0].Comment.sequenceNumber);
            mapper.AddPropertyMap((o) => o.GI[0].ExhibitionPriorityDetails[0].Comment.Value, (c) => c[0].ExhibitionPriorityDetails[0].Comment.Value);
            mapper.AddPropertyMap((o) => o.GI[0].ExhibitionPriorityDetails[0].ExhibitionCityName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCityName);
            mapper.AddPropertyMap((o) => o.GI[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionCountryCode);
            mapper.AddPropertyMap((o) => o.GI[0].ExhibitionPriorityDetails[0].ExhibitionDate, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionDate);
            mapper.AddPropertyMap((o) => o.GI[0].ExhibitionPriorityDetails[0].ExhibitionName, (c) => c[0].ExhibitionPriorityDetails[0].ExhibitionName);
            mapper.AddFunctionMap<PvGeoServiceReference.GIType[], MarkCurrentStatusCodeType>((o) => o.GI[0].GICurrentStatusCode, c => ((MarkCurrentStatusCodeType)(Enum.Parse(typeof(MarkCurrentStatusCodeType), c[0].GICurrentStatusCode.ToString()))));
            mapper.AddPropertyMap((o) => o.GI[0].GICurrentStatusDate, (c) => c[0].GICurrentStatusDate);
            mapper.AddFunctionMap<PvGeoServiceReference.GIType[], List<string>>((o) => o.GI[0].GIDescriptionDetails, (c) => (c[0].GIDescriptionDetails == null) ? null : c[0].GIDescriptionDetails.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.GIType[], List<string>>((o) => o.GI[0].GIDisclaimerDetails, (c) => (c[0].GIDisclaimerDetails == null) ? null : c[0].GIDisclaimerDetails.ToList());
            mapper.AddObjectMap((o) => o.GI[0].GoodsServicesDetails, (c) => c[0].GoodsServicesDetails);
            mapper.AddObjectMap((o) => o.GI[0].GoodsServicesDetails.GoodsServices, (c) => c[0].GoodsServicesDetails.GoodsServices);
            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails, c => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails);
            mapper.AddPropertyMap((o) => o.GI[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].ClassNumber, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].ClassNumber);
            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription, c => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription);
            mapper.AddPropertyMap((o) => o.GI[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].languageCode, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].languageCode);
            mapper.AddPropertyMap((o) => o.GI[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].sequenceNumber, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].sequenceNumber);
            mapper.AddPropertyMap((o) => o.GI[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].Value, (c) => c[0].GoodsServicesDetails.GoodsServices.ClassDescriptionDetails[0].GoodsServicesDescription[0].Value);

            mapper.AddObjectMap((o) => o.GI[0].MarkImageDetails, (c) => c[0].MarkImageDetails);
            mapper.AddObjectMap((o) => o.GI[0].MarkImageDetails.MarkImage, (c) => c[0].MarkImageDetails.MarkImage);
            mapper.AddPropertyMap((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageBinary, (c) => c[0].MarkImageDetails.MarkImage.MarkImageBinary);
            mapper.AddObjectMap((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageCategory, (c) => c[0].MarkImageDetails.MarkImage.MarkImageCategory);
            mapper.AddPropertyMap((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageCategory.CategoryCodeDetails, (c) => c[0].MarkImageDetails.MarkImage.MarkImageCategory.CategoryCodeDetails == null ? null : c[0].MarkImageDetails.MarkImage.MarkImageCategory.CategoryCodeDetails.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.MarkImageCategoryType, List<string>>((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageCategory.CategoryCodeDetails, (c) => (c.CategoryCodeDetails == null) ? null : c.CategoryCodeDetails.ToList());
            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText, c => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText);
            mapper.AddPropertyMap((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].languageCode, (c) => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].languageCode);
            mapper.AddPropertyMap((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].sequenceNumber, (c) => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].sequenceNumber);
            mapper.AddPropertyMap((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].Value, (c) => c[0].MarkImageDetails.MarkImage.MarkImageColourClaimedText[0].Value);
            mapper.AddPropertyMap((o) => o.GI[0].MarkImageDetails.MarkImage.MarkImageFileFormat, (c) => c[0].MarkImageDetails.MarkImage.MarkImageFileFormat);

            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI[0].PriorityDetails, c => c[0].PriorityDetails);
            mapper.AddPropertyMap((o) => o.GI[0].PriorityDetails[0].PriorityCountryCode, (c) => c[0].PriorityDetails[0].PriorityCountryCode);
            mapper.AddPropertyMap((o) => o.GI[0].PriorityDetails[0].PriorityDate, (c) => c[0].PriorityDetails[0].PriorityDate);
            mapper.AddPropertyMap((o) => o.GI[0].PriorityDetails[0].PriorityNumber, (c) => c[0].PriorityDetails[0].PriorityNumber);
            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI[0].PublicationDetails, c => c[0].PublicationDetails);
            mapper.AddPropertyMap((o) => o.GI[0].PublicationDetails[0].PublicationDate, (c) => c[0].PublicationDetails[0].PublicationDate);
            mapper.AddPropertyMap((o) => o.GI[0].PublicationDetails[0].PublicationIdentifier, (c) => c[0].PublicationDetails[0].PublicationIdentifier);
            mapper.AddPropertyMap((o) => o.GI[0].PublicationDetails[0].PublicationSection, (c) => c[0].PublicationDetails[0].PublicationSection);
            mapper.AddPropertyMap((o) => o.GI[0].PublicationDetails[0].PublicationSubsection, (c) => c[0].PublicationDetails[0].PublicationSubsection);
            mapper.AddPropertyMap((o) => o.GI[0].RegistrationDate, (c) => c[0].RegistrationDate);
            mapper.AddPropertyMap((o) => o.GI[0].RegistrationNumber, (c) => c[0].RegistrationNumber);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails, (c) => c[0].RepresentativeDetails);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative, (c) => c[0].RepresentativeDetails.Representative);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails);
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Email, (c) => (c.Email == null) ? null : c.Email.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Fax, (c) => (c.Fax == null) ? null : c.Fax.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.OtherElectronicAddress, (c) => (c.OtherElectronicAddress == null) ? null : c.OtherElectronicAddress.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.Phone, (c) => (c.Phone == null) ? null : c.Phone.ToList());
            mapper.AddFunctionMap<PvGeoServiceReference.AddressBookTypeContactInformationDetails, List<string>>((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.ContactInformationDetails.URL, (c) => (c.URL == null) ? null : c.URL.ToList());

            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCity);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressCounty);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressPostcode);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressState);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.AddressStreet);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Address.FormattedAddress.FormattedAddressCountryCode);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name);
            mapper.AddObjectMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.FirstName);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.LastName);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.MiddleName);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.NamePrefix);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.OrganizationName);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName, (c) => c[0].RepresentativeDetails.Representative.RepresentativeAddressBook.FormattedNameAddress.Name.FormattedName.SecondLastName);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeIdentifier, (c) => c[0].RepresentativeDetails.Representative.RepresentativeIdentifier);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeLegalEntity, (c) => c[0].RepresentativeDetails.Representative.RepresentativeLegalEntity);
            mapper.AddPropertyMap((o) => o.GI[0].RepresentativeDetails.Representative.RepresentativeNationalityCode, (c) => c[0].RepresentativeDetails.Representative.RepresentativeNationalityCode);
            mapper.AddPropertyMap((o) => o.GI[0].UsageSeqNum, (c) => c[0].UsageSeqNum);
            mapper.AddObjectMap((o) => o.GI[0].WordMarkSpecification, (c) => c[0].WordMarkSpecification);
            mapper.AddCollectionMap<PvGeoServiceReference.GIType[]>((o) => o.GI[0].WordMarkSpecification.MarkTranslation, c => c[0].WordMarkSpecification.MarkTranslation);
            mapper.AddPropertyMap((o) => o.GI[0].WordMarkSpecification.MarkTranslation[0].languageCode, (c) => c[0].WordMarkSpecification.MarkTranslation[0].languageCode);
            mapper.AddPropertyMap((o) => o.GI[0].WordMarkSpecification.MarkTranslation[0].sequenceNumber, (c) => c[0].WordMarkSpecification.MarkTranslation[0].sequenceNumber);
            mapper.AddPropertyMap((o) => o.GI[0].WordMarkSpecification.MarkTranslation[0].Value, (c) => c[0].WordMarkSpecification.MarkTranslation[0].Value);
            mapper.AddObjectMap((o) => o.GI[0].WordMarkSpecification.MarkVerbalElementText, (c) => c[0].WordMarkSpecification.MarkVerbalElementText);
            mapper.AddPropertyMap((o) => o.GI[0].WordMarkSpecification.MarkVerbalElementText.languageCode, (c) => c[0].WordMarkSpecification.MarkVerbalElementText.languageCode);
            mapper.AddPropertyMap((o) => o.GI[0].WordMarkSpecification.MarkVerbalElementText.sequenceNumber, (c) => c[0].WordMarkSpecification.MarkVerbalElementText.sequenceNumber);
            mapper.AddPropertyMap((o) => o.GI[0].WordMarkSpecification.MarkVerbalElementText.Value, (c) => c[0].WordMarkSpecification.MarkVerbalElementText.Value);


            return mapper;
        }

        public CommonSignedResponse<GetGIByNameType, GIDetailsType> GetREG_GEO_GI_Name(GetGIByNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvGeoServiceReference.BPOGeoSearchClient serviceClient = new PvGeoServiceReference.BPOGeoSearchClient("BPOGeoSearchServiceDefaultPort", WebServiceUrl.Value);
                PvGeoServiceReference.getGIByNameType arg = new PvGeoServiceReference.getGIByNameType();
                arg.giname = argument.GIName;
                PvGeoServiceReference.GIType[] serviceResult = serviceClient.getGIByName(arg);
                ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType> mapper = CreateMapper(accessMatrix);
                GIDetailsType searchResults = new GIDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                   SigningUtils.CreateAndSign(
                   argument,
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

        public CommonSignedResponse<GetGIByUserNameType, GIDetailsType> GetREG_GEO_GI_User(GetGIByUserNameType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvGeoServiceReference.BPOGeoSearchClient serviceClient = new PvGeoServiceReference.BPOGeoSearchClient("BPOGeoSearchServiceDefaultPort", WebServiceUrl.Value);
                PvGeoServiceReference.getGIByUserNameType arg = new PvGeoServiceReference.getGIByUserNameType();
                arg.fname = argument.FName;
                arg.lname = argument.LName;
                arg.sname = argument.SName;
                PvGeoServiceReference.GIType[] serviceResult = serviceClient.getGIByUserName(arg);
                ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType> mapper = CreateMapper(accessMatrix);
                GIDetailsType searchResults = new GIDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                    SigningUtils.CreateAndSign(
                    argument,
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

        public CommonSignedResponse<GetGIByRegNumType, GIDetailsType> GetREG_GEO_Reg_Num(GetGIByRegNumType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PvGeoServiceReference.BPOGeoSearchClient serviceClient = new PvGeoServiceReference.BPOGeoSearchClient("BPOGeoSearchServiceDefaultPort", WebServiceUrl.Value);
                PvGeoServiceReference.getGIByRegNumType arg = new PvGeoServiceReference.getGIByRegNumType();
                arg.regnum = argument.RegNum;
                PvGeoServiceReference.GIType[] serviceResult = serviceClient.getGIByRegNum(arg);
                ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType> mapper = CreateMapper(accessMatrix);
                GIDetailsType searchResults = new GIDetailsType();
                mapper.Map(serviceResult, searchResults);
                return
                    SigningUtils.CreateAndSign(
                    argument,
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

        // public GIDetailsType GetREG_GEO_Stat_App_Date(GIDetailsType argument, AccessMatrix accessMatrix)
        // {
        //     PvGeoServiceReference.BPOGeoSearchClient serviceClient = new PvGeoServiceReference.BPOGeoSearchClient("BPOGeoSearchServiceDefaultPort", ServiceUrl.Value);
        //     PvGeoServiceReference.GIDetailsType arg = new PvGeoServiceReference.GIDetailsType();
        //     PvGeoServiceReference.GIType[] serviceResult = serviceClient.GetGIByRegNum(argument);
        //     ObjectMapper<PvGeoServiceReference.GIType[], GIDetailsType> mapper = CreateGeoStatAppDateMapper(accessMatrix);
        //     GIDetailsType searchResults = new GIDetailsType();
        //     // mapper.Map(serviceResult, searchResults);
        //     return searchResults;
        // }
    }
}
