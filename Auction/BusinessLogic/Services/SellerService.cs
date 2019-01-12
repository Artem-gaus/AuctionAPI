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
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork uow;
        private readonly IUnitOfWorkFactory uowFactory;

        public SellerService(IUnitOfWork uow, IUnitOfWorkFactory uowFactory)
        {
            this.uow = uow;
            this.uowFactory = uowFactory;
        }

        public void Create(SellerDTO sellerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SellerDTO, Seller>()).CreateMapper();
            Seller seller = mapper.Map<SellerDTO, Seller>(sellerDTO);
            using (var uow = uowFactory.Create())
            {
                uow.Sellers.Add(seller);
                uow.Save();
            } 
        }

        public void Delete(SellerDTO sellerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SellerDTO, Seller>()).CreateMapper();
            Seller seller = mapper.Map<SellerDTO, Seller>(sellerDTO);

            using (var uow = uowFactory.Create())
            {
                Seller existsSeller = uow.Sellers.Get(seller.Id);
                if (existsSeller != null || existsSeller.Id != 0)
                {
                    uow.Sellers.Remove(seller);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not remove the Seller, becouse does Seller not exist");
                }
            }
        }

        public SellerDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Seller, SellerDTO>()).CreateMapper();
            Seller seller = new Seller();

            using (var uow = uowFactory.Create())
            {
                seller = uow.Sellers.Get(id);
            }

            return mapper.Map<Seller, SellerDTO>(seller);
        }

        public void Update(SellerDTO sellerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SellerDTO, Seller>()).CreateMapper();
            Seller seller = mapper.Map<SellerDTO, Seller>(sellerDTO);

            using (var uow = uowFactory.Create())
            {
                Seller existsSeller = uow.Sellers.Get(seller.Id);
                if (existsSeller != null || existsSeller.Id != 0)
                {
                    uow.Sellers.Update(seller);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not update the Seller, becouse does Seller not exist");
                }
            }
        }
    }
}
