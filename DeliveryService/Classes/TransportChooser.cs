using DeliveryService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryService
{
    public class TransportChooser
    {
        TransportService tService;
        public TransportChooser(TransportService tService)
        {
            this.tService = tService;
        }
        public void ChooseTransport(Order order)
        {
            var availableTransport = tService.GetAll();
            var suitableTransport = availableTransport.Where(t => t.IsBusy == false).ToList();
            //ICollection<Transport> productAvailableTransport = order.Product.availableTransport;
            //var suitableTransport = ShopStorage.AllTransport.Where(t => productAvailableTransport.Contains(t) && t.IsBusy == false).ToList();
            //var suitableTransport = tService.GetAll().Where(t => productAvailableTransport.Contains(t) && t.IsBusy == false).ToList();
            if (suitableTransport == null || suitableTransport.Count == 0)
            {
                order.Transport = ChooseBusyTransport(order, availableTransport/*productAvailableTransport*/);
            }
            else
            {
                Transport choosenTransport = ChooseFreeTransport(order, suitableTransport);
                order.Transport = choosenTransport;
                choosenTransport.IsBusy = true;
                tService.Update(choosenTransport);
                order.IsDelivering = true;
            }
        }

        private Transport ChooseBusyTransport(Order order, ICollection<Transport> availableTransport)
        {
            var choosenTransport = availableTransport.OrderBy(t => t.TimeReturnToShop).First();
            //var firstPriority = order.Product.TransportPriority.Where(t => availableTransport.Contains(t.Key)).OrderBy(t => t.Value).First();
            //var choosenTransport = availableTransport.Where(t => t.Type.Equals(firstPriority.Key.Type)).OrderBy(t => t.TimeReturnToShop).First();
            return choosenTransport;
        }

        private Transport ChooseFreeTransport(Order order, ICollection<Transport> suitableTransport)
        {
            var choosenTransport = suitableTransport.First();
            //var firstPriority = order.Product.TransportPriority.Where(t => suitableTransport.Contains(t.Key)).OrderBy(t => t.Value).First();
            //var choosenTransport = suitableTransport.Where(t => t.Type.Equals(firstPriority.Key.Type)).First();
            return choosenTransport;
        }
    }
}
