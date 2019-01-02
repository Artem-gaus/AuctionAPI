using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces.IRepositories;

namespace DataAccess.Repositories
{
    class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        public ProducerRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }
    }
}
