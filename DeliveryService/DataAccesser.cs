using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    class DataAccesser<Shop>
    {
        IDataAccessController<Shop> dataAccessController;
        public DataAccesser(IDataAccessController<Shop> dataAccessController)
        {
            this.dataAccessController = dataAccessController;
        }

        public void SetData(Shop obj)
        {
            dataAccessController.SetInformation(obj);
        }

        public Shop GetData()
        {
            return dataAccessController.GetInformation();
        }
    }
}
