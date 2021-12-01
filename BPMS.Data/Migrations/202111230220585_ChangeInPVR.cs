namespace BPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInPVR : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientVisitRecord",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        TestsScheduled = c.String(nullable: false),
                        TestResults = c.String(),
                        AppointmentDate = c.DateTime(nullable: false),
                        DoctorsNotes = c.String(nullable: false),
                        Prognosis = c.String(nullable: false),
                        PatientHeight = c.String(nullable: false),
                        PatientWeight = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisitRecord", "PatientId", "dbo.Patient");
            DropIndex("dbo.PatientVisitRecord", new[] { "PatientId" });
            DropTable("dbo.PatientVisitRecord");
        }
    }
}
