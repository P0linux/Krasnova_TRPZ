using DeliveryService.Iterfaces;
using DeliveryService.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class WaitingOrderUpdater : IWaitingOrderUpdater
    {
        ITransportReturnTimeCounter ReturnTimeCounter;
        ITimeToReadyCounter TimeToReadyCounter;
        WaitingOrderService waitingOrderService;
        DeliveryOrderService deliveryOrderService;
        TransportService transportService;
        public WaitingOrderUpdater(ITransportReturnTimeCounter returnTimeCounter, ITimeToReadyCounter timeCounter, WaitingOrderService waitingOrderService, DeliveryOrderService deliveryOrderService, TransportService transportService)
        {
            ReturnTimeCounter = returnTimeCounter;
            TimeToReadyCounter = timeCounter;
            this.waitingOrderService = waitingOrderService;
            this.deliveryOrderService = deliveryOrderService;
            this.transportService = transportService;
        }
        public void UpdateWaitingOrder(Order order)
        {
            order.TransportReturnTime = order.Transport.TimeReturnToShop;
            waitingOrderService.Update(order);
        }

        public void UpdateWaitingOrderList()
        {
            foreach (Order ord in ShopStorage.WaitingQueue)
            {
                UpdateWaitingOrder(ord);
                if (ord.Transport.IsBusy == false)
                {
                    waitingOrderService.DeleteById(ord.Id);
                    deliveryOrderService.Add(ord);
                    //ShopStorage.WaitingQueue.Remove(ord);
                    //ShopStorage.DeliveryQueue.Add(ord);
                    ord.TimeToReady = TimeToReadyCounter.CountTime(ord);
                    ord.TransportReturnTime = ReturnTimeCounter.CountTime(ord);
                    ord.Transport.IsBusy = true;
                    ord.IsDelivering = true;
                    deliveryOrderService.Update(ord);
                    transportService.Update(ord.Transport);
                    break;
                }
            }
        }
    }
}
