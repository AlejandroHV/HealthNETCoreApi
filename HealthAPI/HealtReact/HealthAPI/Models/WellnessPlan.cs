using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.Models
{
    public class WellnessPlan
    {

        public  int Id { get; set; }
        public string Name { get; set; }
        public  string  Description { get; set; }
        public string Activities { get; set; }
        public double Duration { get; set; }
    }
}
