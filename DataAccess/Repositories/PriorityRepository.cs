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
    public class PriorityRepository : IPriorityRepository
    {
        DbSet<PriorityModel> _dbSet;
        public PriorityRepository(ApplicationContext context)
        {
            _dbSet = context.Set<PriorityModel>();
        }
        public void DeleteById(int Id)
        {
            var priorityModel = _dbSet.Find(Id);
            if (priorityModel != null)
            {
                _dbSet.Remove(priorityModel);
            }
        }

        public IEnumerable<PriorityModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public PriorityModel GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(PriorityModel model)
        {
            _dbSet.Add(model);
        }

        public void Update(PriorityModel model)
        {
            _dbSet.Update(model);
        }
    }
}
