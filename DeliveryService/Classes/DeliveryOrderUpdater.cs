using DeliveryService.Iterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class DeliveryOrderUpdater : IDeliveryOrderUpdater
    {
        public ITransportReturnTimeCounter ReturnTimeCounter { get; set; }
        private DateTime currentTime;

        public DeliveryOrderUpdater(ITransportReturnTimeCounter timeCounter)
        {
            ReturnTimeCounter = timeCounter;
        }

        public void UpdateDeliveryOrder(Order order)
        {
            TimeSpan newTimeToReady = order.TimeToReady - (currentTime - order.OrderTime);
            order.TimeToReady = newTimeToReady;
            TimeSpan newTransportReturnTime = ReturnTimeCounter.CountTime(order);
            order.Transport.TimeReturnToShop = newTransportReturnTime;
        }

        public void UpdateDeliveryOrderList()
        {
            currentTime = DateTime.Now;
            List<Order> toRemove = new List<Order>();
            foreach (Order ord in ShopStorage.DeliveryQueue)
            {
                UpdateDeliveryOrder(ord);
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
