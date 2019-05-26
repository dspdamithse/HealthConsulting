namespace HealthConsulting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialTistAreaAndUpdateDoctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialListAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Doctors", "SpecialListAreasId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "SpecialListAreasId");
            AddForeignKey("dbo.Doctors", "SpecialListAreasId", "dbo.SpecialListAreas", "Id", cascadeDelete: true);
            DropColumn("dbo.Doctors", "SpecialistArea");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "SpecialistArea", c => c.String());
            DropForeignKey("dbo.Doctors", "SpecialListAreasId", "dbo.SpecialListAreas");
            DropIndex("dbo.Doctors", new[] { "SpecialListAreasId" });
            DropColumn("dbo.Doctors", "SpecialListAreasId");
            DropTable("dbo.SpecialListAreas");
        }
    }
}
