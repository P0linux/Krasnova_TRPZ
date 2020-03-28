using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public Product Product { get; set; }
        public DeliveryPlace DeliveryPlace { get; set; }
        public DateTime OrderTime { get; set; }
        public TimeSpan TimeToReady { get; set; } = TimeSpan.Zero;
        public TimeSpan TransportReturnTime { get; set; } = TimeSpan.Zero;
        public Transport Transport { get; set; } = null;
        public bool IsDelivering { get; set; } = false;

        public Order(int orderNumber, Product product, DeliveryPlace deliveryPlace, DateTime orderTime)
        {
            OrderNumber = orderNumber;
            Product = product;
            DeliveryPlace = deliveryPlace;
            OrderTime = orderTime;
        }

    }
}
