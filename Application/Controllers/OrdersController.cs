using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.OrderAggregate;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderingService orderingService;

        public OrdersController(OrderingService orderingService)
        {
            this.orderingService = orderingService;
        }
        [HttpPost]
        public IActionResult AddOrder(Order order) {
            orderingService.PlaceOrder(order);
            return Ok(order);

        }
    }
}