using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DataAccess.EntityModels;

namespace DeliveryService.Classes
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<WaitingOrderModel, Order>().ReverseMap();
            CreateMap<DeliveryOrderModel, Order>().ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<PriorityModel, Priority>().ReverseMap();
            CreateMap<TransportModel, Transport>().ReverseMap();
            CreateMap<DeliveryPlaceModel, DeliveryPlace>().ReverseMap();
        }
    }
}
