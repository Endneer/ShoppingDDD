using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.ProductAggregate
{
    public class Product : Entity<Guid>
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        private Product() : base(Guid.NewGuid())
        {

        }

        public Product(string name, int quantity, double price) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Quantity = quantity;
            Price = price;
        }

        public void IncreaseQuantity(int increaseQuantity)
        {
            if (increaseQuantity > 0)
                this.Quantity += increaseQuantity;
            else
                throw new ArgumentOutOfRangeException(nameof(increaseQuantity));
        }
    }
}
