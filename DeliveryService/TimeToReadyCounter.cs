using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class TimeToReadyCounter : ITimeCounter
    {
        public TimeSpan CountTime(Order order)
        {
            double timeInHours = order.DeliveryPlace.DistanceToShop / order.Transport.Speed;
            TimeSpan time = TimeSpan.FromHours(timeInHours);
            return JamIndexer.JamImpactIndexing(order, time);
        }        
    }
}
