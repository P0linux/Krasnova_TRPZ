using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceInterface2
{
    interface IModel
    {
        TimeSpan GetTime();
        bool GetStatus();
        List<string> GetProducts();
        List<string> GetDeliveryPlaces();
        void GetOrder(int number, string product, string deliveryPlace);
    }
}
