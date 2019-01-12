using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }

        public Customer Get(int id)
        {
            var query = context.Customers.AsNoTracking().Where(c => c.Id == id);
            Customer customer = new Customer();
            foreach (var item in query)
            {
                customer.Id = item.Id;
                customer.Name = item.Name;
                customer.Surname = item.Surname;
                customer.Email = item.Email;
                customer.Phone = item.Phone;
                customer.BankAccountNumber = item.BankAccountNumber;
                customer.Bids = item.Bids;
            }

            return customer; 
        }
    }
}
