using BPMS.Data;
using BPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Services
{
    public class PatientVisitRecordService
    {
        public bool CreatePatientVisitRecord(PatientVisitRecordCreate model)
        {
            var entity = new PatientVisitRecord()
            {
                RecordId = model.RecordId,
                TestsScheduled = model.TestsScheduled,
                TestResults = model.TestResults,
                AppointmentDate = model.AppointmentDate,
                DoctorsNotes = model.DoctorsNotes,
                Prognosis = model.Prognosis,
                PatientHeight = model.PatientHeight,
                PatientWeight = model.PatientWeight,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PatientVisitRecords.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PatientVisitList> GetPatientVisitRecords()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PatientVisitRecords.Select(e => new PatientVisitList
                {
                    RecordId = e.RecordId,
                    TestsScheduled = e.TestsScheduled,
                    TestResults = e.TestResults,
                    AppointmentDate = e.AppointmentDate,
                    DoctorsNotes = e.DoctorsNotes,
                    Prognosis = e.Prognosis,
                    PatientHeight = e.PatientHeight,
                    PatientWeight = e.PatientWeight,
                    DoctorId = e.DoctorId,
                    PatientId = e.PatientId
                });

                return query.ToArray();
            }
        }

        public PatientVisitRecordDetail GetPatientVisitRecordsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PatientVisitRecords.Single(e => e.RecordId == id);

                return new PatientVisitRecordDetail
                {
                    RecordId = entity.RecordId,
                    TestsScheduled = entity.TestsScheduled,
                    TestResults = entity.TestResults,
                    AppointmentDate = entity.AppointmentDate,
                    DoctorsNotes = entity.DoctorsNotes,
                    Prognosis = entity.Prognosis,
                    PatientHeight = entity.PatientHeight,
                    PatientWeight = entity.PatientWeight,
                    DoctorId = entity.DoctorId,
                    PatientId = entity.PatientId
                };
            }
        }

        public bool UpdatePatientVisitRecord(PatientVisitRecordEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PatientVisitRecords.Single(e => e.RecordId == model.RecordId);

                entity.RecordId = model.RecordId;
                entity.TestsScheduled = model.TestsScheduled;
                entity.TestResults = model.TestResults;
                entity.AppointmentDate = model.AppointmentDate;
                entity.DoctorsNotes = model.DoctorsNotes;
                entity.Prognosis = model.Prognosis;
                entity.PatientHeight = model.PatientHeight;
                entity.PatientWeight = model.PatientWeight;
                entity.DoctorId = model.DoctorId;
                entity.PatientId = model.PatientId;

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeletePatientVisitRecord(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PatientVisitRecords.Single(e => e.RecordId == id);
                ctx.PatientVisitRecords.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
