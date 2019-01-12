using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Interfaces;

namespace DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly AuctionContext context;
        public UnitOfWorkFactory()
        {
            context = new AuctionContext();
        }
        public IUnitOfWork Create()
        {
            return new UnitOfWork(context);
        }
    }
}
