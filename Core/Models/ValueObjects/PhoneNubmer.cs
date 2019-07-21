using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Models.ValueObjects
{
    [Owned]
    public class PhoneNubmer
    {
        public long Number { get; private set; }
        public PhoneNubmer(long number)
        {
            if (Regex.IsMatch(number.ToString(), "^(\\d){11}$"))
                Number = number;
            else
                throw new ArgumentException("Phone number must be nine digits");
        }
    }
}
