using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyWeb.Models;

namespace VidlyWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Customer> customers = _db.Customers
                .Include(c => c.MembershipType);
            return View(customers);
        }

        public IActionResult Details(int? id)
        {
            if (id is null or 0) return NotFound();

            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null) 
                return NotFound();

            return View(customer);
        }
    }
}
