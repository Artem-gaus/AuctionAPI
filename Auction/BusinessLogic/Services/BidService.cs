using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.IServices;
using BusinessLogic.DTO;
using AutoMapper;

namespace BusinessLogic.Services
{
    public class BidService : IBidService
    {
        private readonly IUnitOfWork uow;

        public BidService(IUnitOfWork repository)
        {
            this.uow = repository;
        }

        public void Create(BidDTO bidDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BidDTO, Bid>()).CreateMapper();
            Bid bid = mapper.Map<BidDTO, Bid>(bidDTO);
            bid.TimeOfBit = DateTime.Now;

            uow.Bids.Add(bid);
            uow.Save();
        }
        public void Delete(BidDTO bidDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();
            Bid bid = mapper.Map<BidDTO, Bid>(bidDTO);
            uow.Bids.Remove(bid);
            uow.Save();
        }
        public BidDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();
            Bid bid = new Bid();
            var query = uow.Bids.Get(id);

            foreach (var item in query)
            {
                bid.Id = item.Id;
                bid.Price = item.Price;
                bid.TimeOfBit = item.TimeOfBit;
                bid.Product = item.Product;
                bid.ProductId = item.ProductId;
                bid.Customer = item.Customer;
                bid.CustomerId = item.CustomerId;
            }

            return mapper.Map<Bid, BidDTO>(bid);
        }
        public List<BidDTO> GetBidsByCustomer(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();
            List<Bid> bids = uow.Bids.GetBidsByCustomer(id);

            return mapper.Map<List<Bid>, List<BidDTO>>(bids);
        }
        public void Update(BidDTO bidDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();
            Bid bid = mapper.Map<BidDTO, Bid>(bidDTO);
            uow.Bids.Update(bid);
            uow.Save();
        }
    }
}
