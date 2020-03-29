using DataAccess.Interfaces;
using DataAccess.Interfaces.RepositoryInterfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext context;
        private IPriorityRepository priorityRepository;
        private IDeliveryOrderRepository deliveryOrderRepository;
        private IDeliveryPlaceRepository deliveryPlaceRepository;
        private ITransportRepository transportRepository;
        private IProductRepository productRepository;
        private IWaitingOrderRepository waitingOrderRepository;

        public UnitOfWork(ApplicationContext dbContext)
        {
            context = dbContext;
        }

        public IPriorityRepository PriorityRepository
        {
            get
            {
                return priorityRepository ?? 
                    (priorityRepository = new PriorityRepository(context)); 
            }
        }
        public IDeliveryOrderRepository DeliveryOrderRepository
        {
            get
            {
                return deliveryOrderRepository ?? (deliveryOrderRepository = new DeliveryOrderRepository(context));
            }
        }

        public IDeliveryPlaceRepository DeliveryPlaceRepository
        {
            get
            {
                return deliveryPlaceRepository ??
                    (deliveryPlaceRepository = new DeliveryPlaceRepository(context));
            }
        }

        public ITransportRepository TransportRepository
        {
            get
            {
                return transportRepository ??
                    (transportRepository = new TransportRepository(context));
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return productRepository ??
                    (productRepository = new ProductRepository(context));
            }
        }

        public IWaitingOrderRepository WaitingOrderRepository
        {
            get
            {
                return waitingOrderRepository ??
                    (waitingOrderRepository = new WaitingOrderRepository(context));
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
