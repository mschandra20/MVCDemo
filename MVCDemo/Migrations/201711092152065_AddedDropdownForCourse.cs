namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDropdownForCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Course", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Course");
        }
    }
}
