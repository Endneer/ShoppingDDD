using Core.Models.ValueObjects;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.OrderAggregate
{
    public class Order : Entity<Guid>
    {
        public Guid CustomerId { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        private Order() : base(Guid.NewGuid())
        {

        }

        public Order(Guid customerId, List<OrderItem> orderItems) : this()
        {
            CustomerId = customerId;
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));
        }
    }
}
