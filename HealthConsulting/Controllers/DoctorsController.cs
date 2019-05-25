using HealthConsulting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ViewResult Index()
        {
            var doctor = _context.Doctors.ToList();

            return View(doctor);
        }

        public ActionResult Edit(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(c => c.Id == id);

            if (doctor == null)
                return HttpNotFound();

            return View("CustomerForm", doctor);
        }

        public ActionResult New()
        {
            return View("CustomerForm");
        }

        [HttpPost]
        public ActionResult Save(Doctor doctor)
        {
            if (doctor.Id == 0)
                _context.Doctors.Add(doctor);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == doctor.Id);

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
    }
}