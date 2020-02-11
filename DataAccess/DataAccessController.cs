using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class DataAccessController<T> : IDataAccessController<T>
    {
        ISerializer<T> serializer;
        public DataAccessController(ISerializer<T> serializer)
        {
            this.serializer = serializer;
        }
        public T GetInformation()
        {
            return serializer.Deserialize(Properties.Resources.SerializedData);
        }

        public void SetInformation(T obj)
        {
            serializer.Serialize(obj, Properties.Resources.SerializedData);
        }
    }
}
