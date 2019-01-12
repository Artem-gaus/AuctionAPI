using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces.IRepositories;

namespace DataAccess.Repositories
{
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        public ProducerRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }

        public Producer Get(int id)
        {
            var query = context.Producers.AsNoTracking().Where(p => p.Id == id);
            Producer producer = new Producer();
            foreach (var item in query)
            {
                producer.Id = item.Id;
                producer.Title = item.Title;
                producer.Description = item.Description;
                producer.Products = item.Products;
            }
            return producer;
        }
    }
}
