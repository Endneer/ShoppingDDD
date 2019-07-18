using Core.Interfaces;
using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class OrderingService
    {
        private readonly IOrderRepository orderRepository;
        public OrderingService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public void PlaceOrder(Order order)
        {
            orderRepository.AddOrder(order);
        }
    }
}
