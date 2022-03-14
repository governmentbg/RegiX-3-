using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.GitExplosivesAdapter
{
    public partial class PersonDetails
    {
        public bool ShouldSerializeFirstName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FirstName);

            if (!haveSomeValue)
            {
                this.FirstName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSecondName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SecondName);

            if (!haveSomeValue)
            {
                this.SecondName = null;
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

        public bool ShouldSerializePhoneNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PhoneNumber);

            if (!haveSomeValue)
            {
                this.PhoneNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCellPhoneNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CellPhoneNumber);

            if (!haveSomeValue)
            {
                this.CellPhoneNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFaxNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FaxNumber);

            if (!haveSomeValue)
            {
                this.FaxNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmailAddress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EmailAddress);

            if (!haveSomeValue)
            {
                this.EmailAddress = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ExplosivesCertificateDataType
    {
        public bool ShouldSerializeCertificateNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CertificateNumber);

            if (!haveSomeValue)
            {
                this.CertificateNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTrainingOrganizationName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.TrainingOrganizationName);

            if (!haveSomeValue)
            {
                this.TrainingOrganizationName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOwnerType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.OwnerType);

            if (!haveSomeValue)
            {
                this.OwnerType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOwnerIdentifierType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.OwnerIdentifierType);

            if (!haveSomeValue)
            {
                this.OwnerIdentifierType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Identifier);

            if (!haveSomeValue)
            {
                this.Identifier = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOwner()
        {
            bool haveSomeValue = this.Owner != null &&
                (
                this.Owner.ShouldSerializeFirstName() ||
                this.Owner.ShouldSerializeSecondName() ||
                this.Owner.ShouldSerializeLastName() ||
                this.Owner.ShouldSerializePhoneNumber() ||
                this.Owner.ShouldSerializeCellPhoneNumber() ||
                this.Owner.ShouldSerializeFaxNumber() ||
                this.Owner.ShouldSerializeEmailAddress()
                );

            if (!haveSomeValue)
            {
                this.Owner = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeQualification()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Qualification);

            if (!haveSomeValue)
            {
                this.Qualification = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeExamProtocolNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ExamProtocolNumber);

            if (!haveSomeValue)
            {
                this.ExamProtocolNumber = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmployerName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EmployerName);

            if (!haveSomeValue)
            {
                this.EmployerName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEmployerIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EmployerIdentifier);

            if (!haveSomeValue)
            {
                this.EmployerIdentifier = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCertificateStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CertificateStatus);

            if (!haveSomeValue)
            {
                this.CertificateStatus = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ValidExplosivesCertificateResponse
    {
        public bool ShouldSerializeValidExplosivesCertificate()
        {
            //Here removing the empty elements from the array or collection
            if (this.ValidExplosivesCertificate != null)
            {
                this.ValidExplosivesCertificate = this.ValidExplosivesCertificate.Where(x => x != default(ExplosivesCertificateDataType)).ToList();
            }

            bool haveSomeValue = this.ValidExplosivesCertificate != null &&
                this.ValidExplosivesCertificate.Count() != 0 &&
                (
                this.ValidExplosivesCertificate[0].ExpiryDate != default(DateTime) ||
                this.ValidExplosivesCertificate[0].ExpiryDateSpecified != default(Boolean) ||
                this.ValidExplosivesCertificate[0].ExamProtocolDate != default(DateTime) ||
                this.ValidExplosivesCertificate[0].ExamProtocolDateSpecified != default(Boolean) ||
                this.ValidExplosivesCertificate[0].ShouldSerializeCertificateNumber() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeTrainingOrganizationName() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeOwnerType() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeOwnerIdentifierType() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeIdentifier() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeOwner() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeQualification() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeExamProtocolNumber() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeEmployerName() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeEmployerIdentifier() ||
                this.ValidExplosivesCertificate[0].ShouldSerializeCertificateStatus()
                );

            if (!haveSomeValue)
            {
                this.ValidExplosivesCertificate = null;
            }

            return haveSomeValue;
        }
    }
}
