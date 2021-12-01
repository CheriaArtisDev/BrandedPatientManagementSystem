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
    public class PatientVisitRecordCreate
    {
        [Key]
        public int RecordId { get; set; }
        [Required]
        public string TestsScheduled { get; set; }

        public string TestResults { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string DoctorsNotes { get; set; }
        [Required]
        public string Prognosis { get; set; }
        [Required]
        public string PatientHeight { get; set; }
        [Required]
        public int PatientWeight { get; set; }
        
        public List<Doctor> Doctor { get; set; }
        [ForeignKey(nameof(Doctor))]
        [Display(Name = "Patient's Doctor")]

        public int DoctorId { get; set; }
        
        public List<Patient> Patient { get; set; }
        [ForeignKey(nameof(Patient))]
        [Display(Name = "Patient")]

        public int PatientId { get; set; }
    }
}
