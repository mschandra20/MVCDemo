using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        public string Name { get; set; }

        
        public int CourseNumber { get;  set; }

        [Required]
        [Range(0,100)]
        public int Capacity { get; set; }

        public int Enrolled { get; set; }
        public int UnEnrolled { get; set; }

        [NotMapped]
        public sbyte _Capacity
        { get { return (sbyte)Capacity; } set { Capacity = value; } }

        [NotMapped]
        public sbyte _Enrolled
        { get { return (sbyte)Enrolled; } set { Enrolled = (int)value; } }

        [NotMapped]
        public sbyte _UnEnrolled
        { get { return (sbyte)UnEnrolled; } set { UnEnrolled = (int)value; } }

        [ForeignKey("StudentList")]
        public int StudentID { get; set; }
        //Navigation properties
        public IEnumerable<Student> StudentList { get; set; }
        
    }
}