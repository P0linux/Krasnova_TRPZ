using DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.RepositoryInterfaces
{
    public interface IPriorityRepository
    {
        IEnumerable<PriorityModel> GetAll();
        void Insert(PriorityModel model);
        void Update(PriorityModel model);
        PriorityModel GetById(int Id);
        void DeleteById(int Id);
    }
}
