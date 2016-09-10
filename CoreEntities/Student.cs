using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class Student
    {
        public Student() {
            IsAdmin = false;
            IsApproved = false;
        }

        public long StudentId { get; set; }
        public string FullName { get; set; }
        public string RollNo { get; set; }
        public string EnrollmentNo { get; set; }
        public bool IsAdmin { get; set; } 
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string EmailId { get; set; }
        public bool IsApproved { get; set; }

        public long BranchId { get; set; }
        public Branch branch { get; set; }
        public long AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
