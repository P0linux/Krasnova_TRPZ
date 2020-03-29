using DeliveryService.Iterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class WaitingOrderUpdater : IWaitingOrderUpdater
    {
        ITransportReturnTimeCounter ReturnTimeCounter;
        ITimeToReadyCounter TimeToReadyCounter;
        public WaitingOrderUpdater(ITransportReturnTimeCounter returnTimeCounter, ITimeToReadyCounter timeCounter)
        {
            ReturnTimeCounter = returnTimeCounter;
            TimeToReadyCounter = timeCounter;
        }
        public void UpdateWaitingOrder(Order order)
        {
            order.TransportReturnTime = order.Transport.TimeReturnToShop;
        }

        public void UpdateWaitingOrderList()
        {
            foreach (Order ord in ShopStorage.WaitingQueue)
            {
                UpdateWaitingOrder(ord);
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
