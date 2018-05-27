using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.DataTransferObjects
{
    public class StudentDetailsDTO
    {
        public string StudentName { get; set; }
        public int StudentNumber { get; set; }
        public List<ListOfCourses> CourseList { get; set; }
        
    }
    public class ListOfCourses
    {
        public int CourseNumber { get; set; }
        public string CourseName { get; set; }
    }
}