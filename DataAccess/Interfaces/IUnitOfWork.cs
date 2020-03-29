using DataAccess.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IPriorityRepository PriorityRepository { get; }
        IDeliveryOrderRepository DeliveryOrderRepositoryRepository { get; }
        IDeliveryPlaceRepository DeliveryPlaceRepository { get; }
        ITransportRepository TransportRepository { get; }
        IProductRepository ProductRepository { get; }
        IWaitingOrderRepository WaitingOrderRepository { get; }
        void Commit();
    }
}
