using Core.Interfaces;
using Core.Models;
using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly ShoppingContext context;

        public EfOrderRepository(ShoppingContext context)
        {
            this.context = context;
        }
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);

            context.SaveChanges();

         
        }


    }
}
