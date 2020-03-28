using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityModels
{
    class DeliveryOrderModel : IEntity
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public ProductModel Product { get; set; }
        public DeliveryPlaceModel DeliveryPlace { get; set; }
        public DateTime OrderTime { get; set; }
        public TimeSpan TimeToReady { get; set; }
        public TimeSpan TransportReturnTime { get; set; }
        public TransportModel Transport { get; set; }
        public bool IsDelivering { get; set; } = false;
    }
}
