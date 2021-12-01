using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Models
{
    public class PatientVisitRecordDetail
    {
        public int RecordId { get; set; }
        public string TestsScheduled { get; set; }
        public string TestResults { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorsNotes { get; set; }
        public string Prognosis { get; set; }
        public string PatientHeight { get; set; }
        public int PatientWeight { get; set; }

        [Display(Name = "Patient's Doctor")]
        public int DoctorId { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }
    }
}
