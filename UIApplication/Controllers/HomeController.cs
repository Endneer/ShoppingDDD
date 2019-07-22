using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using UIApplication.Models;

namespace UIApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<Product>() { new Product("Chai", 10, 4.4) });
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
