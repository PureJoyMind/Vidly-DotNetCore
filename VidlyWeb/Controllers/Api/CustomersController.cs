using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VidlyWeb.Dtos;
using VidlyWeb.Models;

namespace VidlyWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _db.Customers.ToList().Select(_mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/id
        [HttpGet("{id:int}")]
        public CustomerDto GetCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) NotFound();

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            _db.Customers.Add(customer);
            _db.SaveChanges();

            //customerDto.Id = customer.Id;

            return customerDto;
        }


        // PUT /api/customer/id
        [HttpPut("{id:int}")]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) BadRequest();

            var customerInDb = _db.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null) NotFound();

            _mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _db.SaveChanges();
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
