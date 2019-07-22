using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models.ProductAggregate;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
           return productsRepository.GetProducts();
        }


        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            productsRepository.AddProduct(product);
            return Ok();
        }

  

    }
}