using System;
using System.Collections.Generic;

namespace MVCDemo.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int StudentID { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Navigation properties
        public IEnumerable<Course> CourseList { get; set; }

    }
}