using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataContainer<T>
    {
        IDataAccessController<T> GetDataAccesser();
    }
}
