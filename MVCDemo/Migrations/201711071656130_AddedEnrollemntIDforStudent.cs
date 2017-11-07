namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnrollemntIDforStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "EnrollmentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "EnrollmentID");
        }
    }
}
