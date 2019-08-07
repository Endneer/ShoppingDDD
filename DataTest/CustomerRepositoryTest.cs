using Core.Models.CustomerAggregate;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Linq;
using Xunit;

namespace DataTest
{
    public class CustomerRepositoryTest
    {
        private EfCustomersRepository efCustomerRepository;

        public CustomerRepositoryTest()
        {
            //Arrange
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<ShoppingContext>();
            builder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ShoppingDB;Trusted_Connection=True;");
            this.efCustomerRepository = new EfCustomersRepository(new ShoppingContext(builder.Options));

            efCustomerRepository.AddCustomer(new Customer("Osama", new Core.Models.ValueObjects.Address("Tiba Gardens", 7, "6th Of October", "Egypt"),
                new Core.Models.ValueObjects.PhoneNubmer(11111111111)));

            Assert.NotNull(efCustomerRepository.GetCustomers().FirstOrDefault());
        }
        [Fact]
        public void AddingNewCustomerWithValidData()
        {
            
        }
    }
}
