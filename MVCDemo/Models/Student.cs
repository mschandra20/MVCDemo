using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class Student
    {
        //[Key]
        public int StudentID { get; set; }

        //[Key]
        public int EnrollmentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("CourseList")]
        public int CourseID { get; set; }
        //Navigation properties
        public IEnumerable<Course> CourseList { get; set; }

    }
}