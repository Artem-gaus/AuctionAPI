using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces;

namespace DataAccess.Repositories
{
    public class CustomerRepository : IRepositoryCRUD<Customer>
    {
        private readonly AuctionContext context;

        public CustomerRepository(AuctionContext context)
        {
            this.context = context;
        }

        public void Create(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            Customer customer = context.Customers.SingleOrDefault(e => e.Id == id);

            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
