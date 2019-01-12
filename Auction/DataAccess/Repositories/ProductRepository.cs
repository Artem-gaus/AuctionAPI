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

        public Product Get(int id)
        {
            var query = context.Products.AsNoTracking().Where(p => p.Id == id);
            Product product = new Product();
            foreach (var item in query)
            {
                product.Id = item.Id;
                product.Bids = item.Bids;
                product.Description = item.Description;
                product.EndDate = item.EndDate;
                product.Producer = item.Producer;
                product.ProducerId = item.ProducerId;
                product.ProductCategory = item.ProductCategory;
                product.ProductCategoryId = item.ProductCategoryId;
                product.PublicationDate = item.PublicationDate;
                product.Seller = item.Seller;
                product.SellerId = item.SellerId;
                product.Title = item.Title;
            }

            return product;
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
