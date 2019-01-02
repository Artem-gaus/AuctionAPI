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

        public void Create(Customer item)
        {
            context.Customers.Add(item);
        }

        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }
    }
}
