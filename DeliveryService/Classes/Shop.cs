using DataAccess;
using DeliveryService.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService
{
    public class Shop : IShop
    {
        Order order;
        IWaitingOrderUpdater waitingOrderUpdater;
        IDeliveryOrderUpdater deliveryOrderUpdater;
        ITransportReturnTimeCounter transportReturnTimeCounter;
        ITimeToReadyCounter timeToReadyCounter;
        TransportChooser transportChooser;
      
        public Shop(IWaitingOrderUpdater waitingOrderUpdater, IDeliveryOrderUpdater deliveryOrderUpdater, ITransportReturnTimeCounter transportReturnTimeCounter,
                    ITimeToReadyCounter timeToReadyCounter, TransportChooser transportChooser)
        {
            this.waitingOrderUpdater = waitingOrderUpdater;
            this.deliveryOrderUpdater = deliveryOrderUpdater;
            this.transportReturnTimeCounter = transportReturnTimeCounter;
            this.timeToReadyCounter = timeToReadyCounter;
            this.transportChooser = transportChooser;
            InfoLoader.LoadInfo();
        }

        private void GetOrder(Order order)
        {
            ChooseTransport(order);
            if (order.IsDelivering == true)
            {
                ShopStorage.DeliveryQueue.Add(order);
            } 
            else ShopStorage.WaitingQueue.Add(order);
            CountTime(order);
            UpdateOrders();
        }

        private void ChooseTransport(Order order)
        {
            transportChooser.ChooseTransport(order);
        }

        private void UpdateOrders()
        {
            if (ShopStorage.DeliveryQueue.Count != 0) deliveryOrderUpdater.UpdateDeliveryOrderList();
            if (ShopStorage.WaitingQueue.Count != 0) waitingOrderUpdater.UpdateWaitingOrderList();
        }

        private void CountTime(Order order)
        {
            if (order.IsDelivering == true)
            {
                order.TimeToReady = timeToReadyCounter.CountTime(order); 
                order.Transport.TimeReturnToShop = transportReturnTimeCounter.CountTime(order);
            }
            else
            {
                order.TransportReturnTime = order.Transport.TimeReturnToShop;
            }
        }

        public void CreateOrder(int number, string productName, string placeName)
        {
            var product = ShopStorage.AvailableProducts.Where(p => p.Name == productName).First();
            var place = ShopStorage.DeliveryPlaces.Where(p => p.Name == placeName).First();
            order = new Order(number, product as Product, place as DeliveryPlace, DateTime.Now);
            GetOrder(order);
            //return order;
        }

        public TimeSpan GetTime()
        {
            if (order.IsDelivering) return order.TimeToReady;
            else return order.TransportReturnTime;
        }

        public bool GetOrderStatus()
        {
            return order.IsDelivering;
        }

        public List<string> GetProducts()
        {
            return ShopStorage.AvailableProducts.Select(p => p.Name).ToList();
        }

        public List<string> GetDeliveryPlaces()
        {
            var list = ShopStorage.DeliveryPlaces.Select(p => p.Name).ToList();
            return list;
        }
    }
}
