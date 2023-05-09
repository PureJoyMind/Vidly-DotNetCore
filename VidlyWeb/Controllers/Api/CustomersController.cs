using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VidlyWeb.Models;

namespace VidlyWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        // GET /api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _db.Customers.ToList();
        }

        // GET /api/customers/id
        [HttpGet("{id:int}")]
        public Customer GetCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) NotFound();

            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid) BadRequest();

            _db.Customers.Add(customer);
            _db.SaveChanges();

            return customer;
        }


        // PUT /api/customer/id
        [HttpPut("{id:int}")]
        public Customer UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid) BadRequest();

            var customerInDb = _db.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null) NotFound();

            customerInDb.Name = customer.Name;
            customerInDb.BirthDateTime = customer.BirthDateTime;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _db.SaveChanges();
            return customerInDb;
        }

        // DELETE /api/customers/id
        [HttpDelete("{id:int}")]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _db.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null) NotFound();

            _db.Customers.Remove(customerInDb);
            _db.SaveChanges();
        }
    }
}
