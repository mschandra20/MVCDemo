using System.Data.Entity;

namespace MVCDemo.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("StudentCourseDatabase")
        {

        }
        public DbSet<Course> DbSetCourses { get; set; }
        public DbSet<Student> DbSetStudents { get; set; }



        //FLUENT API to override the conventions

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}