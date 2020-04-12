using HealthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.DTOS
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InsuranceName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserPassword { get; set; }
        public IEnumerable<Sickness> Sicknesses { get; set; }
        public IEnumerable<Appointment> Appointsments { get; set; }
        public IEnumerable<WellnessPlan> WellnessPlan { get; set; }
    }
}
