using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCDemo.Models
{
    public class MContext:DbContext
    {
        public MContext() : base("MVCDemoDBCS")
        {

        }
        public DbSet<Course> DbSetCourses { get; set; }
        public DbSet<Student> DbSetStudents { get; set; }
        public DbSet<Enrollment> DbSetEnrollments { get; set; }


        //FLUENT API to override the conventions

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }
    }
}