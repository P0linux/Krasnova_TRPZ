using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class DeliveryPlace
    {
        public string Name { get; set; }
        public double DistanceToShop { get; set; }

        public DeliveryPlace(string name, double distanceToShop)
        {
            Name = name;
            DistanceToShop = distanceToShop;
        }
    }
}
