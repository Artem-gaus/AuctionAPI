using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Tests.Controllers.Tests
{
    class CustomerServiceFake : ICustomerService
    {
        private List<CustomerDTO> customers;
        public CustomerServiceFake()
        {
            customers = new List<CustomerDTO>() {
                new CustomerDTO { Id = 1, Name = "Name1", Surname = "Surname1", Email = "his1@mail.com", Phone = 969699947, BankAccountNumber = 1234 },
                new CustomerDTO { Id = 2, Name = "Name2", Surname = "Surname2", Email = "his2@mail.com", Phone = 9696999, BankAccountNumber = 12345 },
                new CustomerDTO { Id = 3, Name = "Name3", Surname = "Surname3", Email = "his3@mail.com", Phone = 96969, BankAccountNumber = 123456 }
            };
        }
        public void Create(CustomerDTO customer)
        {
            customers.Add(customer);
        }

        public void Delete(CustomerDTO customer)
        {
            customers.Remove(customer);
        }

        public CustomerDTO Get(int id)
        {
            CustomerDTO existing = customers.FirstOrDefault(c => id == c.Id);
            return existing;
        }

        public void Update(CustomerDTO customer)
        {
            customers.Remove(customer);
            customers.Add(customer);
        }
    }
}
