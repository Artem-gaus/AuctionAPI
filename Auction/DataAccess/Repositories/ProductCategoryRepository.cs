using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces;

namespace DataAccess.Repositories
{
    class ProductCategoryRepository : IRepositoryCRUD<ProductCategory>
    {
        private readonly AuctionContext context;

        public ProductCategoryRepository(AuctionContext context)
        {
            this.context = context;
        }

        public void Create(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
