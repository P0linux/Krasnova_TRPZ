using AutoMapper;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Services
{
    class DeliveryPlaceService
    {
        private Mapper mapper;
        private IUnitOfWork unitOfWork;
        public DeliveryPlaceService(Mapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<DeliveryPlace> GetAll()
        {
            var delPlaces = unitOfWork.DeliveryPlaceRepository.GetAll();
            List<DeliveryPlace> deliveryPlaces = mapper.Map<List<DeliveryPlace>>(delPlaces);
            return deliveryPlaces;
        }
    }
}
