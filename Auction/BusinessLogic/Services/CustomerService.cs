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
        private readonly IRepositoryCRUD<Customer> repository;

        public CustomerService(IRepositoryCRUD<Customer> repository) 
        {
            this.repository = repository;
        }

        public CustomerDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
            Customer customer = repository.Get(id);

            return mapper.Map<Customer, CustomerDTO>(customer);
        }
    }
}
