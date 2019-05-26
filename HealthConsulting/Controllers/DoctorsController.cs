using HealthConsulting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using HealthConsulting.Models.ViewModels;

namespace HealthConsulting.Controllers
{
    public class DoctorsController : Controller
    {
        // GET: Doctors
        private ApplicationDbContext _context;

        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var doctor = _context.Doctors.Include(m => m.SpecialListAreas).ToList();

            return View(doctor);
        }

        public ActionResult Edit(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(c => c.Id == id);

            if (doctor == null)
                return HttpNotFound();
            var viewModel = new DoctorFormViewModel
            {
                Doctors = doctor,
                SpecialListAreas = _context.SpecialListAreas.ToList()
            };


            return View("DoctorForm", viewModel);
        }

        public ActionResult New()
        {
            var specialistAreas = _context.SpecialListAreas.ToList();
            var viewModel = new DoctorFormViewModel
            {
                Doctors = new Doctor(),
                SpecialListAreas = specialistAreas
            };

            return View("DoctorForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Doctor Doctors)
        {
            if (Doctors.Id == 0)
                _context.Doctors.Add(Doctors);
            else
            {
                var customerInDb = _context.Doctors.Single(c => c.Id == Doctors.Id);
                customerInDb.FirstName = Doctors.FirstName;
                customerInDb.LastName = Doctors.LastName;
                customerInDb.AboutHim = Doctors.AboutHim;
                customerInDb.SpecialListAreasId = Doctors.SpecialListAreasId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Doctors");
        }
    }
}