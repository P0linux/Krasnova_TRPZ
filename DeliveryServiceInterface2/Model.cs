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
        IContainer container;
        public Model(IContainer container)
        {
            this.container = container;
        }
        public TimeSpan GetTime()
        {
            return container.GetShop().GetTime();
        }
        public bool GetStatus()
        {
            return container.GetShop().GetOrderStatus();
        }
        public List<string> GetProducts()
        {
            return container.GetShop().GetProducts();
        }
        public List<string> GetDeliveryPlaces()
        {
            var list = container.GetShop().GetDeliveryPlaces();
            return list;
        }
        public void GetOrder(int number, string product, string deliveryPlace)
        {
            container.GetShop().CreateOrder(number, product, deliveryPlace);
        }
    }
}
