using AutoMapper;
using DataAccess.EntityModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Services
{
    public class DeliveryOrderService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public DeliveryOrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public List<Order> GetAll()
        {
            var dOrders = unitOfWork.DeliveryOrderRepository.GetAll();
            List<Order> orders = mapper.Map<List<Order>>(dOrders);
            return orders;
        }

        public void Update(Order order)
        {
            var ord = mapper.Map<DeliveryOrderModel>(order);
            unitOfWork.DeliveryOrderRepository.Update(ord);
            unitOfWork.Commit();
        }

        public void Add(Order order)
        {
            var ord = mapper.Map<DeliveryOrderModel>(order);
            unitOfWork.DeliveryOrderRepository.Insert(ord);
            unitOfWork.Commit();
        }

        public void DeleteById(int Id)
        {
            unitOfWork.DeliveryOrderRepository.DeleteById(Id);
            unitOfWork.Commit();
        }
    }
}
