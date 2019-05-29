using AutoMapper;
using HealthConsulting.Models;
using HealthConsulting.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HealthConsulting.Controllers.Api
{
    public class DoctorsController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetDoctors()
        {
            var doctordto = _context.Doctors.ToList().Select(Mapper.Map<Doctor, DoctorDTO>);

            return Ok(doctordto);
        }
        public IHttpActionResult GetDoctor(int id)
        {

            var doctor = _context.Doctors.SingleOrDefault(c => c.Id == id);

            if (doctor == null)
                return NotFound();

            return Ok(Mapper.Map<Doctor, DoctorDTO>(doctor));
        }
        [HttpPost]
        public IHttpActionResult CreateDoctor(DoctorDTO doctorDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var doctor = Mapper.Map<DoctorDTO, Doctor>(doctorDto);

            _context.Doctors.Add(doctor);

            doctorDto.Id = doctor.Id;
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + doctor.Id), doctorDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateDoctors(int id, DoctorDTO doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var doctorInDb = _context.Doctors.SingleOrDefault(c => c.Id == id);

            if (doctorInDb == null)
                return NotFound();

            Mapper.Map(doctorDto, doctorInDb);


            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteDoctor(int id)
        {
            var doctorInDb = _context.Doctors.SingleOrDefault(c => c.Id == id);

            if (doctorInDb == null)
                return NotFound();

            _context.Doctors.Remove(doctorInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
