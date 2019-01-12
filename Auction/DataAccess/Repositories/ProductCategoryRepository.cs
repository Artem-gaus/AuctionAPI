using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces.IRepositories;

namespace DataAccess.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }

        public ProductCategory Get(int id)
        {
            var query = context.GetProductCategories.AsNoTracking().Where(p => p.Id == id);
            ProductCategory category = new ProductCategory();
            foreach (var item in query)
            {
                category.Id = item.Id;
                category.Title = item.Title;
                category.Description = item.Description;
                category.Products = item.Products;
            }

            return category;
        }
    }
}
