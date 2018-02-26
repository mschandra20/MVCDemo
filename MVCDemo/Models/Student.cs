using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    /// <summary>
    /// This class has information about the student and enrollements of this student
    /// </summary>
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        
        [Display(Name = "Enrollement Number")]
        [Required]
        public int EnrollmentNumber { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name ="Phone Number")]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

      

        //Navigation properties
        //[ForeignKey("enrollment")]
        //public int EnrollmentID { get; set; }

        public virtual IEnumerable<Enrollment> enrollment{ get; set; }

    }
}