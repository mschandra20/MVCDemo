using System.Collections.Generic;

namespace MVCDemo.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int CourseNumber { get;  set; }
        
        
        //Navigation properties
        public IEnumerable<Student> StudentList { get; set; }
        
    }
}