using Core.Interfaces;
using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    class EfOrderRepository : IOrderRepository
    {
        private readonly ShoppingContext context;
        public EfOrderRepository(ShoppingContext context)
        {
            this.context = context;
        }
        public void AddOrder(Order order)
        {
            context.Customers.Find(order.CustomerId).OrdersIds.Add(order.Id);
            context.SaveChanges();
        }
    }
}
