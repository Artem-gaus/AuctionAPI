using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BusinessLogic.DTO;
using BusinessLogic.Models;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork uow;
        private readonly IUnitOfWorkFactory uowFactory;

        public CustomerService(IUnitOfWork repository, IUnitOfWorkFactory uowFactory)
        {
            this.uow = repository;
            this.uowFactory = uowFactory;
        }

        public void Create(CustomerDTO customerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, Customer>()).CreateMapper();
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);

            using (var uow = uowFactory.Create())
            {
                uow.Customers.Add(customer);
                uow.Save();
            }  
        }
        public CustomerDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();

            Customer customer = new Customer();
            using (var uow = uowFactory.Create())
            {
                customer = uow.Customers.Get(id);
            } 

            return mapper.Map<Customer, CustomerDTO>(customer);
        }
        public void Update(CustomerDTO customerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);

            using (var uow = uowFactory.Create())
            {
                Customer existsCustomer = uow.Customers.Get(customer.Id);

                if (existsCustomer != null)
                {
                    uow.Customers.Update(customer);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException();
                }
            } 
        }
        public void Delete(CustomerDTO customerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            Customer customer = mapper.Map<CustomerDTO, Customer>(customerDTO);

            using (var uow = uowFactory.Create())
            {
                Customer existsCustomer = uow.Customers.Get(customer.Id);

                if (existsCustomer != null)
                {
                    uow.Customers.Remove(customer);
                    uow.Save();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
