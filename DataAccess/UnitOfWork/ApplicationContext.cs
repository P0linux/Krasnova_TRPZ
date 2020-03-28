using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.UnitOfWork
{
    class ApplicationContext : DbContext
    {
        public DbSet<DeliveryOrderModel> DeliveryQueue { get; set; }
        public DbSet<WaitingOrderModel> WaitingQueue { get; set; }
        public DbSet<TransportModel> Transports { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<DeliveryPlaceModel> DeliveryPlaces { get; set; }
        public DbSet<PriorityModel> Priorities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DeliveryService;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
