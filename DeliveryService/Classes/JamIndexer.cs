using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public static class JamIndexer
    {
        public static TimeSpan JamImpactIndexing(Order order, TimeSpan time)
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
