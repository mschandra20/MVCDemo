namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "CourseNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "CourseNumber");
        }
    }
}
