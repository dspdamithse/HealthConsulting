using HealthConsulting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthConsulting.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", customer);
        }

        public ActionResult New()
        {
            return View("CustomerForm");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Image = customer.Image;
                customerInDb.Address = customer.Address;
                customerInDb.HomeTelephoneNumber = customer.HomeTelephoneNumber;
                customerInDb.MobileNumber = customer.MobileNumber;
                customerInDb.GuardianName = customer.GuardianName;
                customerInDb.GuardianContactNumb = customer.GuardianContactNumb;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

    }
}