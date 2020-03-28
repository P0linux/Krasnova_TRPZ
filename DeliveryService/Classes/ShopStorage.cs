using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public static class ShopStorage
    {
        public static List<Product> AvailableProducts { get; set; } = new List<Product>();
        public static List<Transport> AllTransport { get; set; } = new List<Transport>();
        public static List<DeliveryPlace> DeliveryPlaces { get; set; } = new List<DeliveryPlace>();
        public static Dictionary<JamInterval, double> jamImpactIndexes { get; set; } = new Dictionary<JamInterval, double>();
        public static List<Order> DeliveryQueue { get; set; } = new List<Order>();
        public static List<Order> WaitingQueue { get; set; } = new List<Order>();

        public struct JamInterval
        {
            public TimeSpan startTime;
            public TimeSpan endTime;
        }
    }
}
