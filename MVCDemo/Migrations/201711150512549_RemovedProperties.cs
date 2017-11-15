namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Student_StudentID", c => c.Int());
            CreateIndex("dbo.Course", "Student_StudentID");
            AddForeignKey("dbo.Course", "Student_StudentID", "dbo.Student", "StudentID");
            DropColumn("dbo.Student", "Course");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Course", c => c.Int(nullable: false));
            DropForeignKey("dbo.Course", "Student_StudentID", "dbo.Student");
            DropIndex("dbo.Course", new[] { "Student_StudentID" });
            DropColumn("dbo.Course", "Student_StudentID");
        }
    }
}
