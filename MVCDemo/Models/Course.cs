using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class Course
    {
        [Required]
        public int CourseID { get; set; }

        [Required]
        public string Name { get; set; }

        
        public int CourseNumber { get;  set; }

        [Required]
        [Range(0,100)]
        public int Capacity { get; set; }

        public int Enrolled { get; set; }
        public int UnEnrolled { get; set; }


        #region Notmapped Properties

        //These not mapped entities are for usng sbyte in our application but as DB does not consist 
        //a datatype for the sbyte we convert it to int
        [NotMapped]
        public sbyte _Capacity
        { get { return (sbyte)Capacity; } set { Capacity = value; } }

        [NotMapped]
        public sbyte _Enrolled
        { get { return (sbyte)Enrolled; } set { Enrolled = (int)value; } }

        [NotMapped]
        public sbyte _UnEnrolled
        { get { return (sbyte)UnEnrolled; } set { UnEnrolled = (int)value; } }

        #endregion



        //Navigation properties

       
       // public int StudentID { get; set; }

        //[Key,ForeignKey("course")]
        public Student Student { get; set; }
        
    }
}