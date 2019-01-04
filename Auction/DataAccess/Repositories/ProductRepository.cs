using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces.IRepositories;

namespace DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }

        public List<Product> GetProductsByProducer(int producerId)
        {
            var query = context.Products.AsQueryable();
            query = query.Where(p => p.ProducerId == producerId);

            return query.ToList();
        }
        public List<Product> GetProductsByCategory(int categoryId)
        {
            var query = context.Products.AsQueryable();
            query = query.Where(p => p.ProductCategoryId == categoryId);

            return query.ToList();
        }
    }
}
