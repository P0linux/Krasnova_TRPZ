using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityModels
{
    class DeliveryPlaceModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DistanceToShop { get; set; }
    }
}
