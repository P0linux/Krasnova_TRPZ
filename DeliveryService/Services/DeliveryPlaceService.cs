using AutoMapper;
using DataAccess.EntityModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Services
{
    public class DeliveryPlaceService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public DeliveryPlaceService(IMapper mapper, IUnitOfWork unitOfWork)
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

        public void Add(DeliveryPlace deliveryPlace)
        {
            var del = mapper.Map<DeliveryPlaceModel>(deliveryPlace);
            unitOfWork.DeliveryPlaceRepository.Insert(del);
            unitOfWork.Commit();
        }
    }
}
