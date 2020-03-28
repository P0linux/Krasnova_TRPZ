using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public interface IContainer
    {
        IShop GetShop();
    }
}
