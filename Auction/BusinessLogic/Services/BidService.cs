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
        private readonly IUnitOfWorkFactory uowFactory;

        public BidService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        public void Create(BidDTO bidDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BidDTO, Bid>()).CreateMapper();
            Bid bid = mapper.Map<BidDTO, Bid>(bidDTO);

            bid.TimeOfBit = DateTime.Now;
            using (var uow = uowFactory.Create())
            {
                try
                {
                    uow.Bids.Add(bid);
                    uow.Save();
                }
                catch (Exception)
                {
                    throw new ArgumentException("Parameters are not correct.");
                }
            }
        }
        public void Delete(BidDTO bidDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();
            Bid bid = mapper.Map<BidDTO, Bid>(bidDTO);
            using (var uow = uowFactory.Create())
            {
                Bid existsBid = uow.Bids.Get(bidDTO.Id);
                if (existsBid != null || existsBid.Id != 0)
                {
                    uow.Bids.Remove(bid);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not remove the bid, becouse does bid not exist");
                }
            }
        }
        public BidDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();

            Bid bid = new Bid();
            using (var uow = uowFactory.Create())
            {
                bid = uow.Bids.Get(id);
            }  

            return mapper.Map<Bid, BidDTO>(bid);
        }
        public List<BidDTO> GetBidsByCustomer(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();
            List<Bid> bids = new List<Bid>(); 

            using (var uow = uowFactory.Create())
            {
                bids = uow.Bids.GetBidsByCustomer(id);
            }

            return mapper.Map<List<Bid>, List<BidDTO>>(bids);
        }
        public void Update(BidDTO bidDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bid, BidDTO>()).CreateMapper();
            Bid bid = mapper.Map<BidDTO, Bid>(bidDTO);

            using (var uow = uowFactory.Create())
            {
                Bid existsBid = uow.Bids.Get(bidDTO.Id);
                if (existsBid != null || existsBid.Id != 0)
                {
                    uow.Bids.Update(bid);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not update the bid, becouse does bid not exist");
                }
            }  
        }
    }
}
