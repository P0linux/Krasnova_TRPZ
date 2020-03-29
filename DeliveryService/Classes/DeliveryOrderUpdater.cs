using DeliveryService.Iterfaces;
using DeliveryService.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class DeliveryOrderUpdater : IDeliveryOrderUpdater
    {
        public ITransportReturnTimeCounter ReturnTimeCounter { get; set; }
        private DateTime currentTime;
        DeliveryOrderService deliveryOrderService;
        TransportService transportService;

        public DeliveryOrderUpdater(ITransportReturnTimeCounter timeCounter, DeliveryOrderService deliveryOrderService, TransportService transportService)
        {
            ReturnTimeCounter = timeCounter;
            this.deliveryOrderService = deliveryOrderService;
            this.transportService = transportService;
        }

        public void UpdateDeliveryOrder(Order order)
        {
            TimeSpan newTimeToReady = order.TimeToReady - (currentTime - order.OrderTime);
            order.TimeToReady = newTimeToReady;
            TimeSpan newTransportReturnTime = ReturnTimeCounter.CountTime(order);
            order.Transport.TimeReturnToShop = newTransportReturnTime;
            deliveryOrderService.Update(order);
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
                deliveryOrderService.DeleteById(ord.Id);
                //ShopStorage.DeliveryQueue.Remove(ord);
                ord.Transport.IsBusy = false;
                transportService.Update(ord.Transport);

            }
        }
    }
}
