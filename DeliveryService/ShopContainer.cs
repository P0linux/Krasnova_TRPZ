using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class ShopContainer : IContainer
    {
        IShop shop;
        ITimeCounter returnTimeCounter;
        ITimeCounter timeToReadyCounter;
        IOrderUpdater deliveryOrderUpdater;
        IOrderUpdater waitingOrderUpdater;
        TransportChooser transportChooser;

        public ShopContainer()
        {
            returnTimeCounter = new TransportReturnTimeCounter();
            timeToReadyCounter = new TimeToReadyCounter();
            transportChooser = new TransportChooser();
            deliveryOrderUpdater = new DeliveryOrderUpdater(returnTimeCounter);
            waitingOrderUpdater = new WaitingOrderUpdater(returnTimeCounter, timeToReadyCounter);
        }
        public IShop GetShop()
        {
            shop = new Shop(waitingOrderUpdater, deliveryOrderUpdater, returnTimeCounter, timeToReadyCounter, transportChooser);
            return shop;
        }
    }
}
