using BPMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Models
{
    public class PatientCreate
    {
        [Required]
        [Display(Name = "Patient's First Name")]
        public string PatientFirstName { get; set; }

        [Required]
        [Display(Name = "Patient's Last Name")]
        public string PatientLastName { get; set; }

        [Display(Name = "Patient's Full Name")]
        public string PatientFullName
        {
            get
            {
                return PatientFirstName + " " + PatientLastName;
            }
        }

        [Required]
        [Display(Name = "Patient's Age")]
        public int PatientAge { get; set; }

        [Required]
        [Display(Name = "Patient's Address")]
        public string PatientAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Patient's Phone Number")]
        public string PatientPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Patient's Birthdate")]
        public DateTime PatientBirthdate { get; set; }

        [Required]
        [Display(Name = "Patient's Gender")]
        public string PatientGender { get; set; }

        public virtual List<Doctor> Doctors { get; set; }
        [ForeignKey(nameof(DoctorId))]
        [Display(Name = "Patient's Doctor")]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Has Insurance?")]
        public bool HasInsurance { get; set; }

        [Required]
        [Display(Name = "Patient's Marital Status")]
        public string MaritalStatus { get; set; }
    }
}
