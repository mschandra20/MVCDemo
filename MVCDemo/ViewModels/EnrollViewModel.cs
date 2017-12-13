using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCDemo.ViewModels
{
    public class EnrollViewModel
    {

        #region Student Details

        [Required]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }


        [Required]
        public string Address { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Phone Number")]
        public string Contact { get; set; }
        

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        #endregion


        #region Course Details
        [Required]
        [Display(Name = "Course Name")]
        [StringLength(100)]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Course Number")]
        public int CourseNumber { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Total Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Enrolled Students")]
        public int Enrolled { get; set; }

        [Display(Name = "Empty Seats")]
        public int UnEnrolled { get { return Capacity - Enrolled; } }
        #endregion


        public List<SelectListItem> StudentEnrollmentNumber { set; get; }

        public List<SelectListItem> CourseEnrollmentNumber { set; get; }


        public int? SelectedStudentNumber { set; get; }

        public int? SelectedCourseNumber { set; get; }

    }
}


