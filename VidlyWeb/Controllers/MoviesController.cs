using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Details()
        {

        }
    }
}
