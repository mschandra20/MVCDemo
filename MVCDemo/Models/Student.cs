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
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Navigation properties
        public IEnumerable<Course> CourseList { get; set; }

    }
}