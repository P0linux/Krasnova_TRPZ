using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public interface IShop
    {
        void CreateOrder(int number, string product, string place);
        TimeSpan GetTime();
        bool GetOrderStatus();
        List<string> GetProducts();
        List<string> GetDeliveryPlaces();
    }
}
