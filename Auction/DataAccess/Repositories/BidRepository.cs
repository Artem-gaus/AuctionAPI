using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.IRepositories;

namespace DataAccess.Repositories
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        public BidRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }

        public List<Bid> GetBidsByCustomer(int customerId)
        {
            var query = context.Bids.AsQueryable();
            query = query.Where(b => b.CustomerId == customerId);

            return query.ToList();
        }
    }
}
