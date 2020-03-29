using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using DeliveryService.Iterfaces;

namespace DeliveryService
{
    public class ShopContainer : IContainer
    {
        IShop shop;
        ITransportReturnTimeCounter returnTimeCounter;
        ITimeToReadyCounter timeToReadyCounter;
        IDeliveryOrderUpdater deliveryOrderUpdater;
        IWaitingOrderUpdater waitingOrderUpdater;
        TransportChooser transportChooser;
        IDataContainer<Shop> dataContainer;

        public ShopContainer()
        {
            returnTimeCounter = new TransportReturnTimeCounter();
            timeToReadyCounter = new TimeToReadyCounter();
            transportChooser = new TransportChooser();
            deliveryOrderUpdater = new DeliveryOrderUpdater(returnTimeCounter);
            waitingOrderUpdater = new WaitingOrderUpdater(returnTimeCounter, timeToReadyCounter);
            dataContainer = new DataAccessContainer<Shop>();
            IDataAccessController<Shop> dataAccesser = dataContainer.GetDataAccesser();
            //shop = new Shop(waitingOrderUpdater, deliveryOrderUpdater, returnTimeCounter, timeToReadyCounter, transportChooser);
        }
        public IShop GetShop()
        {
            /*IDataAccessController<Shop> dataAccesser = dataContainer.GetDataAccesser();
            shop = new Shop(waitingOrderUpdater, deliveryOrderUpdater, returnTimeCounter, timeToReadyCounter, transportChooser, dataAccesser);*/
            return shop;
        }
    }
}
