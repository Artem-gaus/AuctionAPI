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
        private readonly IUnitOfWorkFactory uowFactory;

        public ProductCategoryService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        public void Create(ProductCategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryDTO, ProductCategory>()).CreateMapper();
            ProductCategory category = mapper.Map<ProductCategoryDTO, ProductCategory>(categoryDTO);

            using (var uow = uowFactory.Create())
            {
                uow.ProductCategories.Add(category);
                uow.Save();
            }
        }

        public void Delete(ProductCategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryDTO, ProductCategory>()).CreateMapper();
            ProductCategory category = mapper.Map<ProductCategoryDTO, ProductCategory>(categoryDTO);

            using (var uow = uowFactory.Create())
            {
                ProductCategory existsCategory = uow.ProductCategories.Get(category.Id);

                if (existsCategory != null)
                {
                    uow.ProductCategories.Remove(category);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not delete the Product Category, becouse does Product Category not exist");
                }
            }
        }

        public ProductCategoryDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, ProductCategoryDTO>()).CreateMapper();
            ProductCategory category = new ProductCategory();

            using (var uow = uowFactory.Create())
            {
                category = uow.ProductCategories.Get(id);
            }

            return mapper.Map<ProductCategory, ProductCategoryDTO>(category);
        }

        public List<ProductCategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategory, ProductCategoryDTO>()).CreateMapper();
            List<ProductCategory> categorys = new List<ProductCategory>();

            using (var uow = uowFactory.Create())
            {
                categorys = uow.ProductCategories.GetAll().ToList();
            }

            return mapper.Map<List<ProductCategory>, List<ProductCategoryDTO>>(categorys);
        }

        public void Update(ProductCategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductCategoryDTO, ProductCategory>()).CreateMapper();
            ProductCategory category = mapper.Map<ProductCategoryDTO, ProductCategory>(categoryDTO);

            using (var uow = uowFactory.Create())
            {
                ProductCategory existsCategory = uow.ProductCategories.Get(category.Id);

                if (existsCategory != null)
                {
                    uow.ProductCategories.Update(category);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not update the Product Category, becouse does Product Category not exist");
                }
            }
        }
    }
}
