using DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.RepositoryInterfaces
{
    interface ITransportRepository
    {
        IEnumerable<TransportModel> GetAll();
        void Insert(TransportModel model);
        void Update(TransportModel model);
        TransportModel GetById(int Id);
        void DeleteById(int Id);
    }
}
