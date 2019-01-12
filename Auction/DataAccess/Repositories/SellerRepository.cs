using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;
using BusinessLogic.Interfaces.IRepositories;

namespace DataAccess.Repositories
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        public SellerRepository(AuctionContext context) : base(context)
        {
        }
        public AuctionContext AuctionContext
        {
            get { return context as AuctionContext; }
        }

        public Seller Get(int id)
        {
            var query = context.Sellers.AsNoTracking().Where(s => s.Id == id);

            Seller seller = new Seller();
            foreach (var item in query)
            {
                seller.Id = item.Id;
                seller.Name = item.Name;
                seller.Surname = item.Surname;
                seller.Phone = item.Phone;
                seller.Email = item.Email;
                seller.BankAccountNumber = seller.BankAccountNumber;
                seller.Products = item.Products;
            }

            return seller;
        }
    }
}
