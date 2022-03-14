using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.MonStudentsAdapter
{
    public partial class HigherEduStudentByStatusResponse
    {
        public bool ShouldSerializeStudentData()
        {
            //Here removing the empty elements from the array or collection
            if (this.StudentData != null)
            {
                this.StudentData = this.StudentData.Where(x => x != default(StudentData)).ToList();
            }

            bool haveSomeValue = this.StudentData != null &&
                this.StudentData.Count() != 0 &&
                (
                this.StudentData[0].EducationalYear != default(Int32) ||
                this.StudentData[0].EducationalYearSpecified != default(Boolean) ||
                this.StudentData[0].UpdateDate != default(DateTime) ||
                this.StudentData[0].UpdateDateSpecified != default(Boolean) ||
                this.StudentData[0].ShouldSerializeStudentIdentifier() ||
                this.StudentData[0].ShouldSerializeFirstName() ||
                this.StudentData[0].ShouldSerializeMiddleName() ||
                this.StudentData[0].ShouldSerializeLastName() ||
                this.StudentData[0].ShouldSerializeNationality() ||
                this.StudentData[0].ShouldSerializeHigherSchoolName() ||
                this.StudentData[0].ShouldSerializeHigherSchollLocation() ||
                this.StudentData[0].ShouldSerializeFacultyName() ||
                this.StudentData[0].ShouldSerializeSemester() ||
                this.StudentData[0].ShouldSerializeAcquiredDegree() ||
                this.StudentData[0].ShouldSerializeProfessionalField() ||
                this.StudentData[0].ShouldSerializeSubject() ||
                this.StudentData[0].ShouldSerializeEducationalCourse() ||
                this.StudentData[0].ShouldSerializeEducationalForm() ||
                this.StudentData[0].ShouldSerializeStudentStatus() ||
                this.StudentData[0].ShouldSerializeFacultyNumber()
                );

            if (!haveSomeValue)
            {
                this.StudentData = null;
            }

            return haveSomeValue;
        }
    }
    public partial class HigherEduStudentResponse
    {
        public bool ShouldSerializeStudentData()
        {
            //Here removing the empty elements from the array or collection
            if (this.StudentData != null)
            {
                this.StudentData = this.StudentData.Where(x => x != default(StudentData)).ToList();
            }

            bool haveSomeValue = this.StudentData != null &&
                this.StudentData.Count() != 0 &&
                (
                this.StudentData[0].EducationalYear != default(Int32) ||
                this.StudentData[0].EducationalYearSpecified != default(Boolean) ||
                this.StudentData[0].UpdateDate != default(DateTime) ||
                this.StudentData[0].UpdateDateSpecified != default(Boolean) ||
                this.StudentData[0].ShouldSerializeStudentIdentifier() ||
                this.StudentData[0].ShouldSerializeFirstName() ||
                this.StudentData[0].ShouldSerializeMiddleName() ||
                this.StudentData[0].ShouldSerializeLastName() ||
                this.StudentData[0].ShouldSerializeNationality() ||
                this.StudentData[0].ShouldSerializeHigherSchoolName() ||
                this.StudentData[0].ShouldSerializeHigherSchollLocation() ||
                this.StudentData[0].ShouldSerializeFacultyName() ||
                this.StudentData[0].ShouldSerializeSemester() ||
                this.StudentData[0].ShouldSerializeAcquiredDegree() ||
                this.StudentData[0].ShouldSerializeProfessionalField() ||
                this.StudentData[0].ShouldSerializeSubject() ||
                this.StudentData[0].ShouldSerializeEducationalCourse() ||
                this.StudentData[0].ShouldSerializeEducationalForm() ||
                this.StudentData[0].ShouldSerializeStudentStatus() ||
                this.StudentData[0].ShouldSerializeFacultyNumber()
                );

            if (!haveSomeValue)
            {
                this.StudentData = null;
            }

            return haveSomeValue;
        }
    }
    public partial class StudentData
    {
        public bool ShouldSerializeStudentIdentifier()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.StudentIdentifier);

            if (!haveSomeValue)
            {
                this.StudentIdentifier = null;
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

        public bool ShouldSerializeNationality()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Nationality);

            if (!haveSomeValue)
            {
                this.Nationality = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeHigherSchoolName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.HigherSchoolName);

            if (!haveSomeValue)
            {
                this.HigherSchoolName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeHigherSchollLocation()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.HigherSchollLocation);

            if (!haveSomeValue)
            {
                this.HigherSchollLocation = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFacultyName()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FacultyName);

            if (!haveSomeValue)
            {
                this.FacultyName = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSemester()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Semester);

            if (!haveSomeValue)
            {
                this.Semester = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeAcquiredDegree()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.AcquiredDegree);

            if (!haveSomeValue)
            {
                this.AcquiredDegree = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeProfessionalField()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.ProfessionalField);

            if (!haveSomeValue)
            {
                this.ProfessionalField = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeSubject()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.Subject);

            if (!haveSomeValue)
            {
                this.Subject = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEducationalCourse()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EducationalCourse);

            if (!haveSomeValue)
            {
                this.EducationalCourse = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeEducationalForm()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.EducationalForm);

            if (!haveSomeValue)
            {
                this.EducationalForm = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeStudentStatus()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.StudentStatus);

            if (!haveSomeValue)
            {
                this.StudentStatus = null;
            }

            return haveSomeValue;
        }

        public bool ShouldSerializeFacultyNumber()
        {
            bool haveSomeValue = !string.IsNullOrEmpty(this.FacultyNumber);

            if (!haveSomeValue)
            {
                this.FacultyNumber = null;
            }

            return haveSomeValue;
        }
    }
}
