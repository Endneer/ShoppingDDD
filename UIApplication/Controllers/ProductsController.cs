using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Models.OrderAggregate;
using Core.Models.ProductAggregate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using UIApplication.Models;
using UIApplication.Services;

namespace UIApplication.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApiClient apiClient;

        public ProductsController(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public List<Product> GetProducts()
        {
            return apiClient.GetProducts().Result;
        }

        public void OrderOneItem([FromBody]Product product)
        {
            //Need a way to link customer with the logged in user
            //Azure B2C
            //return apiClient.Order(new Order())
        }

    }
}
