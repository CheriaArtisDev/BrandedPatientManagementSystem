namespace BPMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorDataChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientVisitRecord", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientVisitRecord", "DoctorId");
            AddForeignKey("dbo.PatientVisitRecord", "DoctorId", "dbo.Doctor", "DoctorId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisitRecord", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.PatientVisitRecord", new[] { "DoctorId" });
            DropColumn("dbo.PatientVisitRecord", "DoctorId");
        }
    }
}
