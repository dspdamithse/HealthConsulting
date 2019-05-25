namespace HealthConsulting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appontments", "CustomersId", c => c.Int(nullable: false));
            AddColumn("dbo.Appontments", "DoctorsId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "GuardianName", c => c.String());
            AddColumn("dbo.Customers", "GuardianContactNumb", c => c.Int(nullable: false));
            CreateIndex("dbo.Appontments", "CustomersId");
            CreateIndex("dbo.Appontments", "DoctorsId");
            AddForeignKey("dbo.Appontments", "CustomersId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appontments", "DoctorsId", "dbo.Doctors", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "Barakaru");
            DropColumn("dbo.Customers", "barakaruPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "barakaruPhone", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Barakaru", c => c.String());
            DropForeignKey("dbo.Appontments", "DoctorsId", "dbo.Doctors");
            DropForeignKey("dbo.Appontments", "CustomersId", "dbo.Customers");
            DropIndex("dbo.Appontments", new[] { "DoctorsId" });
            DropIndex("dbo.Appontments", new[] { "CustomersId" });
            DropColumn("dbo.Customers", "GuardianContactNumb");
            DropColumn("dbo.Customers", "GuardianName");
            DropColumn("dbo.Appontments", "DoctorsId");
            DropColumn("dbo.Appontments", "CustomersId");
        }
    }
}
