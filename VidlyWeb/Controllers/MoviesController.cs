using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyWeb.Models;
using VidlyWeb.ViewModels;

namespace VidlyWeb.Controllers
{
    public class MoviesController : Controller
    {
        // To have applicationDbContext work with the database
        private readonly ApplicationDbContext _db;

        public MoviesController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _db.Movies;
            return View(movies);
        }

        public IActionResult Details(int? id)
        {
            if (id is null or 0) return NotFound();

            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken] // not required
        public IActionResult Create(Movie obj)
        {
            //if (!ModelState.IsValid) // Is tested in client
            //{
            //    return View(obj);
            //}
            _db.Movies.Add(obj); // not saved to the database
            _db.SaveChanges(); // saved to the database
            TempData["success"] = "Movie Created Successfully.";
            return RedirectToAction("Index"); // looks for action inside the same controller

            // to redirect to another action in another controller we feed the method
            // the controller name ("Action","Controller")
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var movie = _db.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null) return NotFound();

            return View(movie);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken] // not required
        public IActionResult Edit(Movie obj)
        {
            //if (!ModelState.IsValid) // Is tested in client
            //{
            //    return View(obj);
            //}
            _db.Movies.Update(obj); // not saved to the database
            _db.SaveChanges(); // saved to the database
            TempData["success"] = "Customer Edited Successfully.";
            return RedirectToAction("Index"); // looks for action inside the same controller

            // to redirect to another action in another controller we feed the method
            // the controller name ("Action","Controller")
        }
    }
}
