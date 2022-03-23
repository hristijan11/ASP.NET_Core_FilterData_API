using Microsoft.AspNetCore.Mvc;
using RentMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMovies.Controllers
{
    public class AccountController : Controller
    {
        [Route("signup")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
