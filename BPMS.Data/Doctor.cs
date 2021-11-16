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
        public string DoctorFirstName { get; set; }

        [Required]
        public string DoctorLastName { get; set; }

        public string DoctorFullName 
        {
            get
            {
                return DoctorFirstName + " " + DoctorLastName;
            } 
        }

        [Required]
        [MaxLength(50)]
        public string DoctorSpecialty { get; set; }

        [Required]
        public bool TakingNewPatients { get; set; }
    }
}
