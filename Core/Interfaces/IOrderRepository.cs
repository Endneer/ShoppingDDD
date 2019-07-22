using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);


    }
}
