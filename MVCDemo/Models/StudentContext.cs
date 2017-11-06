using System.Data.Entity;

namespace MVCDemo.Models
{
    public class StudentContext:DbContext
    {
       public DbSet<Course> DbSetCourses { get; set; }
        public DbSet<Student> DbSetStudents { get; set; }

    }
}