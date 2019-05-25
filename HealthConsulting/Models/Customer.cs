using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthConsulting.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int HomeTelephoneNumber { get; set; }
        public int MobileNumber { get; set; }
        public string GuardianName { get; set; }
        public int GuardianContactNumb{ get; set; }

    }
}