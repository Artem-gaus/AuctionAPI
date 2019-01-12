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

        public Bid Get(int id)
        {
            var query = context.Bids.AsNoTracking().Where(c => c.Id == id);
            Bid bid = new Bid();
            foreach (var item in query)
            {
                bid.Id = item.Id;
                bid.Price = item.Price;
                bid.TimeOfBit = item.TimeOfBit;
                bid.Product = item.Product;
                bid.ProductId = item.ProductId;
                bid.Customer = item.Customer;
                bid.CustomerId = item.CustomerId;
            }
            return bid;
        }
        public List<Bid> GetBidsByCustomer(int customerId)
        {
            var query = context.Bids.AsQueryable();
            query = query.Where(b => b.CustomerId == customerId);

            return query.ToList();
        }
    }
}
