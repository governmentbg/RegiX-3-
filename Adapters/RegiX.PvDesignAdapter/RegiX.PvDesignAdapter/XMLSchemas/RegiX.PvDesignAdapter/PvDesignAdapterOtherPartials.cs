using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.PvDesignAdapter
{
    public partial class DesignDetailsType
    {
        public bool ShouldSerializeDesign()
        {
            //Here removing the empty elements from the array or collection
            if (this.Design != null)
            {
                this.Design = this.Design.Where(x => x != default(DesignType)).ToList();
            }

            bool haveSomeValue = this.Design != null &&
                this.Design.Count() != 0 &&
                (
                this.Design[0].ApplicationDate != default(DateTime) ||
                this.Design[0].ApplicationDateSpecified != default(Boolean) ||
                this.Design[0].RegistrationDate != default(DateTime) ||
                this.Design[0].RegistrationDateSpecified != default(Boolean) ||
                this.Design[0].ExpiryDate != default(DateTime) ||
                this.Design[0].ExpiryDateSpecified != default(Boolean) ||
                //this.Design[0].DesignCurrentStatusCodeSpecified != default(Boolean) || -> Няма такова поле
                this.Design[0].DesignCurrentStatusDate != default(DateTime) ||
                this.Design[0].DesignCurrentStatusDateSpecified != default(Boolean) ||
                //this.Design[0].DesignKindSpecified != default(Boolean) || -> Няма такова поле
                this.Design[0].ShouldSerializeApplicationNumber() ||
                this.Design[0].ShouldSerializeRegistrationNumber() ||
                this.Design[0].ShouldSerializeDesignTitle() ||
                this.Design[0].ShouldSerializeDesignDescription() ||
                this.Design[0].ShouldSerializeDesignRepresentationSheetDetails() ||
                this.Design[0].ShouldSerializeIndicationProductDetails() ||
                this.Design[0].ShouldSerializePriorityDetails() ||
                this.Design[0].ShouldSerializeExhibitionPriorityDetails() ||
                this.Design[0].ShouldSerializePublicationDetails() ||
                this.Design[0].ShouldSerializeApplicantDetails() ||
                this.Design[0].ShouldSerializeRepresentativeDetails() ||
                this.Design[0].ShouldSerializeDesignerDetails()
                );

            if (!haveSomeValue)
            {
                this.Design = null;
            }

            return haveSomeValue;
        }
    }

    public partial class DesignType
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

        public bool ShouldSerializeDesignTitle()
        {
            bool haveSomeValue = this.DesignTitle != null &&
                (
                this.DesignTitle.ShouldSerializelanguageCode() ||
                this.DesignTitle.ShouldSerializesequenceNumber() ||
                this.DesignTitle.ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.DesignTitle = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDesignDescription()
        {
            bool haveSomeValue = this.DesignDescription != null &&
                (
                this.DesignDescription.ShouldSerializelanguageCode() ||
                this.DesignDescription.ShouldSerializesequenceNumber() ||
                this.DesignDescription.ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.DesignDescription = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDesignRepresentationSheetDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.DesignRepresentationSheetDetails != null)
            {
                this.DesignRepresentationSheetDetails = this.DesignRepresentationSheetDetails.Where(x => x != default(ViewType)).ToList();
            }

            bool haveSomeValue = this.DesignRepresentationSheetDetails != null &&
                this.DesignRepresentationSheetDetails.Count() != 0 &&
                (
                this.DesignRepresentationSheetDetails[0].ShouldSerializeViewIdentifier() ||
                this.DesignRepresentationSheetDetails[0].ShouldSerializeViewFileFormat() ||
                this.DesignRepresentationSheetDetails[0].ShouldSerializeViewTitle() ||
                this.DesignRepresentationSheetDetails[0].ShouldSerializeViewBinary()
                );

            if (!haveSomeValue)
            {
                this.DesignRepresentationSheetDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeIndicationProductDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.IndicationProductDetails != null)
            {
                this.IndicationProductDetails = this.IndicationProductDetails.Where(x => x != default(LocarnoClassDescriptionType)).ToList();
            }

            bool haveSomeValue = this.IndicationProductDetails != null &&
                this.IndicationProductDetails.Count() != 0 &&
                (
                this.IndicationProductDetails[0].ShouldSerializeClassNumber() ||
                this.IndicationProductDetails[0].ShouldSerializeProductDescription()
                );

            if (!haveSomeValue)
            {
                this.IndicationProductDetails = null;
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

        public bool ShouldSerializeDesignerDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.DesignerDetails != null)
            {
                this.DesignerDetails = this.DesignerDetails.Where(x => x != default(DesignerType)).ToList();
            }

            bool haveSomeValue = this.DesignerDetails != null &&
                this.DesignerDetails.Count() != 0 &&
                (
                this.DesignerDetails[0].ShouldSerializeDesignerNationalityCode() ||
                this.DesignerDetails[0].ShouldSerializeDesignerLegalEntity() ||
                this.DesignerDetails[0].ShouldSerializeDesignerAddressBook()
                );

            if (!haveSomeValue)
            {
                this.DesignerDetails = null;
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

    public partial class DesignerType
    {
        public bool ShouldSerializeDesignerNationalityCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.DesignerNationalityCode);

            if (!haveSomeValue)
            {
                this.DesignerNationalityCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDesignerLegalEntity()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.DesignerLegalEntity);

            if (!haveSomeValue)
            {
                this.DesignerLegalEntity = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDesignerAddressBook()
        {
            bool haveSomeValue = this.DesignerAddressBook != null &&
                (
                this.DesignerAddressBook.ShouldSerializeFormattedNameAddress() ||
                this.DesignerAddressBook.ShouldSerializeContactInformationDetails()
                );

            if (!haveSomeValue)
            {
                this.DesignerAddressBook = null;
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
                this.Name.ShouldSerializeItem()
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
                this.Address.ShouldSerializeItem()
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
        public bool ShouldSerializeItem()
        {
            bool haveSomeValue = this.Item != null &&
                (
                this.Item.ShouldSerializeNamePrefix() ||
                this.Item.ShouldSerializeFirstName() ||
                this.Item.ShouldSerializeMiddleName() ||
                this.Item.ShouldSerializeLastName() ||
                this.Item.ShouldSerializeSecondLastName() ||
                this.Item.ShouldSerializeOrganizationName()
                );

            if (!haveSomeValue)
            {
                this.Item = null;
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
        public bool ShouldSerializeItem()
        {
            bool haveSomeValue = this.Item != null &&
                (
                this.Item.ShouldSerializeAddressStreet() ||
                this.Item.ShouldSerializeAddressCity() ||
                this.Item.ShouldSerializeAddressCounty() ||
                this.Item.ShouldSerializeAddressState() ||
                this.Item.ShouldSerializeAddressPostcode() ||
                this.Item.ShouldSerializeFormattedAddressCountryCode()
                );

            if (!haveSomeValue)
            {
                this.Item = null;
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

    public partial class LocarnoClassDescriptionType
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

        public bool ShouldSerializeProductDescription()
        {
            //Here removing the empty elements from the array or collection
            if (this.ProductDescription != null)
            {
                this.ProductDescription = this.ProductDescription.Where(x => x != default(TextType)).ToList();
            }

            bool haveSomeValue = this.ProductDescription != null &&
                this.ProductDescription.Count() != 0 &&
                (
                this.ProductDescription[0].ShouldSerializelanguageCode() ||
                this.ProductDescription[0].ShouldSerializesequenceNumber() ||
                this.ProductDescription[0].ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.ProductDescription = null;
            }

            return haveSomeValue;
        }
    }

    public partial class ViewType
    {
        public bool ShouldSerializeViewIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ViewIdentifier);

            if (!haveSomeValue)
            {
                this.ViewIdentifier = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeViewFileFormat()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ViewFileFormat);

            if (!haveSomeValue)
            {
                this.ViewFileFormat = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeViewTitle()
        {
            bool haveSomeValue = this.ViewTitle != null &&
                (
                this.ViewTitle.ShouldSerializelanguageCode() ||
                this.ViewTitle.ShouldSerializesequenceNumber() ||
                this.ViewTitle.ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.ViewTitle = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeViewBinary()
        {
            bool haveSomeValue = this.ViewBinary != null &&
                this.ViewBinary.Count() != 0;

            if (!haveSomeValue)
            {
                this.ViewBinary = null;
            }

            return haveSomeValue;
        }
    }

    public partial class DesignTypeApplicantDetails
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

    public partial class DesignTypeRepresentativeDetails
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