using AutoMapper;
using HealthConsulting.Models;
using HealthConsulting.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthConsulting.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Doctor, DoctorDTO>();

            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<DoctorDTO, Doctor>()
               .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}