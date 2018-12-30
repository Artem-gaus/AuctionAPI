using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Models;

namespace DataAccess
{
    public class AuctionContext : DbContext
    {
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> GetProductCategories { get; set; }

        public AuctionContext() : base("DBAuction")
        {
        }
    }
}
