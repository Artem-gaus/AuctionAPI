using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces.IRepositories;

namespace DataAccess.Repositories
{
    class SellerRepository : Repository<Seller>, ISellerRepository
    {
        public SellerRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }
    }
}
