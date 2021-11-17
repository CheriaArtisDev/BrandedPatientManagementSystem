using BPMS.Data;
using BPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Services
{
    public class DoctorService
    {
        public bool CreateDoctor(DoctorCreate model)
        {
            var entity = new Doctor()
            {
                DoctorFirstName = model.DoctorFirstName,
                DoctorLastName = model.DoctorLastName,
                DoctorSpecialty = model.DoctorSpecialty,
                TakingNewPatients = model.TakingNewPatients
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Doctors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DoctorListPerson> GetDoctors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Doctors.Select(e => new DoctorListPerson
                {
                    DoctorId = e.DoctorId,
                    DoctorFirstName = e.DoctorFirstName,
                    DoctorLastName = e.DoctorLastName,
                    DoctorSpecialty = e.DoctorSpecialty,
                    TakingNewPatients = e.TakingNewPatients
                });

                return query.ToArray();
            }
        }

        public DoctorDetail GetDoctorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Doctors.Single(e => e.DoctorId == id);

                return new DoctorDetail
                {
                    DoctorId = entity.DoctorId,
                    DoctorFirstName = entity.DoctorFirstName,
                    DoctorLastName = entity.DoctorLastName,
                    DoctorSpecialty = entity.DoctorSpecialty,
                    TakingNewPatients = entity.TakingNewPatients
                };
            }
        }
    }
}
