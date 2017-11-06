using System.Data.Entity;

namespace MVCDemo.Models
{
    public class StudentContext:DbContext
    {
        DbSet<Course> DbSetCourses { get; set; }
        DbSet<Student> DbSetStudents { get; set; }

    }
}