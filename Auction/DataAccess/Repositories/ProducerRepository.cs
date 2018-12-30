using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces;

namespace DataAccess.Repositories
{
    class ProducerRepository : IRepositoryCRUD<Producer>
    {
        private readonly AuctionContext context;

        public ProducerRepository(AuctionContext context)
        {
            this.context = context;
        }

        public void Create(Producer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Producer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Producer item)
        {
            throw new NotImplementedException();
        }
    }
}
