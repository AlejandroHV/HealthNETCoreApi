using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.Models
{
    public class Sickness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symptoms { get; set; }
        public string Description { get; set; }
        public DateTime StartedDate { get; set; }

    }
}
