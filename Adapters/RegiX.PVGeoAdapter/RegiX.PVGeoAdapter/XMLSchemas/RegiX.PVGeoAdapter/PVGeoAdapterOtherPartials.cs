using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.PVGeoAdapter
{
    public partial class GIDetailsType
    {
        public bool ShouldSerializeGI()
        {
            //Here removing the empty elements from the array or collection
            if (this.GI != null)
            {
                this.GI = this.GI.Where(x => x != default(GIType)).ToList();
            }

            bool haveSomeValue = this.GI != null &&
                this.GI.Count() != 0 &&
                (
                this.GI[0].ApplicationDate != default(DateTime) ||
                this.GI[0].ApplicationDateSpecified != default(Boolean) ||
                this.GI[0].RegistrationDate != default(DateTime) ||
                this.GI[0].RegistrationDateSpecified != default(Boolean) ||
                this.GI[0].GICurrentStatusCodeSpecified != default(Boolean) ||
                this.GI[0].GICurrentStatusDate != default(DateTime) ||
                this.GI[0].GICurrentStatusDateSpecified != default(Boolean) ||
                this.GI[0].ShouldSerializeApplicationNumber() ||
                this.GI[0].ShouldSerializeRegistrationNumber() ||
                this.GI[0].ShouldSerializeUsageSeqNum() ||
                this.GI[0].ShouldSerializeGIDescriptionDetails() ||
                this.GI[0].ShouldSerializeGIDisclaimerDetails() ||
                this.GI[0].ShouldSerializeWordMarkSpecification() ||
                this.GI[0].ShouldSerializeMarkImageDetails() ||
                this.GI[0].ShouldSerializeGoodsServicesDetails() ||
                this.GI[0].ShouldSerializePriorityDetails() ||
                this.GI[0].ShouldSerializeExhibitionPriorityDetails() ||
                this.GI[0].ShouldSerializePublicationDetails() ||
                this.GI[0].ShouldSerializeApplicantDetails() ||
                this.GI[0].ShouldSerializeRepresentativeDetails()
                );

            if (!haveSomeValue)
            {
                this.GI = null;
            }

            return haveSomeValue;
        }
    }

    public partial class GIType
    {
        public bool ShouldSerializeApplicationNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ApplicationNumber);

            if (!haveSomeValue)
            {
                this.ApplicationNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistrationNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegistrationNumber);

            if (!haveSomeValue)
            {
                this.RegistrationNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeUsageSeqNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.UsageSeqNum);

            if (!haveSomeValue)
            {
                this.UsageSeqNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeGIDescriptionDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.GIDescriptionDetails != null)
            {
                this.GIDescriptionDetails = this.GIDescriptionDetails.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.GIDescriptionDetails != null &&
                this.GIDescriptionDetails.Count() != 0;

            if (!haveSomeValue)
            {
                this.GIDescriptionDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeGIDisclaimerDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.GIDisclaimerDetails != null)
            {
                this.GIDisclaimerDetails = this.GIDisclaimerDetails.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.GIDisclaimerDetails != null &&
                this.GIDisclaimerDetails.Count() != 0;

            if (!haveSomeValue)
            {
                this.GIDisclaimerDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeWordMarkSpecification()
        {
            bool haveSomeValue = this.WordMarkSpecification != null &&
                (
                this.WordMarkSpecification.ShouldSerializeMarkVerbalElementText() ||
                this.WordMarkSpecification.ShouldSerializeMarkTranslation()
                );

            if (!haveSomeValue)
            {
                this.WordMarkSpecification = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMarkImageDetails()
        {
            bool haveSomeValue = this.MarkImageDetails != null &&
                (
                this.MarkImageDetails.ShouldSerializeMarkImage()
                );

            if (!haveSomeValue)
            {
                this.MarkImageDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeGoodsServicesDetails()
        {
            bool haveSomeValue = this.GoodsServicesDetails != null &&
                (
                this.GoodsServicesDetails.ShouldSerializeGoodsServices()
                );

            if (!haveSomeValue)
            {
                this.GoodsServicesDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePriorityDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.PriorityDetails != null)
            {
                this.PriorityDetails = this.PriorityDetails.Where(x => x != default(PriorityType)).ToList();
            }

            bool haveSomeValue = this.PriorityDetails != null &&
                this.PriorityDetails.Count() != 0 &&
                (
                this.PriorityDetails[0].PriorityDate != default(DateTime) ||
                this.PriorityDetails[0].PriorityDateSpecified != default(Boolean) ||
                this.PriorityDetails[0].ShouldSerializePriorityCountryCode() ||
                this.PriorityDetails[0].ShouldSerializePriorityNumber()
                );

            if (!haveSomeValue)
            {
                this.PriorityDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeExhibitionPriorityDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.ExhibitionPriorityDetails != null)
            {
                this.ExhibitionPriorityDetails = this.ExhibitionPriorityDetails.Where(x => x != default(ExhibitionPriorityType)).ToList();
            }

            bool haveSomeValue = this.ExhibitionPriorityDetails != null &&
                this.ExhibitionPriorityDetails.Count() != 0 &&
                (
                this.ExhibitionPriorityDetails[0].ExhibitionDate != default(DateTime) ||
                this.ExhibitionPriorityDetails[0].ExhibitionDateSpecified != default(Boolean) ||
                this.ExhibitionPriorityDetails[0].ShouldSerializeExhibitionCountryCode() ||
                this.ExhibitionPriorityDetails[0].ShouldSerializeExhibitionCityName() ||
                this.ExhibitionPriorityDetails[0].ShouldSerializeExhibitionName() ||
                this.ExhibitionPriorityDetails[0].ShouldSerializeComment()
                );

            if (!haveSomeValue)
            {
                this.ExhibitionPriorityDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePublicationDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.PublicationDetails != null)
            {
                this.PublicationDetails = this.PublicationDetails.Where(x => x != default(PublicationType)).ToList();
            }

            bool haveSomeValue = this.PublicationDetails != null &&
                this.PublicationDetails.Count() != 0 &&
                (
                this.PublicationDetails[0].PublicationDate != default(DateTime) ||
                this.PublicationDetails[0].PublicationDateSpecified != default(Boolean) ||
                this.PublicationDetails[0].ShouldSerializePublicationIdentifier() ||
                this.PublicationDetails[0].ShouldSerializePublicationSection() ||
                this.PublicationDetails[0].ShouldSerializePublicationSubsection()
                );

            if (!haveSomeValue)
            {
                this.PublicationDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeApplicantDetails()
        {
            bool haveSomeValue = this.ApplicantDetails != null &&
                (
                this.ApplicantDetails.ShouldSerializeApplicant()
                );

            if (!haveSomeValue)
            {
                this.ApplicantDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRepresentativeDetails()
        {
            bool haveSomeValue = this.RepresentativeDetails != null &&
                (
                this.RepresentativeDetails.ShouldSerializeRepresentative()
                );

            if (!haveSomeValue)
            {
                this.RepresentativeDetails = null;
            }

            return haveSomeValue;
        }
    }

    public partial class WordMarkSpecificationType
    {
        public bool ShouldSerializeMarkVerbalElementText()
        {
            bool haveSomeValue = this.MarkVerbalElementText != null &&
                (
                this.MarkVerbalElementText.ShouldSerializelanguageCode() ||
                this.MarkVerbalElementText.ShouldSerializesequenceNumber() ||
                this.MarkVerbalElementText.ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.MarkVerbalElementText = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMarkTranslation()
        {
            //Here removing the empty elements from the array or collection
            if (this.MarkTranslation != null)
            {
                this.MarkTranslation = this.MarkTranslation.Where(x => x != default(TextType)).ToList();
            }

            bool haveSomeValue = this.MarkTranslation != null &&
                this.MarkTranslation.Count() != 0 &&
                (
                this.MarkTranslation[0].ShouldSerializelanguageCode() ||
                this.MarkTranslation[0].ShouldSerializesequenceNumber() ||
                this.MarkTranslation[0].ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.MarkTranslation = null;
            }

            return haveSomeValue;
        }
    }

    public partial class TextType
    {
        public bool ShouldSerializelanguageCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.languageCode);

            if (!haveSomeValue)
            {
                this.languageCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializesequenceNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.sequenceNumber);

            if (!haveSomeValue)
            {
                this.sequenceNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeValue()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Value);

            if (!haveSomeValue)
            {
                this.Value = null;
            }

            return haveSomeValue;
        }
    }

    public partial class RepresentativeType
    {
        public bool ShouldSerializeRepresentativeIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RepresentativeIdentifier);

            if (!haveSomeValue)
            {
                this.RepresentativeIdentifier = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRepresentativeNationalityCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RepresentativeNationalityCode);

            if (!haveSomeValue)
            {
                this.RepresentativeNationalityCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRepresentativeLegalEntity()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RepresentativeLegalEntity);

            if (!haveSomeValue)
            {
                this.RepresentativeLegalEntity = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRepresentativeAddressBook()
        {
            bool haveSomeValue = this.RepresentativeAddressBook != null &&
                (
                this.RepresentativeAddressBook.ShouldSerializeFormattedNameAddress() ||
                this.RepresentativeAddressBook.ShouldSerializeContactInformationDetails()
                );

            if (!haveSomeValue)
            {
                this.RepresentativeAddressBook = null;
            }

            return haveSomeValue;
        }
    }

    public partial class AddressBookType
    {
        public bool ShouldSerializeFormattedNameAddress()
        {
            bool haveSomeValue = this.FormattedNameAddress != null &&
                (
                this.FormattedNameAddress.ShouldSerializeName() ||
                this.FormattedNameAddress.ShouldSerializeAddress()
                );

            if (!haveSomeValue)
            {
                this.FormattedNameAddress = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeContactInformationDetails()
        {
            bool haveSomeValue = this.ContactInformationDetails != null &&
                (
                this.ContactInformationDetails.ShouldSerializePhone() ||
                this.ContactInformationDetails.ShouldSerializeFax() ||
                this.ContactInformationDetails.ShouldSerializeEmail() ||
                this.ContactInformationDetails.ShouldSerializeURL() ||
                this.ContactInformationDetails.ShouldSerializeOtherElectronicAddress()
                );

            if (!haveSomeValue)
            {
                this.ContactInformationDetails = null;
            }

            return haveSomeValue;
        }
    }

    public partial class FormattedNameAddressType
    {
        public bool ShouldSerializeName()
        {
            bool haveSomeValue = this.Name != null &&
                (
                this.Name.ShouldSerializeFormattedName()
                );

            if (!haveSomeValue)
            {
                this.Name = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAddress()
        {
            bool haveSomeValue = this.Address != null &&
                (
                this.Address.ShouldSerializeFormattedAddress()
                );

            if (!haveSomeValue)
            {
                this.Address = null;
            }

            return haveSomeValue;
        }
    }

    public partial class NameType
    {
        public bool ShouldSerializeFormattedName()
        {
            bool haveSomeValue = this.FormattedName != null &&
                (
                this.FormattedName.ShouldSerializeNamePrefix() ||
                this.FormattedName.ShouldSerializeFirstName() ||
                this.FormattedName.ShouldSerializeMiddleName() ||
                this.FormattedName.ShouldSerializeLastName() ||
                this.FormattedName.ShouldSerializeSecondLastName() ||
                this.FormattedName.ShouldSerializeOrganizationName()
                );

            if (!haveSomeValue)
            {
                this.FormattedName = null;
            }

            return haveSomeValue;
        }
    }

    public partial class FormattedNameType
    {
        public bool ShouldSerializeNamePrefix()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.NamePrefix);

            if (!haveSomeValue)
            {
                this.NamePrefix = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFirstName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FirstName);

            if (!haveSomeValue)
            {
                this.FirstName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMiddleName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.MiddleName);

            if (!haveSomeValue)
            {
                this.MiddleName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLastName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LastName);

            if (!haveSomeValue)
            {
                this.LastName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSecondLastName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SecondLastName);

            if (!haveSomeValue)
            {
                this.SecondLastName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOrganizationName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.OrganizationName);

            if (!haveSomeValue)
            {
                this.OrganizationName = null;
            }

            return haveSomeValue;
        }
    }

    public partial class AddressType
    {
        public bool ShouldSerializeFormattedAddress()
        {
            bool haveSomeValue = this.FormattedAddress != null &&
                (
                this.FormattedAddress.ShouldSerializeAddressStreet() ||
                this.FormattedAddress.ShouldSerializeAddressCity() ||
                this.FormattedAddress.ShouldSerializeAddressCounty() ||
                this.FormattedAddress.ShouldSerializeAddressState() ||
                this.FormattedAddress.ShouldSerializeAddressPostcode() ||
                this.FormattedAddress.ShouldSerializeFormattedAddressCountryCode()
                );

            if (!haveSomeValue)
            {
                this.FormattedAddress = null;
            }

            return haveSomeValue;
        }
    }

    public partial class FormattedAddressType
    {
        public bool ShouldSerializeAddressStreet()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AddressStreet);

            if (!haveSomeValue)
            {
                this.AddressStreet = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAddressCity()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AddressCity);

            if (!haveSomeValue)
            {
                this.AddressCity = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAddressCounty()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AddressCounty);

            if (!haveSomeValue)
            {
                this.AddressCounty = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAddressState()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AddressState);

            if (!haveSomeValue)
            {
                this.AddressState = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAddressPostcode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AddressPostcode);

            if (!haveSomeValue)
            {
                this.AddressPostcode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFormattedAddressCountryCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FormattedAddressCountryCode);

            if (!haveSomeValue)
            {
                this.FormattedAddressCountryCode = null;
            }

            return haveSomeValue;
        }
    }

    public partial class AddressBookTypeContactInformationDetails
    {
        public bool ShouldSerializePhone()
        {
            //Here removing the empty elements from the array or collection
            if (this.Phone != null)
            {
                this.Phone = this.Phone.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.Phone != null &&
                this.Phone.Count() != 0;

            if (!haveSomeValue)
            {
                this.Phone = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFax()
        {
            //Here removing the empty elements from the array or collection
            if (this.Fax != null)
            {
                this.Fax = this.Fax.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.Fax != null &&
                this.Fax.Count() != 0;

            if (!haveSomeValue)
            {
                this.Fax = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmail()
        {
            //Here removing the empty elements from the array or collection
            if (this.Email != null)
            {
                this.Email = this.Email.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.Email != null &&
                this.Email.Count() != 0;

            if (!haveSomeValue)
            {
                this.Email = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeURL()
        {
            //Here removing the empty elements from the array or collection
            if (this.URL != null)
            {
                this.URL = this.URL.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.URL != null &&
                this.URL.Count() != 0;

            if (!haveSomeValue)
            {
                this.URL = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOtherElectronicAddress()
        {
            //Here removing the empty elements from the array or collection
            if (this.OtherElectronicAddress != null)
            {
                this.OtherElectronicAddress = this.OtherElectronicAddress.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.OtherElectronicAddress != null &&
                this.OtherElectronicAddress.Count() != 0;

            if (!haveSomeValue)
            {
                this.OtherElectronicAddress = null;
            }

            return haveSomeValue;
        }
    }

    public partial class ApplicantType
    {
        public bool ShouldSerializeApplicantIdentifier()
        {
            //Here removing the empty elements from the array or collection
            if (this.ApplicantIdentifier != null)
            {
                this.ApplicantIdentifier = this.ApplicantIdentifier.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.ApplicantIdentifier != null &&
                this.ApplicantIdentifier.Count() != 0;

            if (!haveSomeValue)
            {
                this.ApplicantIdentifier = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeApplicantNationalityCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ApplicantNationalityCode);

            if (!haveSomeValue)
            {
                this.ApplicantNationalityCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeApplicantAddressBook()
        {
            bool haveSomeValue = this.ApplicantAddressBook != null &&
                (
                this.ApplicantAddressBook.ShouldSerializeFormattedNameAddress() ||
                this.ApplicantAddressBook.ShouldSerializeContactInformationDetails()
                );

            if (!haveSomeValue)
            {
                this.ApplicantAddressBook = null;
            }

            return haveSomeValue;
        }
    }

    public partial class PublicationType
    {
        public bool ShouldSerializePublicationIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PublicationIdentifier);

            if (!haveSomeValue)
            {
                this.PublicationIdentifier = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePublicationSection()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PublicationSection);

            if (!haveSomeValue)
            {
                this.PublicationSection = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePublicationSubsection()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PublicationSubsection);

            if (!haveSomeValue)
            {
                this.PublicationSubsection = null;
            }

            return haveSomeValue;
        }
    }

    public partial class ExhibitionPriorityType
    {
        public bool ShouldSerializeExhibitionCountryCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ExhibitionCountryCode);

            if (!haveSomeValue)
            {
                this.ExhibitionCountryCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeExhibitionCityName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ExhibitionCityName);

            if (!haveSomeValue)
            {
                this.ExhibitionCityName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeExhibitionName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ExhibitionName);

            if (!haveSomeValue)
            {
                this.ExhibitionName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeComment()
        {
            bool haveSomeValue = this.Comment != null &&
                (
                this.Comment.ShouldSerializelanguageCode() ||
                this.Comment.ShouldSerializesequenceNumber() ||
                this.Comment.ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.Comment = null;
            }

            return haveSomeValue;
        }
    }

    public partial class PriorityType
    {
        public bool ShouldSerializePriorityCountryCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PriorityCountryCode);

            if (!haveSomeValue)
            {
                this.PriorityCountryCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePriorityNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PriorityNumber);

            if (!haveSomeValue)
            {
                this.PriorityNumber = null;
            }

            return haveSomeValue;
        }
    }

    public partial class ClassDescriptionType
    {
        public bool ShouldSerializeClassNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ClassNumber);

            if (!haveSomeValue)
            {
                this.ClassNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeGoodsServicesDescription()
        {
            //Here removing the empty elements from the array or collection
            if (this.GoodsServicesDescription != null)
            {
                this.GoodsServicesDescription = this.GoodsServicesDescription.Where(x => x != default(TextType)).ToList();
            }

            bool haveSomeValue = this.GoodsServicesDescription != null &&
                this.GoodsServicesDescription.Count() != 0 &&
                (
                this.GoodsServicesDescription[0].ShouldSerializelanguageCode() ||
                this.GoodsServicesDescription[0].ShouldSerializesequenceNumber() ||
                this.GoodsServicesDescription[0].ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.GoodsServicesDescription = null;
            }

            return haveSomeValue;
        }
    }

    public partial class GoodsServicesType
    {
        public bool ShouldSerializeClassDescriptionDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.ClassDescriptionDetails != null)
            {
                this.ClassDescriptionDetails = this.ClassDescriptionDetails.Where(x => x != default(ClassDescriptionType)).ToList();
            }

            bool haveSomeValue = this.ClassDescriptionDetails != null &&
                this.ClassDescriptionDetails.Count() != 0 &&
                (
                this.ClassDescriptionDetails[0].ShouldSerializeClassNumber() ||
                this.ClassDescriptionDetails[0].ShouldSerializeGoodsServicesDescription()
                );

            if (!haveSomeValue)
            {
                this.ClassDescriptionDetails = null;
            }

            return haveSomeValue;
        }
    }

    public partial class MarkImageCategoryType
    {
        public bool ShouldSerializeCategoryCodeDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.CategoryCodeDetails != null)
            {
                this.CategoryCodeDetails = this.CategoryCodeDetails.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.CategoryCodeDetails != null &&
                this.CategoryCodeDetails.Count() != 0;

            if (!haveSomeValue)
            {
                this.CategoryCodeDetails = null;
            }

            return haveSomeValue;
        }
    }

    public partial class MarkImageType
    {
        public bool ShouldSerializeMarkImageFileFormat()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.MarkImageFileFormat);

            if (!haveSomeValue)
            {
                this.MarkImageFileFormat = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMarkImageColourClaimedText()
        {
            //Here removing the empty elements from the array or collection
            if (this.MarkImageColourClaimedText != null)
            {
                this.MarkImageColourClaimedText = this.MarkImageColourClaimedText.Where(x => x != default(TextType)).ToList();
            }

            bool haveSomeValue = this.MarkImageColourClaimedText != null &&
                this.MarkImageColourClaimedText.Count() != 0 &&
                (
                this.MarkImageColourClaimedText[0].ShouldSerializelanguageCode() ||
                this.MarkImageColourClaimedText[0].ShouldSerializesequenceNumber() ||
                this.MarkImageColourClaimedText[0].ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.MarkImageColourClaimedText = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMarkImageCategory()
        {
            bool haveSomeValue = this.MarkImageCategory != null &&
                (
                this.MarkImageCategory.ShouldSerializeCategoryCodeDetails()
                );

            if (!haveSomeValue)
            {
                this.MarkImageCategory = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMarkImageBinary()
        {
            bool haveSomeValue = this.MarkImageBinary != null &&
                this.MarkImageBinary.Count() != 0;

            if (!haveSomeValue)
            {
                this.MarkImageBinary = null;
            }

            return haveSomeValue;
        }
    }

    public partial class GITypeMarkImageDetails
    {
        public bool ShouldSerializeMarkImage()
        {
            bool haveSomeValue = this.MarkImage != null &&
                (
                this.MarkImage.ShouldSerializeMarkImageFileFormat() ||
                this.MarkImage.ShouldSerializeMarkImageColourClaimedText() ||
                this.MarkImage.ShouldSerializeMarkImageCategory() ||
                this.MarkImage.ShouldSerializeMarkImageBinary()
                );

            if (!haveSomeValue)
            {
                this.MarkImage = null;
            }

            return haveSomeValue;
        }
    }

    public partial class GITypeGoodsServicesDetails
    {
        public bool ShouldSerializeGoodsServices()
        {
            bool haveSomeValue = this.GoodsServices != null &&
                (
                this.GoodsServices.ShouldSerializeClassDescriptionDetails()
                );

            if (!haveSomeValue)
            {
                this.GoodsServices = null;
            }

            return haveSomeValue;
        }
    }

    public partial class GITypeApplicantDetails
    {
        public bool ShouldSerializeApplicant()
        {
            bool haveSomeValue = this.Applicant != null &&
                (
                this.Applicant.ShouldSerializeApplicantIdentifier() ||
                this.Applicant.ShouldSerializeApplicantNationalityCode() ||
                this.Applicant.ShouldSerializeApplicantAddressBook()
                );

            if (!haveSomeValue)
            {
                this.Applicant = null;
            }

            return haveSomeValue;
        }
    }

    public partial class GITypeRepresentativeDetails
    {
        public bool ShouldSerializeRepresentative()
        {
            bool haveSomeValue = this.Representative != null &&
                (
                this.Representative.ShouldSerializeRepresentativeIdentifier() ||
                this.Representative.ShouldSerializeRepresentativeNationalityCode() ||
                this.Representative.ShouldSerializeRepresentativeLegalEntity() ||
                this.Representative.ShouldSerializeRepresentativeAddressBook()
                );

            if (!haveSomeValue)
            {
                this.Representative = null;
            }

            return haveSomeValue;
        }
    }
}