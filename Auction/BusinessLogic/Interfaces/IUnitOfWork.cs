using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Interfaces.IRepositories;

namespace BusinessLogic.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        
        ICustomerRepository Customers { get; }
        IBidRepository Bids { get; }
        IProducerRepository Producers { get; }
        IProductCategoryRepository ProductCategories { get; }
        IProductRepository Products { get; }
        ISellerRepository Sellers { get; }
    }
}
