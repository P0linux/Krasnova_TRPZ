using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityModels
{
    class TransportModel : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Speed { get; set; }
        public string Name { get; set; }
        public int MaxWeight { get; set; }
        public int MaxSize { get; set; }
        public bool JamImpact { get; set; }
        public TimeSpan TimeReturnToShop { get; set; }
        public bool IsBusy { get; set; } = false;

    }
}
