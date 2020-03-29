using DeliveryService.Iterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class TransportReturnTimeCounter : ITransportReturnTimeCounter
    {
        public TimeSpan CountTime(Order order)
        {
            TimeSpan timeToReturnToShop = TimeSpan.FromHours(order.DeliveryPlace.DistanceToShop / order.Transport.Speed);
            return JamIndexer.JamImpactIndexing(order, timeToReturnToShop) + order.TimeToReady;
        }
    }
}
