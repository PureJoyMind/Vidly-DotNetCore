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
    }
}
