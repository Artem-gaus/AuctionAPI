using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;

namespace BusinessLogic.Interfaces.IRepositories
{
    public interface IBidRepository : IRepository<Bid>
    {
        Bid Get(int id);
        List<Bid> GetBidsByCustomer(int customerId);
    }
}
