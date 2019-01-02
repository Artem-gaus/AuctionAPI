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
    class ProducerService : IProducerService
    {
        private readonly IUnitOfWork uow;

        public ProducerService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Create(ProducerDTO producerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>()).CreateMapper();
            Producer producer = mapper.Map<ProducerDTO, Producer>(producerDTO);
            uow.Producers.Add(producer);
            uow.Save();
        }

        public void Delete(ProducerDTO producerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>()).CreateMapper();
            Producer producer = mapper.Map<ProducerDTO, Producer>(producerDTO);
            uow.Producers.Remove(producer);
            uow.Save();
        }

        public ProducerDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Producer, ProducerDTO>()).CreateMapper();
            Producer producer = uow.Producers.Get(id);

            return mapper.Map<Producer, ProducerDTO>(producer);
        }

        public void Update(ProducerDTO producerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>()).CreateMapper();
            Producer producer = mapper.Map<ProducerDTO, Producer>(producerDTO);
            uow.Producers.Update(producer);
            uow.Save();
        }
    }
}
