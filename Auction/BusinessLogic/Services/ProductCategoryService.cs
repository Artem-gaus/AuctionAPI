﻿using System;
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
    class ProductCategoryService : IProductCategoryService
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
            ProductCategory category = uow.ProductCategories.Get(id);

            return mapper.Map<ProductCategory, ProductCategoryDTO>(category);
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