using Core.Models.ProductAggregate;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.OrderAggregate
{
    public class OrderItem : Entity<Guid>
    {
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
        private OrderItem() : base(Guid.NewGuid())
        {

        }

        public OrderItem(int quantity, Guid productId) : this()
        {
            Quantity = quantity;
            ProductId = productId;
        }
    }
}
