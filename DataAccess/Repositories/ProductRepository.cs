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
    class ProductRepository: IProductRepository
    {
        DbSet<ProductModel> _dbSet;
        public ProductRepository(ApplicationContext context)
        {
            _dbSet = context.Set<ProductModel>();
        }
        public void DeleteById(int Id)
        {
            var productModel = _dbSet.Find(Id);
            if (productModel != null)
            {
                _dbSet.Remove(productModel);
            }
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public ProductModel GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(ProductModel model)
        {
            _dbSet.Add(model);
        }

        public void Update(ProductModel model)
        {
            _dbSet.Update(model);
        }
    }
}
