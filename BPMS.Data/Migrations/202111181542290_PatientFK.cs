namespace BPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientFirstName = c.String(nullable: false),
                        PatientLastName = c.String(nullable: false),
                        PatientAge = c.Int(nullable: false),
                        PatientAddress = c.String(nullable: false),
                        PatientPhoneNumber = c.String(nullable: false),
                        PatientBirthdate = c.DateTime(nullable: false),
                        PatientGender = c.String(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        HasInsurance = c.Boolean(nullable: false),
                        MaritalStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.Patient", new[] { "DoctorId" });
            DropTable("dbo.Patient");
        }
    }
}
