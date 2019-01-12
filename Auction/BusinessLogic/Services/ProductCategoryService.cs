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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork uow;

        public ProductCategoryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Create(ProductCategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryDTO, ProductCategory>()).CreateMapper();
            ProductCategory category = mapper.Map<ProductCategoryDTO, ProductCategory>(categoryDTO);
            uow.ProductCategories.Add(category);
            uow.Save();
        }

        public void Delete(ProductCategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryDTO, ProductCategory>()).CreateMapper();
            ProductCategory category = mapper.Map<ProductCategoryDTO, ProductCategory>(categoryDTO);
            uow.ProductCategories.Remove(category);
            uow.Save();
        }

        public ProductCategoryDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, ProductCategoryDTO>()).CreateMapper();
            ProductCategory category = new ProductCategory(); // uow.ProductCategories.Get(id);

            return mapper.Map<ProductCategory, ProductCategoryDTO>(category);
        }

        public List<ProductCategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, ProductCategoryDTO>()).CreateMapper();
            List<ProductCategory> categorys = uow.ProductCategories.GetAll().ToList();

            return mapper.Map<List<ProductCategory>, List<ProductCategoryDTO>>(categorys);
        }

        public void Update(ProductCategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryDTO, ProductCategory>()).CreateMapper();
            ProductCategory category = mapper.Map<ProductCategoryDTO, ProductCategory>(categoryDTO);
            uow.ProductCategories.Update(category);
            uow.Save();
        }
    }
}
