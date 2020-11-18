using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.Web.Models;
namespace MovieShop.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public GenreController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // return all generes
            return View();
        }
    }
}
