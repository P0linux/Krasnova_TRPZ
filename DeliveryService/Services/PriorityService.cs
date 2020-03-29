using AutoMapper;
using DataAccess.Interfaces;
using DeliveryService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryService.Services
{
    class PriorityService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public PriorityService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public Dictionary<Transport, int> GetAllByProductId(int Id)
        {
            var priorities = unitOfWork.PriorityRepository.GetAll();
            var prior = mapper.Map<List<Priority>>(priorities);
            prior = prior.Where(p => p.Id == Id).ToList();
            return prior.ToDictionary(p => p.Transport, p => p.PriorityNumber);
        }
    }
}
