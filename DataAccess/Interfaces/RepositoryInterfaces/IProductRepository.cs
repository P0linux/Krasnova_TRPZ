using DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.RepositoryInterfaces
{
    interface IProductRepository
    {
        IEnumerable<ProductModel> GetAll();
        void Insert(ProductModel model);
        void Update(ProductModel model);
        ProductModel GetById(int Id);
        void DeleteById(int Id);
    }
}
