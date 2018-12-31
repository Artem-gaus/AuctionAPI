using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    class BidService
    {
        private readonly IRepositoryCRUD<Bid> bidRepository;

        public BidService(IRepositoryCRUD<Bid> bidRepository)
        {
            this.bidRepository = bidRepository;
        }
    }
}
