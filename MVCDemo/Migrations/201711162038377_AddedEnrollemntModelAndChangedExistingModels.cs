namespace MVCDemo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedEnrollemntModelAndChangedExistingModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollementID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollementID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            AlterColumn("dbo.Course", "CourseNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Course", "Enrolled", c => c.Int(nullable: false));
            AddColumn("dbo.Student", "EnrollmentNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Course", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Student", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Contact", c => c.String(nullable: false));
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            AlterColumn("dbo.Student", "Contact", c => c.String());
            AlterColumn("dbo.Student", "Address", c => c.String());
            AlterColumn("dbo.Student", "Name", c => c.String());
            AlterColumn("dbo.Course", "Name", c => c.String());
            DropColumn("dbo.Student", "EnrollmentNumber");
            DropColumn("dbo.Course", "Enrolled");
            DropColumn("dbo.Course", "CourseNumber");
            DropTable("dbo.Enrollment");
        }
    }
}
