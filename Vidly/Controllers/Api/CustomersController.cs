using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers.Api
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
        public IActionResult GetCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer!));
        }

        // POST /api/customers
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            _db.Customers.Add(customer);
            _db.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.GetDisplayUrl() + customerDto.Id), customerDto);
        }


        // PUT /api/customer/id
        [HttpPut("{id:int}")]
        public IActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) BadRequest();

            var customerInDb = _db.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null) NotFound();

            _mapper.Map(customerDto, customerInDb!);

            _db.SaveChanges();

            customerDto.Id = customerInDb!.Id;

            return Ok(customerDto);
        }

        // DELETE /api/customers/id
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerInDb = _db.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null) NotFound();

            _db.Customers.Remove(customerInDb!);
            _db.SaveChanges();

            return Ok(customerInDb);
        }
    }
}
