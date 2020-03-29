using AutoMapper;
using DataAccess.EntityModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Services
{
    public class ProductService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<Product> GetAll()
        {
            var prod = unitOfWork.ProductRepository.GetAll();
            List<Product> products = mapper.Map<List<Product>>(prod);
            return products;
        }

        public void Add(Product product)
        {
            var prod = mapper.Map<ProductModel>(product);
            unitOfWork.ProductRepository.Insert(prod);
        }
    }
}
