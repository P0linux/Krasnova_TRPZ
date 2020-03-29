using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public interface ITimeToReadyCounter
    {
        TimeSpan CountTime(Order order);
    }
}
