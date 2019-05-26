namespace HealthConsulting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Image", c => c.String());
            AddColumn("dbo.Doctors", "ContactNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "ContactNumber");
            DropColumn("dbo.Doctors", "Image");
        }
    }
}
