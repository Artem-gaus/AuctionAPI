using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.IServices;
using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    class ProductService : IProductSevice
    {
        private readonly IUnitOfWork uow;

        public ProductService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Create(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);
            uow.Products.Add(product);
            uow.Save();
        }

        public void Delete(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);
            uow.Products.Remove(product);
            uow.Save();
        }

        public ProductDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            Product product = uow.Products.Get(id);

            return mapper.Map<Product, ProductDTO>(product);
        }

        public void Update(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);
            uow.Products.Update(product);
            uow.Save();
        }
    }
}
