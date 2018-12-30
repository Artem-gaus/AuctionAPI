using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces;

namespace DataAccess.Repositories
{
    class SellerRepository : IRepositoryCRUD<Seller>
    {
        private readonly AuctionContext context;

        public SellerRepository(AuctionContext context)
        {
            this.context = context;
        }

        public void Create(Seller item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Seller Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seller> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Seller item)
        {
            throw new NotImplementedException();
        }
    }
}
