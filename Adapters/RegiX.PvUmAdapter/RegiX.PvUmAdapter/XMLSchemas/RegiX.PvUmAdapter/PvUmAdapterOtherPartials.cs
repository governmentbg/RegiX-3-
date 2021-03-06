using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.PvUmAdapter
{
    public partial class PatentDetailsType
    {
        public bool ShouldSerializePatent()
        {
            //Here removing the empty elements from the array or collection
            if (this.Patent != null)
            {
                this.Patent = this.Patent.Where(x => x != default(PatentType)).ToList();
            }

            bool haveSomeValue = this.Patent != null &&
                this.Patent.Count() != 0 &&
                (
                this.Patent[0].ApplicationDate != default(DateTime) ||
                this.Patent[0].ApplicationDateSpecified != default(Boolean) ||
                this.Patent[0].RegistrationDate != default(DateTime) ||
                this.Patent[0].RegistrationDateSpecified != default(Boolean) ||
                this.Patent[0].ExpiryDate != default(DateTime) ||
                this.Patent[0].ExpiryDateSpecified != default(Boolean) ||
                this.Patent[0].PatentCurrentStatusCodeSpecified != default(Boolean) ||
                this.Patent[0].PatentCurrentStatusDate != default(DateTime) ||
                this.Patent[0].PatentCurrentStatusDateSpecified != default(Boolean) ||
                this.Patent[0].PatentKindSpecified != default(Boolean) ||
                this.Patent[0].ShouldSerializeApplicationNumber() ||
                this.Patent[0].ShouldSerializeRegistrationNumber() ||
                this.Patent[0].ShouldSerializePatentTitle() ||
                this.Patent[0].ShouldSerializePatentDescription() ||
                this.Patent[0].ShouldSerializePatentRepresentationSheetDetails() ||
                this.Patent[0].ShouldSerializeIPCClassDetails() ||
                this.Patent[0].ShouldSerializePriorityDetails() ||
                this.Patent[0].ShouldSerializeExhibitionPriorityDetails() ||
                this.Patent[0].ShouldSerializePublicationDetails() ||
                this.Patent[0].ShouldSerializeApplicantDetails() ||
                this.Patent[0].ShouldSerializeRepresentativeDetails() ||
                this.Patent[0].ShouldSerializeInventorDetails()
                );

            if (!haveSomeValue)
            {
                this.Patent = null;
            }

            return haveSomeValue;
        }
    }

    public partial class PatentType
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

        public bool ShouldSerializePatentTitle()
        {
            bool haveSomeValue = this.PatentTitle != null &&
                (
                this.PatentTitle.ShouldSerializelanguageCode() ||
                this.PatentTitle.ShouldSerializesequenceNumber() ||
                this.PatentTitle.ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.PatentTitle = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePatentDescription()
        {
            bool haveSomeValue = this.PatentDescription != null &&
                (
                this.PatentDescription.ShouldSerializelanguageCode() ||
                this.PatentDescription.ShouldSerializesequenceNumber() ||
                this.PatentDescription.ShouldSerializeValue()
                );

            if (!haveSomeValue)
            {
                this.PatentDescription = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePatentRepresentationSheetDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.PatentRepresentationSheetDetails != null)
            {
                this.PatentRepresentationSheetDetails = this.PatentRepresentationSheetDetails.Where(x => x != default(ViewType)).ToList();
            }

            bool haveSomeValue = this.PatentRepresentationSheetDetails != null &&
                this.PatentRepresentationSheetDetails.Count() != 0 &&
                (
                this.PatentRepresentationSheetDetails[0].ShouldSerializeViewIdentifier() ||
                this.PatentRepresentationSheetDetails[0].ShouldSerializeViewFileFormat() ||
                this.PatentRepresentationSheetDetails[0].ShouldSerializeViewTitle() ||
                this.PatentRepresentationSheetDetails[0].ShouldSerializeViewBinary()
                );

            if (!haveSomeValue)
            {
                this.PatentRepresentationSheetDetails = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeIPCClassDetails()
        {
            bool haveSomeValue = this.IPCClassDetails != null &&
                (
                this.IPCClassDetails.ShouldSerializeIPCClass() ||
                this.IPCClassDetails.ShouldSerializeIPCName()
                );

            if (!haveSomeValue)
            {
                this.IPCClassDetails = null;
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

        public bool ShouldSerializeInventorDetails()
        {
            //Here removing the empty elements from the array or collection
            if (this.InventorDetails != null)
            {
                this.InventorDetails = this.InventorDetails.Where(x => x != default(InventorType)).ToList();
            }

            bool haveSomeValue = this.InventorDetails != null &&
                this.InventorDetails.Count() != 0 &&
                (
                this.InventorDetails[0].ShouldSerializeInventorNationalityCode() ||
                this.InventorDetails[0].ShouldSerializeInventorLegalEntity() ||
                this.InventorDetails[0].ShouldSerializeInventorAddressBook()
                );

            if (!haveSomeValue)
            {
                this.InventorDetails = null;
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

    public partial class InventorType
    {
        public bool ShouldSerializeInventorNationalityCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.InventorNationalityCode);

            if (!haveSomeValue)
            {
                this.InventorNationalityCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeInventorLegalEntity()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.InventorLegalEntity);

            if (!haveSomeValue)
            {
                this.InventorLegalEntity = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeInventorAddressBook()
        {
            bool haveSomeValue = this.InventorAddressBook != null &&
                (
                this.InventorAddressBook.ShouldSerializeFormattedNameAddress() ||
                this.InventorAddressBook.ShouldSerializeContactInformationDetails()
                );

            if (!haveSomeValue)
            {
                this.InventorAddressBook = null;
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

    public partial class PatentTypeIPCClassDetails
    {
        public bool ShouldSerializeIPCClass()
        {
            //Here removing the empty elements from the array or collection
            if (this.IPCClass != null)
            {
                this.IPCClass = this.IPCClass.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.IPCClass != null &&
                this.IPCClass.Count() != 0;

            if (!haveSomeValue)
            {
                this.IPCClass = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeIPCName()
        {
            //Here removing the empty elements from the array or collection
            if (this.IPCName != null)
            {
                this.IPCName = this.IPCName.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            bool haveSomeValue = this.IPCName != null &&
                this.IPCName.Count() != 0;

            if (!haveSomeValue)
            {
                this.IPCName = null;
            }

            return haveSomeValue;
        }
    }

    public partial class PatentTypeApplicantDetails
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

    public partial class PatentTypeRepresentativeDetails
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
