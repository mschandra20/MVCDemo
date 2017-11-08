namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnrollments1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Course", "Enrolled", c => c.Int(nullable: false));
            AddColumn("dbo.Course", "UnEnrolled", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "UnEnrolled");
            DropColumn("dbo.Course", "Enrolled");
            DropColumn("dbo.Course", "Capacity");
        }
    }
}
