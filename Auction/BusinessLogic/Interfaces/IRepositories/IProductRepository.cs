using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(int id);
        List<Product> GetProductsByProducer(int producerId);
        List<Product> GetProductsByCategory(int categoryId);
    }
}
