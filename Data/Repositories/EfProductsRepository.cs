using Core.Interfaces;
using Core.Models.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data.Repositories
{
    public class EfProductsRepository : IProductsRepository
    {
        private readonly ShoppingContext context;

        public EfProductsRepository(ShoppingContext context)
        {
            this.context = context;
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.Find(id);
             
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

        }
    }
}
