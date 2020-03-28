using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityModels
{
    class PriorityModel : IEntity
    {
        public int Id { get; set; }
        public int ProductModelId { get; set; }
        public int TransportModelId { get; set; }
        public ProductModel ProductModel { get; set; }
        public TransportModel TransportModel { get; set; }
        public int PriorityNumber { get; set; }
    }
}
