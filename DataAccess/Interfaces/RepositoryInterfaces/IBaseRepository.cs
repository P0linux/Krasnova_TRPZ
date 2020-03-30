using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.RepositoryInterfaces
{
    public interface IBaseRepository<T> where T: IEntity
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        T GetById(int Id);
        void DeleteById(int Id);

    }
}
