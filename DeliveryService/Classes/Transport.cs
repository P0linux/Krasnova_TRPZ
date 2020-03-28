using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class Transport
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Speed { get; set; }
        public string Name { get; set; }
        public int MaxWeight { get; set; }
        public int MaxSize { get; set; }
        public bool JamImpact { get; set; }
        public TimeSpan TimeReturnToShop { get; set; } = TimeSpan.Zero;
        public bool IsBusy { get; set; } = false;

        public Transport(string type, double speed, string name, int maxWeight, int maxSize, bool jamImpact)
        {
            Type = type;
            Speed = speed;
            Name = name;
            MaxWeight = maxWeight;
            MaxSize = maxSize;
            JamImpact = jamImpact;
        }


    }
}
