using Core.Models.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IProductsRepository
    {
        Product GetProductById(Guid id);
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        void AddProduct(Product product);
    }
}
