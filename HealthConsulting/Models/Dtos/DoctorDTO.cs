using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthConsulting.Models.Dtos
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutHim { get; set; }
        public int ContactNumber { get; set; }

        [Display(Name = "Select Specilist Area")]
        public int SpecialListAreasId { get; set; }
    }
}