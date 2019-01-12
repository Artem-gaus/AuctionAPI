using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;

namespace BusinessLogic.Interfaces.IRepositories
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Seller Get(int id);
    }
}
