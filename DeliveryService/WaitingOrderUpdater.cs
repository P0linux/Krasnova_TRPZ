using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class WaitingOrderUpdater : IOrderUpdater
    {
        
        public WaitingOrderUpdater()
        {

        }
        public void UpdateOrder(Order order)
        {
            order.TransportReturnTime = order.Transport.TimeReturnToShop;
        }

        public void UpdateOrderList()
        {
            foreach (Order ord in ShopStorage.WaitingQueue)
            {
                UpdateOrder(ord);
                if (ord.Transport.IsBusy == false)
                {
                    ShopStorage.WaitingQueue.Remove(ord);
                    ShopStorage.DeliveryQueue.Add(ord);
                    // PLACE AN ORDER
                    break;
                }
            }
        }
    }
}
