using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Classes
{
    class Priority
    {
        public int Id { get; set; }
        public int ProductModelId { get; set; }
        public int TransportModelId { get; set; }
        public Product Product { get; set; }
        public Transport Transport { get; set; }
        public int PriorityNumber { get; set; }
    }
}
