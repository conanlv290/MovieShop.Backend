using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieShop.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MoviesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public void MoviebyGenre(int genreId)
        {
            return;
        }
        public void Details(int movieId)
        {
            return;
        }
    }
}
