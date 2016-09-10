using CoreEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ClientInterface.Models
{
    public class StudentsViewModel
    {
        public StudentsViewModel()
        {
            IsAdmin = false;
            IsApproved = false;
        }

        public long StudentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Full Name not found")]
        public string FullName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Roll No not found")]
        public string RollNo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Enrollment No not found")]
        public string EnrollmentNo { get; set; }
        public bool IsAdmin { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Login Name not found")]
        public string LoginName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Login Password not found")]
        public string LoginPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Email Id not found")]
        public string EmailId { get; set; }
        public bool IsApproved { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Branch not found")]
        public long BranchId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Academic Year not found")]
        public long AcademicYearId { get; set; }


    }
}