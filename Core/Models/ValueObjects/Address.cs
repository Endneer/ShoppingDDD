using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; private set; }
        public int Building { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public Address(string street, int building, string city, string country)
        {
            Street = street ?? throw new ArgumentNullException(nameof(street));
            Building = building;
            City = city ?? throw new ArgumentNullException(nameof(city));
            Country = country ?? throw new ArgumentNullException(nameof(country));
        }
    }
}
