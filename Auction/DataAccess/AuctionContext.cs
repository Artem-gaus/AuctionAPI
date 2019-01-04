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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(e => e.PublicationDate).HasColumnType("datetime2");
            modelBuilder.Entity<Product>().Property(e => e.EndDate).HasColumnType("datetime2");

            modelBuilder.Entity<Bid>().Property(e => e.TimeOfBit).HasColumnType("datetime2");

            modelBuilder.Entity<Bid>()
                .HasRequired(b => b.Customer)
                .WithMany(c => c.Bids)
                .HasForeignKey(b => b.CustomerId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Bid>()
                .HasRequired(b => b.Product)
                .WithMany(p => p.Bids)
                .HasForeignKey(b => b.ProductId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
