namespace HealthConsulting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSpecialistAreas : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SpecialListAreas(Name, Description) VALUES('Cardiologists','Cardiologists Description')");
            Sql("INSERT INTO SpecialListAreas(Name, Description) VALUES('Anesthesiologists','Anesthesiologists Description')");
            Sql("INSERT INTO SpecialListAreas(Name, Description) VALUES('Urologists','Urologists Description')");
            Sql("INSERT INTO SpecialListAreas(Name, Description) VALUES('Gastroenterologists','Gastroenterologists Description')");
            Sql("INSERT INTO SpecialListAreas(Name, Description) VALUES('Oncologists','Oncologists Description')");
            Sql("INSERT INTO SpecialListAreas(Name, Description) VALUES('Dermatologists','Dermatologists Description')");
        }
        
        public override void Down()
        {
        }
    }
}
