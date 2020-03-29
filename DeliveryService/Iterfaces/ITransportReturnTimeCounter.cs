using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Iterfaces
{
    public interface ITransportReturnTimeCounter
    {
        TimeSpan CountTime(Order order);
    }
}
