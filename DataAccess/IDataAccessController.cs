using System;

namespace DataAccess
{
    public interface IDataAccessController<T>
    {
        void SetInformation(T obj);
        T GetInformation();
    }
}
