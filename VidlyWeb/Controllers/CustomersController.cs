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

            var customer = _db.Customers.Include(c => c.MembershipType).FirstOrDefault(x => x.Id == id);
            if (customer == null) 
                return NotFound();

            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken] // not required
        public IActionResult Create(Customer obj)
        {
            //if (!ModelState.IsValid) // Is tested in client
            //{
            //    return View(obj);
            //}
            _db.Customers.Add(obj); // not saved to the database
            _db.SaveChanges(); // saved to the database
            TempData["success"] = "Customer Created Successfully.";
            return RedirectToAction("Index"); // looks for action inside the same controller

            // to redirect to another action in another controller we feed the method
            // the controller name ("Action","Controller")
        }
    }
}
