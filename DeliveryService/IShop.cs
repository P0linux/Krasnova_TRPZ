using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    interface IShop
    {
        Order CreateOrder(int number, Product product, DeliveryPlace place);
    }
}
