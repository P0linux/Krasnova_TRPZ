using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public interface IOrderUpdater
    {
        void UpdateOrderList();
        void UpdateOrder(Order order);
    }
}
