namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "Contact", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Contact", c => c.String());
            AlterColumn("dbo.Student", "Address", c => c.String());
            AlterColumn("dbo.Student", "Name", c => c.String());
            AlterColumn("dbo.Course", "Name", c => c.String());
        }
    }
}
