using Core.Models.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class EfCustomersRepository
    {
        private readonly ShoppingContext shoppingContext;

        public EfCustomersRepository(ShoppingContext shoppingContext)
        {
            this.shoppingContext = shoppingContext;
        }
       public void AddCustomer(Customer customer)
        {
            shoppingContext.Add(customer);
            shoppingContext.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return shoppingContext.Customers.ToList();
        }
    }
}
