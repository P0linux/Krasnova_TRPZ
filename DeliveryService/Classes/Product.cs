using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public class Product
    {
        public string Type { get; set; } 
        public int Size { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public List<Transport> availableTransport { get; set; } = new List<Transport>();
        public Dictionary<Transport, int> TransportPriority { get; set; } = new Dictionary<Transport, int>();

        public Product(string type, int size, int weight, string name)
        {
            Type = type;
            Size = size;
            Weight = weight;
            Name = name;
        }

    }
}
