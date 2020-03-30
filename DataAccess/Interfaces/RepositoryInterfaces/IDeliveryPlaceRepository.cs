using DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.RepositoryInterfaces
{
    public interface IDeliveryPlaceRepository:IBaseRepository<DeliveryPlaceModel>
    {
        IEnumerable<DeliveryPlaceModel> GetAll();
        void Insert(DeliveryPlaceModel model);
        void Update(DeliveryPlaceModel model);
        DeliveryPlaceModel GetById(int Id);
        void DeleteById(int Id);
    }
}
