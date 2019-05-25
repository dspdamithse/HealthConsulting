using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthConsulting.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutHim { get; set; }
        public string SpecialistArea { get; set; }

    }
}