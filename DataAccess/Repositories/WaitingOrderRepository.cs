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
    public class WaitingOrderRepository : IWaitingOrderRepository
    {
        DbSet<WaitingOrderModel> _dbSet;
        public WaitingOrderRepository(ApplicationContext context)
        {
            _dbSet = context.Set<WaitingOrderModel>();
        }
        public void DeleteById(int Id)
        {
            var orderModel = _dbSet.Find(Id);
            if (orderModel != null)
            {
                _dbSet.Remove(orderModel);
            }
        }

        public IEnumerable<WaitingOrderModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public WaitingOrderModel GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(WaitingOrderModel model)
        {
            _dbSet.Add(model);
        }

        public void Update(WaitingOrderModel model)
        {
            _dbSet.Update(model);
        }
    }
}
