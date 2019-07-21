using Core.Models.OrderAggregate;
using Core.Models.ValueObjects;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.CustomerAggregate
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNubmer PhoneNubmer { get; private set; }
        public List<Order> Orders { get; private set; }
        private Customer() : base(Guid.NewGuid())
        {

        }
        public Customer(string name, Address address, PhoneNubmer phoneNubmer) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            PhoneNubmer = phoneNubmer ?? throw new ArgumentNullException(nameof(phoneNubmer));
        }
    }
}
