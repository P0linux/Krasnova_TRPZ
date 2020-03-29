using AutoMapper;
using DataAccess.EntityModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Services
{
    public class TransportService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public TransportService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<Transport> GetAll()
        {
            var trans = unitOfWork.TransportRepository.GetAll();
            List<Transport> transports = mapper.Map<List<Transport>>(trans);
            return transports;
        }

        public void Update(Transport transport)
        {
            var trans = mapper.Map<TransportModel>(transport);
            unitOfWork.TransportRepository.Update(trans);
            unitOfWork.Commit();
        }

        public void Add(Transport transport)
        {
            var trans = mapper.Map<TransportModel>(transport);
            unitOfWork.TransportRepository.Insert(trans);
            unitOfWork.Commit();
        }

        public void DeleteById(int Id)
        {
            unitOfWork.TransportRepository.DeleteById(Id);
            unitOfWork.Commit();
        }
    }
}
