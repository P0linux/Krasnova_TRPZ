using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryService
{
    public class TransportChooser
    {
        public void ChooseTransport(Order order)
        {
            List<Transport> productAvailableTransport = order.Product.availableTransport;
            var suitableTransport = ShopStorage.AllTransport.Where(t => productAvailableTransport.Contains(t) && t.IsBusy == false).ToList();

            if (suitableTransport == null || suitableTransport.Count == 0)
            {
                order.Transport = ChooseBusyTransport(order, productAvailableTransport);
            }
            else
            {
                Transport choosenTransport = ChooseFreeTransport(order, suitableTransport);
                order.Transport = choosenTransport;
                choosenTransport.IsBusy = true;
            }
        }

        private Transport ChooseBusyTransport(Order order, List<Transport> availableTransport)
        {
            var firstPriority = order.Product.TransportPriority.Where(t => availableTransport.Contains(t.Key)).OrderBy(t => t.Value).First();
            var choosenTransport = availableTransport.Where(t => t.Type.Equals(firstPriority.Key.Type)).OrderBy(t => t.TimeReturnToShop).First();
            return choosenTransport;
        }

        private Transport ChooseFreeTransport(Order order, List<Transport> suitableTransport)
        {
            var firstPriority = order.Product.TransportPriority.Where(t => suitableTransport.Contains(t.Key)).OrderBy(t => t.Value).First();
            var choosenTransport = suitableTransport.Where(t => t.Type.Equals(firstPriority.Key.Type)).First();
            return choosenTransport;
        }
    }
}
