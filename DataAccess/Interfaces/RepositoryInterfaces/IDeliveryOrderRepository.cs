using DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.RepositoryInterfaces
{
    public interface IDeliveryOrderRepository:IBaseRepository<DeliveryOrderModel>
    {
        IEnumerable<DeliveryOrderModel> GetAll();
        void Insert(DeliveryOrderModel model);
        void Update(DeliveryOrderModel model);
        DeliveryOrderModel GetById(int Id);
        void DeleteById(int Id);

    }
}
