using System;

namespace DeliveryService
{
    public class Shop
    {
        IOrderUpdater waitingOrderUpdater;
        IOrderUpdater deliveryOrderUpdater;
        ITimeCounter transportReturnTimeCounter;
        ITimeCounter timeToReadyCounter;
        TransportChooser transportChooser;

        public Shop(IOrderUpdater waitingOrderUpdater, IOrderUpdater deliveryOrderUpdater, ITimeCounter transportReturnTimeCounter,
                    ITimeCounter timeToReadyCounter, TransportChooser transportChooser)
        {
            this.waitingOrderUpdater = waitingOrderUpdater;
            this.deliveryOrderUpdater = deliveryOrderUpdater;
            this.transportReturnTimeCounter = transportReturnTimeCounter;
            this.timeToReadyCounter = timeToReadyCounter;
            this.transportChooser = transportChooser;
        }

        private void GetOrder(Order order)
        {
            ChooseTransport(order);
            if (order.Transport.IsBusy == false) ShopStorage.DeliveryQueue.Add(order);
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
            if (ShopStorage.DeliveryQueue.Count != 0) deliveryOrderUpdater.UpdateOrderList();
            if (ShopStorage.WaitingQueue.Count != 0) waitingOrderUpdater.UpdateOrderList();
        }

        private void CountTime(Order order)
        {
            if (order.Transport.IsBusy == false)
            {
                order.TimeToReady = timeToReadyCounter.CountTime(order); 
                order.Transport.TimeReturnToShop = transportReturnTimeCounter.CountTime(order);
            }
            else
            {
                order.TransportReturnTime = order.Transport.TimeReturnToShop;
            }
        }

        public Order CreateOrder(int number, Product product, DeliveryPlace place)
        {
            Order order = new Order(number, product, place, DateTime.Now);
            GetOrder(order);
            return order;
        }
    }
}
