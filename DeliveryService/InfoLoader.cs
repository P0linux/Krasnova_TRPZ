using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public static class InfoLoader
    {
        public static void LoadInfo()
        {
            Product p1 = new Product("Meat", 2, 3, "Chicken");
            Product p2 = new Product("Fish", 3, 3, "Salmon");

            ShopStorage.AvailableProducts.Add(p1);
            ShopStorage.AvailableProducts.Add(p2);

            Transport t1 = new Transport("Truck", 20, "Truck1", 20, 15, true);
            Transport t2 = new Transport("Byke", 20, "Byke1", 4, 2, false);

            ShopStorage.AllTransport.Add(t1);
            ShopStorage.AllTransport.Add(t2);

            DeliveryPlace d1 = new DeliveryPlace("Kyiv", 20);
            DeliveryPlace d2 = new DeliveryPlace("Harkiv", 40);

            ShopStorage.DeliveryPlaces.Add(d1);
            ShopStorage.DeliveryPlaces.Add(d2);

            ShopStorage.jamImpactIndexes.Add(new ShopStorage.JamInterval { startTime = new TimeSpan(6, 0, 0), endTime = new TimeSpan(7, 0, 0) }, 2);
            ShopStorage.jamImpactIndexes.Add(new ShopStorage.JamInterval { startTime = new TimeSpan(18, 0, 0), endTime = new TimeSpan(19, 0, 0) }, 4);

            p1.availableTransport.Add(t1);
            p1.availableTransport.Add(t2);

            p1.TransportPriority.Add(t1, 1);
            p1.TransportPriority.Add(t2, 2);

            p2.availableTransport.Add(t1);
            p2.TransportPriority.Add(t1, 1);

        }



    }
}
