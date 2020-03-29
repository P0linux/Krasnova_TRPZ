using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService;

namespace DeliveryServiceInterface2
{
    class Model:IModel
    {
        IShop shop;
        public Model(IShop shop)
        {
            this.shop = shop;
        }
        public TimeSpan GetTime()
        {
            return shop.GetTime();
        }
        public bool GetStatus()
        {
            return shop.GetOrderStatus();
        }
        public List<string> GetProducts()
        {
            return shop.GetProducts();
        }
        public List<string> GetDeliveryPlaces()
        {
            var list = shop.GetDeliveryPlaces();
            return list;
        }
        public void GetOrder(int number, string product, string deliveryPlace)
        {
            shop.CreateOrder(number, product, deliveryPlace);
        }
    }
}
