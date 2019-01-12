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
    public class ProducerService : IProducerService
    {
        private readonly IUnitOfWorkFactory uowFactory;

        public ProducerService(IUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        public void Create(ProducerDTO producerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>()).CreateMapper();
            Producer producer = mapper.Map<ProducerDTO, Producer>(producerDTO);

            using (var uow = uowFactory.Create())
            {
                uow.Producers.Add(producer);
                uow.Save();
            }  
        }

        public void Delete(ProducerDTO producerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>()).CreateMapper();
            Producer producer = mapper.Map<ProducerDTO, Producer>(producerDTO);
            using (var uow = uowFactory.Create())
            {
                Producer existsProducer = uow.Producers.Get(producerDTO.Id);
                if (existsProducer != null || existsProducer.Id != 0)
                {
                    uow.Producers.Remove(producer);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not update the producer, becouse does producer not exist");
                }
            }
        }

        public ProducerDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Producer, ProducerDTO>()).CreateMapper();
            Producer producer = new Producer();

            using (var uow = uowFactory.Create())
            {
                producer = uow.Producers.Get(id);
            }

            return mapper.Map<Producer, ProducerDTO>(producer);
        }

        public List<ProducerDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Producer, ProducerDTO>()).CreateMapper();
            List<Producer> producers = new List<Producer>();

            using (var uow = uowFactory.Create())
            {
                producers = uow.Producers.GetAll().ToList();
            }

            return mapper.Map<List<Producer>, List<ProducerDTO>>(producers);
        }

        public void Update(ProducerDTO producerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>()).CreateMapper();
            Producer producer = mapper.Map<ProducerDTO, Producer>(producerDTO);
            
            using (var uow = uowFactory.Create())
            {
                Producer existsProducer = uow.Producers.Get(producerDTO.Id);
                if (existsProducer != null || existsProducer.Id != 0)
                {
                    uow.Producers.Update(producer);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException("You can not update the producer, becouse does producer not exist");
                }
            }
        }
    }
}
