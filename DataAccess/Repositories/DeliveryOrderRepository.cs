using DataAccess.UnitOfWork;
using DataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Interfaces.RepositoryInterfaces;

namespace DataAccess.Repositories
{
    public class DeliveryOrderRepository : IDeliveryOrderRepository
    {
        DbSet<DeliveryOrderModel> _dbSet;

        public DeliveryOrderRepository(ApplicationContext context)
        {
            _dbSet = context.Set<DeliveryOrderModel>();
        }

        public IEnumerable<DeliveryOrderModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Insert(DeliveryOrderModel model)
        {
            _dbSet.Add(model);
        }

        public void Update(DeliveryOrderModel model)
        {
            _dbSet.Update(model);
        }

        public DeliveryOrderModel GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void DeleteById(int Id)
        {
            var orderModel = _dbSet.Find(Id);
            if (orderModel != null)
            {
                _dbSet.Remove(orderModel);
            }
        }
    }
}
