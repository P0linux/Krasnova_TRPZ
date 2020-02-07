using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService
{
    public interface ITimeCounter
    {
        TimeSpan CountTime(Order order);
        TimeSpan JamImpactIndexing(Order order, TimeSpan time); //Отдельный класс для функции лучше
    }
}
