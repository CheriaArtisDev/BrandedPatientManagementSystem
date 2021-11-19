using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Data
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Doctor's First Name")]
        public string DoctorFirstName { get; set; }

        [Required]
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

        [Required]
        [MaxLength(50)]
        [Display(Name = "Doctor's Specialty")]
        public string DoctorSpecialty { get; set; }

        [Required]
        [Display(Name = "Taking New Patients?")]
        public bool TakingNewPatients { get; set; }

        public virtual ICollection<Patient> PatientList { get; set; } = new List<Patient>();
    }
}
