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
        public int EnrollmentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        //Navigation properties
        public IEnumerable<Course> CourseList { get; set; }

    }
}