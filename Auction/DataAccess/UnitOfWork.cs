using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Repositories;

namespace DataAccess
{
    class UnitOfWork : IDisposable
    {
        private AuctionContext context = new AuctionContext();
        private BidRepository bidRepository;
        private CustomerRepository customerRepository;
        private ProducerRepository producerRepository;
        private ProductCategoryRepository categoryRepository;
        private ProductRepository productRepository;
        private SellerRepository sellerRepository;

        public BidRepository Bids
        {
            get
            {
                if (bidRepository == null)
                    bidRepository = new BidRepository(context);

                return bidRepository;
            }
        }
        public CustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(context);

                return customerRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

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
    }
}
