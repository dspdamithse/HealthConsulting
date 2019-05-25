using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthConsulting.Models
{
    public class Appontment
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool Confirmed { get; set; }
        public string AppointmentInitialConst { get; set; }

        public Customer Customers { get; set; }
        public int CustomersId { get; set; }

        public Doctor Doctors { get; set; }
        public int DoctorsId { get; set; }

    }
}