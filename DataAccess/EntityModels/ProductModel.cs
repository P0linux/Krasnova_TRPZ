using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityModels
{
    class ProductModel : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public ICollection<TransportModel> availableTransport { get; set; }
        //public Dictionary<TransportModel, int> TransportPriority { get; set; }
    }
}
