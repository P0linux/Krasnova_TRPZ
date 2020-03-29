using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Iterfaces
{
    public interface IDeliveryOrderUpdater
    {
        void UpdateDeliveryOrderList();
        void UpdateDeliveryOrder(Order order);
    }
}
