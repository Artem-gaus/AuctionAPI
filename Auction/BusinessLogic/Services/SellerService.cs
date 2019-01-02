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
    class SellerService : ISellerService
    {
        private readonly IUnitOfWork uow;

        public SellerService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Create(SellerDTO sellerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SellerDTO, Seller>()).CreateMapper();
            Seller seller = mapper.Map<SellerDTO, Seller>(sellerDTO);
            uow.Sellers.Add(seller);
            uow.Save();
        }

        public void Delete(SellerDTO sellerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SellerDTO, Seller>()).CreateMapper();
            Seller seller = mapper.Map<SellerDTO, Seller>(sellerDTO);
            uow.Sellers.Remove(seller);
            uow.Save();
        }

        public SellerDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Seller, SellerDTO>()).CreateMapper();
            Seller seller = uow.Sellers.Get(id);

            return mapper.Map<Seller, SellerDTO>(seller);
        }

        public void Update(SellerDTO sellerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SellerDTO, Seller>()).CreateMapper();
            Seller seller = mapper.Map<SellerDTO, Seller>(sellerDTO);
            uow.Sellers.Update(seller);
            uow.Save();
        }
    }
}
