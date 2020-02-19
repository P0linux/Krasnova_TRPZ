using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DataAccessContainer<T> : IDataContainer<T>
    {
        IDataAccessController<T> dataAccessController;
        public IDataAccessController<T> GetDataAccesser()
        {
            dataAccessController = new DataAccessController<T>(new XMLSerializer<T>(typeof(T)));
            return dataAccessController;
        }
    }
}
