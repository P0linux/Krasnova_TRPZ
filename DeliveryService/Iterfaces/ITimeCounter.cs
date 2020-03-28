using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public interface ITimeCounter
    {
        TimeSpan CountTime(Order order);
    }
}
