using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.MonChildSchoolStudentsAdapter
{
    public partial class ChildStudentStatusResponse
    {
        public bool ShouldSerializeChildStudentData()
        {
            //Here removing the empty elements from the array or collection
            if (this.ChildStudentData != null)
            {
                this.ChildStudentData = this.ChildStudentData.Where(x => x != default(ChildStudentData)).ToList();
            }

            bool haveSomeValue = this.ChildStudentData != null &&
                this.ChildStudentData.Count() != 0 &&
                (
                this.ChildStudentData[0].EducationalYear != default(Int32) ||
                this.ChildStudentData[0].EducationalYearSpecified != default(Boolean) ||
                //this.ChildStudentData[0].UpdateDate != default(DateTime) ||
                //this.ChildStudentData[0].UpdateDateSpecified != default(Boolean) ||
                this.ChildStudentData[0].ShouldSerializeChildIdentifier() ||
                this.ChildStudentData[0].ShouldSerializeFirstName() ||
                this.ChildStudentData[0].ShouldSerializeMiddleName() ||
                this.ChildStudentData[0].ShouldSerializeLastName() ||
                this.ChildStudentData[0].ShouldSerializeSchoolKindergartenName() ||
                this.ChildStudentData[0].ShouldSerializeEKATTELocationCode() ||
                this.ChildStudentData[0].ShouldSerializeLocationName() ||
                this.ChildStudentData[0].ShouldSerializeEKATTEMunicipalityCode() ||
                this.ChildStudentData[0].ShouldSerializeMunicipalityName() ||
                this.ChildStudentData[0].ShouldSerializeEKATTEDistrictCode() ||
                this.ChildStudentData[0].ShouldSerializeDistrictName() ||
                this.ChildStudentData[0].ShouldSerializeGrade() ||
                this.ChildStudentData[0].ShouldSerializeClassType() ||
                this.ChildStudentData[0].ShouldSerializeEducationForm() ||
                this.ChildStudentData[0].ShouldSerializeSchoolKindergartenType() ||
                this.ChildStudentData[0].ShouldSerializeChildStatus()
                );

            if (!haveSomeValue)
            {
                this.ChildStudentData = null;
            }

            return haveSomeValue;
        }
    }
    public partial class ChildStudentData
    {
        public bool ShouldSerializeChildIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ChildIdentifier);

            if (!haveSomeValue)
            {
                this.ChildIdentifier = null;
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

        public bool ShouldSerializeSchoolKindergartenName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SchoolKindergartenName);

            if (!haveSomeValue)
            {
                this.SchoolKindergartenName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEKATTELocationCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EKATTELocationCode);

            if (!haveSomeValue)
            {
                this.EKATTELocationCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeLocationName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.LocationName);

            if (!haveSomeValue)
            {
                this.LocationName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEKATTEMunicipalityCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EKATTEMunicipalityCode);

            if (!haveSomeValue)
            {
                this.EKATTEMunicipalityCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeMunicipalityName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.MunicipalityName);

            if (!haveSomeValue)
            {
                this.MunicipalityName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEKATTEDistrictCode()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EKATTEDistrictCode);

            if (!haveSomeValue)
            {
                this.EKATTEDistrictCode = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeDistrictName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.DistrictName);

            if (!haveSomeValue)
            {
                this.DistrictName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeGrade()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Grade);

            if (!haveSomeValue)
            {
                this.Grade = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeClassType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ClassType);

            if (!haveSomeValue)
            {
                this.ClassType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEducationForm()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EducationForm);

            if (!haveSomeValue)
            {
                this.EducationForm = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSchoolKindergartenType()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.SchoolKindergartenType);

            if (!haveSomeValue)
            {
                this.SchoolKindergartenType = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeChildStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ChildStatus);

            if (!haveSomeValue)
            {
                this.ChildStatus = null;
            }

            return haveSomeValue;
        }
    }
    public partial class SchoolStudentStatusResponse
    {
        public bool ShouldSerializeChildStudentData()
        {
            //Here removing the empty elements from the array or collection
            if (this.ChildStudentData != null)
            {
                this.ChildStudentData = this.ChildStudentData.Where(x => x != default(ChildStudentData)).ToList();
            }

            bool haveSomeValue = this.ChildStudentData != null &&
                this.ChildStudentData.Count() != 0 &&
                (
                this.ChildStudentData[0].EducationalYear != default(Int32) ||
                this.ChildStudentData[0].EducationalYearSpecified != default(Boolean) ||
                //this.ChildStudentData[0].UpdateDate != default(DateTime) ||
                //this.ChildStudentData[0].UpdateDateSpecified != default(Boolean) ||
                this.ChildStudentData[0].ShouldSerializeChildIdentifier() ||
                this.ChildStudentData[0].ShouldSerializeFirstName() ||
                this.ChildStudentData[0].ShouldSerializeMiddleName() ||
                this.ChildStudentData[0].ShouldSerializeLastName() ||
                this.ChildStudentData[0].ShouldSerializeSchoolKindergartenName() ||
                this.ChildStudentData[0].ShouldSerializeEKATTELocationCode() ||
                this.ChildStudentData[0].ShouldSerializeLocationName() ||
                this.ChildStudentData[0].ShouldSerializeEKATTEMunicipalityCode() ||
                this.ChildStudentData[0].ShouldSerializeMunicipalityName() ||
                this.ChildStudentData[0].ShouldSerializeEKATTEDistrictCode() ||
                this.ChildStudentData[0].ShouldSerializeDistrictName() ||
                this.ChildStudentData[0].ShouldSerializeGrade() ||
                this.ChildStudentData[0].ShouldSerializeClassType() ||
                this.ChildStudentData[0].ShouldSerializeEducationForm() ||
                this.ChildStudentData[0].ShouldSerializeSchoolKindergartenType() ||
                this.ChildStudentData[0].ShouldSerializeChildStatus()
                );

            if (!haveSomeValue)
            {
                this.ChildStudentData = null;
            }

            return haveSomeValue;
        }
    }
}
