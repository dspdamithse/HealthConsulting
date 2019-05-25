namespace HealthConsulting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomersAndAppointmentTableDraft : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appontments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentTime = c.DateTime(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                        AppointmentInitialConst = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Image = c.String(),
                        Address = c.String(),
                        HomeTelephoneNumber = c.Int(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        Barakaru = c.String(),
                        barakaruPhone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
            DropTable("dbo.Appontments");
        }
    }
}
