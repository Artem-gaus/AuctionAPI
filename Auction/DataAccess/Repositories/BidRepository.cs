using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces;

namespace DataAccess.Repositories
{
    class BidRepository : IRepositoryCRUD<Bid>
    {
        private readonly AuctionContext context;

        public BidRepository(AuctionContext context)
        {
            this.context = context;
        }

        public void Create(Bid item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Bid Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bid> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Bid item)
        {
            throw new NotImplementedException();
        }
    }
}
