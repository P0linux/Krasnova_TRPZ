using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Classes
{
    class ApplicationContext : DbContext
    {
        public DbSet<OrderModel> DeliveryQueue { get; set; }
        public DbSet<OrderModel> WaitingQueue { get; set; }
        public DbSet<TransportModel> Transports { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<DeliveryPlaceModel> DeliveryPlaces { get; set; }
        public DbSet<PriorityModel> Priorities { get; set; }

         
    }
}
