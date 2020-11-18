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
    public class UserControler : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserControler(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public void Create()
        {
            // create user
            return;
        }
    }
}
