using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCDemo.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("MVCDemoDBCS")
        {

        }
        public DbSet<Course> DbSetCourses { get; set; }
        public DbSet<Student> DbSetStudents { get; set; }



        //FLUENT API to override the conventions

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}