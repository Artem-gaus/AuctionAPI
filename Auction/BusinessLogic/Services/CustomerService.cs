using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BusinessLogic.DTO;
using BusinessLogic.Models;
using BusinessLogic.Interfaces;

////////////////////////////////
//хорошая валидация
//http://jasonwatmore.com/post/2016/12/12/c-aspnet-domain-validation-logic-in-domain-driven-design-ddd
////////////////////////////////
namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork uow;

        public CustomerService(IUnitOfWork repository)
        {
            this.uow = repository;
        }

        public void Create(CustomerDTO customerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, Customer>()).CreateMapper();
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);
            uow.Customers.Add(customer);
            uow.Save();
        }
        public CustomerDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            Customer customer = new Customer();
            try
            {
                customer = uow.Customers.Get(id);
            }
            catch
            {
            }

            return mapper.Map<Customer, CustomerDTO>(customer);
        }
        public void Update(CustomerDTO customerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);
            uow.Customers.Update(customer);
            uow.Save();
        }
        public void Delete(CustomerDTO customerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);
            uow.Customers.Remove(customer);
            uow.Save();
        }
    }
}
