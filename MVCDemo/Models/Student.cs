using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Student
    {
        //[Key]
        public int StudentID { get; set; }

        //[Key]
        [Display(Name = "Enrollement Number")]
        public int EnrollmentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

      

        //Navigation properties

        //public int CourseID { get; set; }

        //[Required]
        public IEnumerable<Course> course { get; set; }

    }
}