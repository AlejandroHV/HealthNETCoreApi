using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.Models
{
    public class PatientWellnessPlan
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int WellnessPlanId { get; set; }
        public DateTime StartedDate { get; set; }
    }
}
