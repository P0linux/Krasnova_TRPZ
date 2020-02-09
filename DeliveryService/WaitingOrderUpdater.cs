using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class WaitingOrderUpdater : IOrderUpdater
    {
        ITimeCounter ReturnTimeCounter;
        ITimeCounter TimeToReadyCounter;
        public WaitingOrderUpdater(ITimeCounter returnTimeCounter, ITimeCounter timeCounter)
        {
            ReturnTimeCounter = returnTimeCounter;
            TimeToReadyCounter = timeCounter;
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
                    ord.TimeToReady = TimeToReadyCounter.CountTime(ord);
                    ord.TransportReturnTime = ReturnTimeCounter.CountTime(ord);
                    ord.Transport.IsBusy = true;
                    ord.IsDelivering = true;
                    break;
                }
            }
        }
    }
}
