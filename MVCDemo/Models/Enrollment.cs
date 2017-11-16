using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    /// <summary>
    /// This class records the student and course enrollment
    /// </summary>
    public class Enrollment
    {
        [Key]
        public int EnrollementID { get; set; }

        [ForeignKey("student")]
        public int StudentID { get; set; }

        [ForeignKey("course")]
        public int CourseID { get; set; }


        //Navigation properties
        public Student student { get; set; }
        public Course course { get; set; }
    }
}