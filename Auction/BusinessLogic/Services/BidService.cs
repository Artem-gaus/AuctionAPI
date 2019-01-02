﻿using BusinessLogic.Models;
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
    class BidService : IBidService
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
            Bid bid = uow.Bids.Get(id);

            return mapper.Map<Bid, BidDTO>(bid);
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
