using DataAccess.EntityModels;
using DataAccess.Interfaces.RepositoryInterfaces;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    class DeliveryPlaceRepository : IDeliveryPlaceRepository
    {
        DbSet<DeliveryPlaceModel> _dbSet;
        public DeliveryPlaceRepository(ApplicationContext context)
        {
            _dbSet = context.Set<DeliveryPlaceModel>();
        }
        public void DeleteById(int Id)
        {
            var DeliveryPlaceModel = _dbSet.Find(Id);
            if (DeliveryPlaceModel != null)
            {
                _dbSet.Remove(DeliveryPlaceModel);
            }
        }

        public IEnumerable<DeliveryPlaceModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public DeliveryPlaceModel GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(DeliveryPlaceModel model)
        {
            _dbSet.Add(model);
        }

        public void Update(DeliveryPlaceModel model)
        {
            _dbSet.Update(model);
        }
    }
}
