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
    public class TransportRepository: ITransportRepository
    {
        DbSet<TransportModel> _dbSet;
        public TransportRepository(ApplicationContext context)
        {
            _dbSet = context.Set<TransportModel>();
        }
        public void DeleteById(int Id)
        {
            var transportModel = _dbSet.Find(Id);
            if (transportModel != null)
            {
                _dbSet.Remove(transportModel);
            }
        }

        public IEnumerable<TransportModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public TransportModel GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(TransportModel model)
        {
            _dbSet.Add(model);
        }

        public void Update(TransportModel model)
        {
            _dbSet.Update(model);
        }
    }
}

