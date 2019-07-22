using Core.Interfaces;
using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Core.Services
{
    public class OrderingService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductsRepository productsRepository;

        public OrderingService(IOrderRepository orderRepository, IProductsRepository productsRepository)
        {
            this.orderRepository = orderRepository;
            this.productsRepository = productsRepository;
        }

        public void PlaceOrder(Order order)
        {
            var guid=  productsRepository.GetProducts().FirstOrDefault().Id;

            var newItem = new OrderItem(2, guid);

            order.OrderItems.Add(newItem);



            orderRepository.AddOrder(order);

            foreach (var orderItem in order.OrderItems)
            {

                var products = productsRepository.GetProducts().Where(id => id.Id == orderItem.Id);

                foreach (var product in products)
                {
                    product.DeductQuantity(product.Quantity);
                    productsRepository.UpdateProduct(product);
                }
            }

        }
    }
}
