using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.UnitOfWork
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<DeliveryOrderModel> DeliveryOrderModels { get; set; }
        public DbSet<WaitingOrderModel> WaitingOrderModel { get; set; }
        public DbSet<TransportModel> TransportModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<DeliveryPlaceModel> DeliveryPlaceModels { get; set; }
        public DbSet<PriorityModel> PriorityModels { get; set; }
    }
}
