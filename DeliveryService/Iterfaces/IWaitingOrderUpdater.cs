using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public interface IWaitingOrderUpdater
    {
        void UpdateWaitingOrderList();
        void UpdateWaitingOrder(Order order);
    }
}
