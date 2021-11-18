using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Models
{
    public class DoctorEdit
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        [Display(Name = "Doctor's First Name")]
        public string DoctorFirstName { get; set; }

        [Required]
        [Display(Name = "Doctor's Last Name")]
        public string DoctorLastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Doctor's Specialty")]
        public string DoctorSpecialty { get; set; }

        [Required]
        [Display(Name = "Taking New Patients?")]
        public bool TakingNewPatients { get; set; }
    }
}
