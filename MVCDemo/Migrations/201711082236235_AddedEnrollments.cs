namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnrollments : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Course", "Capacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "Capacity", c => c.Int(nullable: false));
        }
    }
}
