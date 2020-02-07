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
            return JamImpactIndexing(order, time);
        }

        public TimeSpan JamImpactIndexing(Order order, TimeSpan time)
        {
            foreach (KeyValuePair<ShopStorage.JamInterval, double> keyValue in ShopStorage.jamImpactIndexes)
            {
                if (order.OrderTime > order.OrderTime.Date.Add(keyValue.Key.startTime) &&
                    order.OrderTime < order.OrderTime.Date.Add(keyValue.Key.endTime) &&
                    order.Transport.JamImpact == true)

                    time += TimeSpan.FromHours(keyValue.Value);
            }
            return time;
        }

        
    }
}
