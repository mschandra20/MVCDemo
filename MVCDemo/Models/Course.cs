using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class Course
    {
        
        [Key]
        public int CourseID { get; set; }

        [Required]
        [Display(Name ="Course Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Course Number")]
        public int CourseNumber { get;  set; }

        [Required]
        [Range(0,100)]
        [Display(Name="Total Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Enrolled Students")]
        public int Enrolled { get; set; }

        [Display(Name = "Empty Seats")]
        public int UnEnrolled { get { return Capacity - Enrolled; } }


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
        { get { return (sbyte)UnEnrolled; } }

        #endregion

        //[ForeignKey("enrollment")]
        //public int EnrollmentID { get; set; }

        //Navigation properties
        public virtual IEnumerable<Enrollment> enrollment { get; set; }
        
    }
}