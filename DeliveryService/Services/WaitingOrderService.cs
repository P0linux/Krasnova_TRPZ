using AutoMapper;
using DataAccess.EntityModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Services
{
    class WaitingOrderService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public WaitingOrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public List<Order> GetAll()
        {
            var wOrders = unitOfWork.DeliveryOrderRepository.GetAll();
            List<Order> orders = mapper.Map<List<Order>>(wOrders);
            return orders;
        }

        public void Update(Order order)
        {
            var ord = mapper.Map<WaitingOrderModel>(order);
            unitOfWork.WaitingOrderRepository.Update(ord);
        }

        public void Add(Order order)
        {
            var ord = mapper.Map<WaitingOrderModel>(order);
            unitOfWork.WaitingOrderRepository.Insert(ord);
        }
    }
}
