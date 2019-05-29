using HealthConsulting.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HealthConsulting.Models.Dtos;
using AutoMapper;

namespace HealthConsulting.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomers()
        {
            var customersDto = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customersDto);
        }
        public IHttpActionResult GetCustomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);

            _context.Customers.Add(customer);

            customerDto.Id = customer.Id;
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+ customer.Id), customerDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCustomers(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);


            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
