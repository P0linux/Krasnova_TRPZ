using AutoMapper;
using DataAccess.EntityModels;
using DataAccess.Interfaces;
using DeliveryService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryService.Services
{
    public class PriorityService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public PriorityService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public Dictionary<Transport, int> GetAllByProduct(Product product)
        {
            var priorities = unitOfWork.PriorityRepository.GetAll();
            var prior = mapper.Map<List<Priority>>(priorities);
            prior = prior.Where(p => p.Product == product).ToList();
            return prior.ToDictionary(p => p.Transport, p => p.PriorityNumber);
        }

        public void Add(Priority priority)
        {
            var pr = mapper.Map<PriorityModel>(priority);
            unitOfWork.PriorityRepository.Insert(pr);
        }
    }
}
