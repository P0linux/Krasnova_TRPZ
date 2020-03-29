using DataAccess;
using DeliveryService.Iterfaces;
using DeliveryService.Services;
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
        InfoLoader loader;
        ProductService productService;
        DeliveryPlaceService deliveryPlaceService;
        DeliveryOrderService deliveryOrderService;
        WaitingOrderService waitingOrderService;


        public Shop(IWaitingOrderUpdater waitingOrderUpdater, IDeliveryOrderUpdater deliveryOrderUpdater, ITransportReturnTimeCounter transportReturnTimeCounter,
                    ITimeToReadyCounter timeToReadyCounter, TransportChooser transportChooser, InfoLoader loader, ProductService productService, DeliveryPlaceService deliveryPlaceService,
                    DeliveryOrderService deliveryOrderService, WaitingOrderService waitingOrderService)
        {
            this.waitingOrderUpdater = waitingOrderUpdater;
            this.deliveryOrderUpdater = deliveryOrderUpdater;
            this.transportReturnTimeCounter = transportReturnTimeCounter;
            this.timeToReadyCounter = timeToReadyCounter;
            this.transportChooser = transportChooser;
            this.loader = loader;
            this.productService = productService;
            this.deliveryPlaceService = deliveryPlaceService;
            this.waitingOrderService = waitingOrderService;
            this.deliveryOrderService = deliveryOrderService;
            loader.LoadInfo();
        }

        private void GetOrder(Order order)
        {
            ChooseTransport(order);
            if (order.IsDelivering == true)
            {
                deliveryOrderService.Add(order);
                //ShopStorage.DeliveryQueue.Add(order);
            }
            else /*ShopStorage.WaitingQueue.Add(order);*/ waitingOrderService.Add(order);
            CountTime(order);
            UpdateOrders();
        }

        private void ChooseTransport(Order order)
        {
            transportChooser.ChooseTransport(order);
        }

        private void UpdateOrders()
        {
            if (/*ShopStorage.DeliveryQueue.Count != 0*/ deliveryOrderService.GetAll().Count != 0) deliveryOrderUpdater.UpdateDeliveryOrderList();
            if (/*ShopStorage.WaitingQueue.Count != 0*/ waitingOrderService.GetAll().Count != 0) waitingOrderUpdater.UpdateWaitingOrderList();
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
            //var product = ShopStorage.AvailableProducts.Where(p => p.Name == productName).First();
            //var place = ShopStorage.DeliveryPlaces.Where(p => p.Name == placeName).First();
            var product = productService.GetAll().Where(p => p.Name == productName).First();
            var place = deliveryPlaceService.GetAll().Where(p => p.Name == placeName).First();
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
            var products = productService.GetAll().Select(p => p.Name).ToList();
            return products;
            //return ShopStorage.AvailableProducts.Select(p => p.Name).ToList();
        }

        public List<string> GetDeliveryPlaces()
        {
            var deliveryPlaces = deliveryPlaceService.GetAll().Select(d => d.Name).ToList();
            return deliveryPlaces;
            //var list = ShopStorage.DeliveryPlaces.Select(p => p.Name).ToList();
            //return list;
        }
    }
}
