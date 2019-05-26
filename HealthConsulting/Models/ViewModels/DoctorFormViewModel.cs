using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthConsulting.Models.ViewModels
{
    public class DoctorFormViewModel
    {
        public IEnumerable<SpecialListArea> SpecialListAreas { get; set; }
        public Doctor Doctors { get; set; }
    }
}