using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter
{
    public partial class ContactType
    {
        public bool ShouldSerializeDistName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.DistName);

            if (!haveSomeValue)
            {
                this.DistName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTerName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.TerName);

            if (!haveSomeValue)
            {
                this.TerName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePopName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.PopName);

            if (!haveSomeValue)
            {
                this.PopName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAdress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Adress);

            if (!haveSomeValue)
            {
                this.Adress = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializePhone()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Phone);

            if (!haveSomeValue)
            {
                this.Phone = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFax()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Fax);

            if (!haveSomeValue)
            {
                this.Fax = null;
            }

            return haveSomeValue;
        }
    }
    public partial class CertificateType
    {
        public bool ShouldSerializeCategoryCertNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CategoryCertNum);

            if (!haveSomeValue)
            {
                this.CategoryCertNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCategoryCertDate()
        {
            bool haveSomeValue = this.CategoryCertDate != null;

            if (!haveSomeValue)
            {
                this.CategoryCertDate = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeValidityTerm()
        {
            bool haveSomeValue = this.ValidityTerm != null;

            if (!haveSomeValue)
            {
                this.ValidityTerm = null;
            }

            return haveSomeValue;
        }
    }
    public partial class TouristSubobjectType
    {
        public bool ShouldSerializeDescription()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Description);

            if (!haveSomeValue)
            {
                this.Description = null;
            }

            return haveSomeValue;
        }
    }
    public partial class TouristEntertainmentObjectArray
    {
        public bool ShouldSerializeObjects()
        {
            //Here removing the empty elements from the array or collection
            if (this.Objects != null)
            {
                this.Objects = this.Objects.Where(x => x != default(TouristEntertainmentObject)).ToList();
            }

            bool haveSomeValue = this.Objects != null &&
                this.Objects.Count() != 0 &&
                (
                //this.Objects[0].SiteTypeSpecified != default(Boolean) ||
                this.Objects[0].Category != default(Int32) ||
                this.Objects[0].CategorySpecified != default(Boolean) ||
                this.Objects[0].ShouldSerializeSiteName() ||
                this.Objects[0].ShouldSerializeAdress() ||
                this.Objects[0].ShouldSerializeCapacity() ||
                this.Objects[0].ShouldSerializeWorkTime() ||
                this.Objects[0].ShouldSerializeSubobjects() ||
                this.Objects[0].ShouldSerializeCertificate() ||
                this.Objects[0].ShouldSerializeEIK()
                );

            if (!haveSomeValue)
            {
                this.Objects = null;
            }

            return haveSomeValue;
        }
    }
    public partial class TouristEntertainmentObject
    {
        public bool ShouldSerializeSiteName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SiteName);

            if (!haveSomeValue)
            {
                this.SiteName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAdress()
        {
            bool haveSomeValue = this.Adress != null &&
                (
                this.Adress.ShouldSerializeDistName() ||
                this.Adress.ShouldSerializeTerName() ||
                this.Adress.ShouldSerializePopName() ||
                this.Adress.ShouldSerializeAdress() ||
                this.Adress.ShouldSerializePhone() ||
                this.Adress.ShouldSerializeFax()
                );
            if (!haveSomeValue)
            {
                this.Adress = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSiteSubType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SiteSubType);

            if (!haveSomeValue)
            {
                this.SiteSubType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCapacity()
        {
            bool haveSomeValue = this.Capacity != null &&
                (
                this.Capacity.Capacity != default(Int32) ||
                this.Capacity.IndoorsCapacity != default(Int32) ||
                this.Capacity.OutdoorsCapacity != default(Int32)
                );
            if (!haveSomeValue)
            {
                this.Capacity = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeWorkTime()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.WorkTime);

            if (!haveSomeValue)
            {
                this.WorkTime = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSubobjects()
        {
            //Here removing the empty elements from the array or collection
            if (this.Subobjects != null)
            {
                this.Subobjects = this.Subobjects.Where(x => x != default(TouristSubobjectType)).ToList();
            }

            bool haveSomeValue = this.Subobjects != null &&
                this.Subobjects.Count() != 0 &&
                (
                this.Subobjects[0].ShouldSerializeDescription()
                );

            if (!haveSomeValue)
            {
                this.Subobjects = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCertificate()
        {
            bool haveSomeValue = this.Certificate != null &&
                (
                this.Certificate.ShouldSerializeCategoryCertNum() ||
                this.Certificate.ShouldSerializeCategoryCertDate() ||
                this.Certificate.ShouldSerializeValidityTerm()
                );
            if (!haveSomeValue)
            {
                this.Certificate = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEIK()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EIK);

            if (!haveSomeValue)
            {
                this.EIK = null;
            }

            return haveSomeValue;
        }
    }
    public partial class TouristObjectArray
    {
        public bool ShouldSerializeObjects()
        {
            //Here removing the empty elements from the array or collection
            if (this.Objects != null)
            {
                this.Objects = this.Objects.Where(x => x != default(TouristObject)).ToList();
            }

            bool haveSomeValue = this.Objects != null &&
                this.Objects.Count() != 0 &&
                (
                this.Objects[0].SiteKindSpecified != default(Boolean) ||
                //this.Objects[0].SiteType != default(Boolean) ||
                this.Objects[0].Category != default(Int32) ||
                this.Objects[0].CategorySpecified != default(Boolean) ||
                this.Objects[0].RoomsNumber != default(Int32) ||
                this.Objects[0].RoomsNumberSpecified != default(Boolean) ||
                this.Objects[0].BedsNumber != default(Int32) ||
                this.Objects[0].BedsNumberSpecified != default(Boolean) ||
                this.Objects[0].ShouldSerializeSiteName() ||
                this.Objects[0].ShouldSerializeAdress() ||
                this.Objects[0].ShouldSerializeSiteSubType() ||
                this.Objects[0].ShouldSerializeCapacity() ||
                this.Objects[0].ShouldSerializeWorkTime() ||
                this.Objects[0].ShouldSerializeSubobjects() ||
                this.Objects[0].ShouldSerializeCertificate() ||
                this.Objects[0].ShouldSerializeEIK()
                );

            if (!haveSomeValue)
            {
                this.Objects = null;
            }

            return haveSomeValue;
        }
    }
    public partial class TouristObject
    {
        public bool ShouldSerializeSiteName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SiteName);

            if (!haveSomeValue)
            {
                this.SiteName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAdress()
        {
            bool haveSomeValue = this.Adress != null &&
                (
                this.Adress.ShouldSerializeDistName() ||
                this.Adress.ShouldSerializeTerName() ||
                this.Adress.ShouldSerializePopName() ||
                this.Adress.ShouldSerializeAdress() ||
                this.Adress.ShouldSerializePhone() ||
                this.Adress.ShouldSerializeFax()
                );
            if (!haveSomeValue)
            {
                this.Adress = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSiteSubType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SiteSubType);

            if (!haveSomeValue)
            {
                this.SiteSubType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCapacity()
        {
            bool haveSomeValue = this.Capacity != null &&
                (
                this.Capacity.Capacity != default(Int32) ||
                this.Capacity.IndoorsCapacity != default(Int32) ||
                this.Capacity.OutdoorsCapacity != default(Int32)
                );
            if (!haveSomeValue)
            {
                this.Capacity = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeWorkTime()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.WorkTime);

            if (!haveSomeValue)
            {
                this.WorkTime = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSubobjects()
        {
            //Here removing the empty elements from the array or collection
            if (this.Subobjects != null)
            {
                this.Subobjects = this.Subobjects.Where(x => x != default(TouristSubobjectType)).ToList();
            }

            bool haveSomeValue = this.Subobjects != null &&
                this.Subobjects.Count() != 0 &&
                (
                this.Subobjects[0].ShouldSerializeDescription()
                );

            if (!haveSomeValue)
            {
                this.Subobjects = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCertificate()
        {
            bool haveSomeValue = this.Certificate != null &&
                (
                this.Certificate.ShouldSerializeCategoryCertNum() ||
                this.Certificate.ShouldSerializeCategoryCertDate() ||
                this.Certificate.ShouldSerializeValidityTerm()
                );
            if (!haveSomeValue)
            {
                this.Certificate = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEIK()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EIK);

            if (!haveSomeValue)
            {
                this.EIK = null;
            }

            return haveSomeValue;
        }
    }
    public partial class InsuranceArray
    {
        public bool ShouldSerializeInsurance()
        {
            //Here removing the empty elements from the array or collection
            if (this.Insurance != null)
            {
                this.Insurance = this.Insurance.Where(x => x != default(InsuranceType)).ToList();
            }

            bool haveSomeValue = this.Insurance != null &&
                this.Insurance.Count() != 0 &&
                (
                this.Insurance[0].InsuranceIssuedDateSpecified != default(Boolean) ||
                this.Insurance[0].InsuranceEndDateSpecified != default(Boolean) ||
                this.Insurance[0].ShouldSerializeEIK() ||
                this.Insurance[0].ShouldSerializeRegNum() ||
                this.Insurance[0].ShouldSerializeInsuranceCompanyName() ||
                this.Insurance[0].ShouldSerializeInsurancePolicyNum() ||
                this.Insurance[0].ShouldSerializeInsuranceIssuedDate() ||
                this.Insurance[0].ShouldSerializeInsuranceEndDate()
                );

            if (!haveSomeValue)
            {
                this.Insurance = null;
            }

            return haveSomeValue;
        }
    }
    public partial class InsuranceType
    {
        public bool ShouldSerializeEIK()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EIK);

            if (!haveSomeValue)
            {
                this.EIK = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegNum);

            if (!haveSomeValue)
            {
                this.RegNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeInsuranceCompanyName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.InsuranceCompanyName);

            if (!haveSomeValue)
            {
                this.InsuranceCompanyName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeInsurancePolicyNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.InsurancePolicyNum);

            if (!haveSomeValue)
            {
                this.InsurancePolicyNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeInsuranceIssuedDate()
        {
            bool haveSomeValue = this.InsuranceIssuedDate != null;

            if (!haveSomeValue)
            {
                this.InsuranceIssuedDate = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeInsuranceEndDate()
        {
            bool haveSomeValue = this.InsuranceEndDate != null;

            if (!haveSomeValue)
            {
                this.InsuranceEndDate = null;
            }

            return haveSomeValue;
        }
    }
    public partial class Tota
    {
        public bool ShouldSerializeEIK()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EIK);

            if (!haveSomeValue)
            {
                this.EIK = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeCompanyName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.CompanyName);

            if (!haveSomeValue)
            {
                this.CompanyName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeTourOperationType()
        {
            bool haveSomeValue = this.TourOperationType != null;

            if (!haveSomeValue)
            {
                this.TourOperationType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeRegistration()
        {
            bool haveSomeValue = this.Registration != null &&
                (
                this.Registration.DateIssuedSpecified != default(Boolean) ||
                this.Registration.ShouldSerializeRegNum() ||
                this.Registration.ShouldSerializeDateIssued() ||
                this.Registration.ShouldSerializeOrder()
                );
            if (!haveSomeValue)
            {
                this.Registration = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOrderChanges()
        {
            //Here removing the empty elements from the array or collection
            if (this.OrderChanges != null)
            {
                this.OrderChanges = this.OrderChanges.Where(x => x != default(OrderType)).ToList();
            }

            bool haveSomeValue = this.OrderChanges != null &&
                this.OrderChanges.Count() != 0 &&
                (
                this.OrderChanges[0].DateSpecified != default(Boolean) ||
                this.OrderChanges[0].ShouldSerializeNumber() ||
                this.OrderChanges[0].ShouldSerializeDate()
                );

            if (!haveSomeValue)
            {
                this.OrderChanges = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLicenseCancellationOrder()
        {
            bool haveSomeValue = this.LicenseCancellationOrder != null &&
                (
                this.LicenseCancellationOrder.DateSpecified != default(Boolean) ||
                this.LicenseCancellationOrder.ShouldSerializeNumber() ||
                this.LicenseCancellationOrder.ShouldSerializeDate()
                );
            if (!haveSomeValue)
            {
                this.LicenseCancellationOrder = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLicense()
        {
            bool haveSomeValue = this.License != null &&
                (
                this.License.LicenseIssuedOrderDateSpecified != default(Boolean) ||
                this.License.ShouldSerializeLicenseIssuedOrderNum() ||
                this.License.ShouldSerializeLicenseIssuedOrderDate() ||
                this.License.ShouldSerializeOrder()
                );
            if (!haveSomeValue)
            {
                this.License = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOffices()
        {
            //Here removing the empty elements from the array or collection
            if (this.Offices != null)
            {
                this.Offices = this.Offices.Where(x => x != default(Office)).ToList();
            }

            bool haveSomeValue = this.Offices != null &&
                this.Offices.Count() != 0 &&
                (
                this.Offices[0].ShouldSerializeOfficePopName() ||
                this.Offices[0].ShouldSerializeOfficeAddress() ||
                this.Offices[0].ShouldSerializeOfficePhone()
                );

            if (!haveSomeValue)
            {
                this.Offices = null;
            }

            return haveSomeValue;
        }
    }
    public partial class RegistrationType
    {
        public bool ShouldSerializeRegNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.RegNum);

            if (!haveSomeValue)
            {
                this.RegNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDateIssued()
        {
            bool haveSomeValue = this.DateIssued != null;

            if (!haveSomeValue)
            {
                this.DateIssued = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOrder()
        {
            bool haveSomeValue = this.Order != null &&
                (
                this.Order.DateSpecified != default(Boolean) ||
                this.Order.ShouldSerializeNumber() ||
                this.Order.ShouldSerializeDate()
                );
            if (!haveSomeValue)
            {
                this.Order = null;
            }

            return haveSomeValue;
        }
    }
    public partial class OrderType
    {
        public bool ShouldSerializeNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Number);

            if (!haveSomeValue)
            {
                this.Number = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDate()
        {
            bool haveSomeValue = this.Date != null;

            if (!haveSomeValue)
            {
                this.Date = null;
            }

            return haveSomeValue;
        }
    }
    public partial class Office
    {
        public bool ShouldSerializeOfficePopName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.OfficePopName);

            if (!haveSomeValue)
            {
                this.OfficePopName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOfficeAddress()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.OfficeAddress);

            if (!haveSomeValue)
            {
                this.OfficeAddress = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOfficePhone()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.OfficePhone);

            if (!haveSomeValue)
            {
                this.OfficePhone = null;
            }

            return haveSomeValue;
        }
    }
    public partial class LicenseType
    {
        public bool ShouldSerializeLicenseIssuedOrderNum()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LicenseIssuedOrderNum);

            if (!haveSomeValue)
            {
                this.LicenseIssuedOrderNum = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLicenseIssuedOrderDate()
        {
            bool haveSomeValue = this.LicenseIssuedOrderDate != null;

            if (!haveSomeValue)
            {
                this.LicenseIssuedOrderDate = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeOrder()
        {
            bool haveSomeValue = this.Order != null &&
                (
                this.Order.DateSpecified != default(Boolean) ||
                this.Order.ShouldSerializeNumber() ||
                this.Order.ShouldSerializeDate()
                );
            if (!haveSomeValue)
            {
                this.Order = null;
            }

            return haveSomeValue;
        }
    }
}
