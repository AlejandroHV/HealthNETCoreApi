using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime OcurredDate { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public string Diagnostic { get; set; }
        public string Medicines { get; set; }


    }
}
