using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAPI.Models
{
    public class Patient
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
        //sickness : ISickness[]
        //appointsments : IAppointment[], 
        //wellnessPlan : IWellnessPlan[]
    }
}
