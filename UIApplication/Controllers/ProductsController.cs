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

    public class ProductsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
