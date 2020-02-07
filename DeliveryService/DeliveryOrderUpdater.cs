using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    class DeliveryOrderUpdater : IOrderUpdater
    {
        private ITimeCounter ReturnTimeCounter;
        private DateTime currentTime;
        public DeliveryOrderUpdater(ITimeCounter timeCounter)
        {
            ReturnTimeCounter = timeCounter;
        }
        public void UpdateOrder(Order order)
        {
            TimeSpan newTimeToReady = order.TimeToReady - (currentTime - order.OrderTime);
            order.TimeToReady = newTimeToReady;
            TimeSpan newTransportReturnTime = ReturnTimeCounter.CountTime(order);
            order.Transport.TimeReturnToShop = newTransportReturnTime;
        }

        public void UpdateOrderList()
        {
            currentTime = DateTime.Now;
            List<Order> toRemove = new List<Order>();
            foreach (Order ord in ShopStorage.DeliveryQueue)
            {
                UpdateOrder(ord);
                if (ord.TimeToReady.TotalHours <= 0) toRemove.Add(ord);
            }
            foreach (Order ord in toRemove)
            {
                ShopStorage.DeliveryQueue.Remove(ord);
                ord.Transport.IsBusy = false;
            }
        }
    }
}
