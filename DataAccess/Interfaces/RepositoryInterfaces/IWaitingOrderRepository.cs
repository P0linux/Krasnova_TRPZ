using DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.RepositoryInterfaces
{
    interface IWaitingOrderRepository
    {
        IEnumerable<WaitingOrderModel> GetAll();
        void Insert(WaitingOrderModel model);
        void Update(WaitingOrderModel model);
        WaitingOrderModel GetById(int Id);
        void DeleteById(int Id);
    }
}
