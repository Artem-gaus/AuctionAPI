using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.IRepositories;

///////////////////
// now is not use//
///////////////////
////////////////////////////////
///хороший вариант реализации///
///должно заработать         /// 
///https://habr.com/post/238737/
////////////////////////////////

namespace DataAccess
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool disposed = false;
        private readonly AuctionContext context;

        public ICustomerRepository Customers { get; private set; }
        public IBidRepository Bids { get; private set; }
        public IProducerRepository Producers { get; private set; }
        public IProductCategoryRepository ProductCategories { get; private set; }
        public IProductRepository Products { get; private set; } 
        public ISellerRepository Sellers { get; private set; }

        public UnitOfWork(AuctionContext context)
        {
            this.context = context;
            Customers = new CustomerRepository(context);
            Bids = new BidRepository(context);
            Producers = new ProducerRepository(context);
            ProductCategories = new ProductCategoryRepository(context);
            Products = new ProductRepository(context);
            Sellers = new SellerRepository(context);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
