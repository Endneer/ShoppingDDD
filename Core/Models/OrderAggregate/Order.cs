using Core.Models.CustomerAggregate;
using Core.Models.ValueObjects;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models.OrderAggregate
{
    public class Order : Entity<Guid>
    {
        public Guid CustomerId { get; private set; }
        //public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; private set; }

        private Order() : base(Guid.NewGuid())
        {
            OrderItems = new List<OrderItem>();
        }

        public Order(Guid customerId, List<OrderItem> orderItems) : this()
        {
            CustomerId = customerId;
            OrderItems = orderItems ?? new List<OrderItem>();
        }
    }
}
