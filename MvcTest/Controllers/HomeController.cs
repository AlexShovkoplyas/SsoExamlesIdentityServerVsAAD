using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcTest.Models;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        ////[Authorize(AuthenticationSchemes = "cookie1")]
        [Authorize(AuthenticationSchemes = "cookie2")]
        //[Authorize(AuthenticationSchemes = "cookie1, cookie2")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
