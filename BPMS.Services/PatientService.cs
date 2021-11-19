using BPMS.Data;
using BPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Services
{
    public class PatientService
    {
        public bool CreatePatient(PatientCreate model)
        {
            
            var entity = new Patient()
            {
                PatientFirstName = model.PatientFirstName,
                PatientLastName = model.PatientLastName,
                PatientAge = model.PatientAge,
                PatientAddress = model.PatientAddress,
                PatientPhoneNumber = model.PatientPhoneNumber,
                PatientBirthdate = model.PatientBirthdate,
                PatientGender = model.PatientGender,
                DoctorId = model.DoctorId,
                HasInsurance = model.HasInsurance,
                MaritalStatus = model.MaritalStatus
            };
           

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Patients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PatientListPerson> GetPatients()
        {
            using (var ctx = new ApplicationDbContext())
            {
              //  var doctorQuery = ctx.Doctors.Single(d => d.DoctorId == )
                var query = ctx.Patients.ToList().Select(e => new PatientListPerson
                {
                    PatientId = e.PatientId,
                    PatientFirstName = e.PatientFirstName,
                    PatientLastName = e.PatientLastName,
                    PatientAge = e.PatientAge,
                    PatientAddress = e.PatientAddress,
                    PatientPhoneNumber = e.PatientPhoneNumber,
                    PatientBirthdate = e.PatientBirthdate,
                    PatientGender = e.PatientGender,
                    DoctorName = e.Doctor.DoctorFullName,
                    DoctorId = e.DoctorId,
                    HasInsurance = e.HasInsurance,
                    MaritalStatus = e.MaritalStatus
                });
                return query.ToArray();
            }
        }

        public PatientDetail GetPatientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Patients.Single(e => e.PatientId == id);

                return new PatientDetail
                {
                    PatientId = entity.PatientId,
                    PatientFirstName = entity.PatientFirstName,
                    PatientLastName = entity.PatientLastName,
                    PatientAge = entity.PatientAge,
                    PatientAddress = entity.PatientAddress,
                    PatientPhoneNumber = entity.PatientPhoneNumber,
                    PatientBirthdate = entity.PatientBirthdate,
                    PatientGender = entity.PatientGender,
                    DoctorName = entity.Doctor.DoctorFullName,
                    DoctorId = entity.DoctorId,
                    HasInsurance = entity.HasInsurance,
                    MaritalStatus = entity.MaritalStatus
                };
            }
        }

        public bool UpdatePatient(PatientEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Patients.Single(e => e.PatientId == model.PatientId);

                entity.PatientId = model.PatientId;
                entity.PatientFirstName = model.PatientFirstName;
                entity.PatientLastName = model.PatientLastName;
                entity.PatientAge = model.PatientAge;
                entity.PatientAddress = model.PatientAddress;
                entity.PatientPhoneNumber = model.PatientPhoneNumber;
                entity.PatientBirthdate = model.PatientBirthdate;
                entity.PatientGender = model.PatientGender;
                entity.Doctor.DoctorLastName = model.DoctorName;
                entity.DoctorId = model.DoctorId;
                entity.HasInsurance = model.HasInsurance;
                entity.MaritalStatus = model.MaritalStatus;

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeletePatient(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Patients.Single(e => e.PatientId == id);
                ctx.Patients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
