using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Models
{
    public class DoctorListPerson
    {
        [Key]
        public int DoctorId { get; set; }
        [Display(Name = "Doctor's First Name")]
        public string DoctorFirstName { get; set; }

        [Display(Name = "Doctor's Last Name")]
        public string DoctorLastName { get; set; }

        [Display(Name = "Doctor's Full Name")]
        public string DoctorFullName 
        {
            get
            {
                return DoctorFirstName + " " + DoctorLastName;
            } 
        }

        [Display(Name = "Doctor's Specialty")]
        public string DoctorSpecialty { get; set; }

        [Display(Name = "Taking New Patients?")]
        public bool TakingNewPatients { get; set; }
    }
}
