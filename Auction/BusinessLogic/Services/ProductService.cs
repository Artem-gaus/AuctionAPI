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
    public class ProductService : IProductSevice
    {
        private readonly IUnitOfWorkFactory uowFactory;

        public ProductService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        public void Create(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

            product.PublicationDate = DateTime.Now;
            product.EndDate = product.PublicationDate.AddMonths(1);

            using (var uow = uowFactory.Create())
            {
                try
                {
                    uow.Products.Add(product);
                    uow.Save();
                }
                catch (Exception)
                {
                    throw new ArgumentException("Parameters are not correct.");
                }
            }
        }

        public void Delete(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

            using (var uow = uowFactory.Create())
            {
                Product existsProduct = uow.Products.Get(product.Id);
                if (existsProduct != null || existsProduct.Id != 0)
                {
                    uow.Products.Remove(product);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not remove the product, becouse does product not exist");
                }
            }
        }

        public ProductDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            Product product = new Product();

            using (var uow = uowFactory.Create())
            {
                product = uow.Products.Get(id);
            }

            return mapper.Map<Product, ProductDTO>(product);
        }

        public List<ProductDTO> GetProductsByProducer(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            List<Product> products = new List<Product>();

            using (var uow = uowFactory.Create())
            {
                products = uow.Products.GetProductsByProducer(id);
            }

            return mapper.Map<List<Product>, List<ProductDTO>>(products);
        }

        public List<ProductDTO> GetProductsByCategory(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            List<Product> products = new List<Product>();

            using (var uow = uowFactory.Create())
            {
                products = uow.Products.GetProductsByCategory(id);
            }

            return mapper.Map<List<Product>, List<ProductDTO>>(products);
        }

        public void Update(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            Product product = mapper.Map<ProductDTO, Product>(productDTO);

            using (var uow = uowFactory.Create())
            {
                Product existsProduct = uow.Products.Get(product.Id);
                if (existsProduct != null || existsProduct.Id != 0)
                {
                    uow.Products.Update(product);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not update the product, becouse does product not exist");
                }
            }
        }
    }
}
