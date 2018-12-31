using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUnitOfWork<BidR, CustomerR> 
        where BidR : class
        where CustomerR : class
    {
        BidR Bids { get; }
        CustomerR Customers { get; }
        void Save();
    }
}
