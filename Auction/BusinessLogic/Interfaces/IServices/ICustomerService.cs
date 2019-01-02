using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO Get(int id);
        void Create(CustomerDTO customerDTO);
        void Update(CustomerDTO customerDTO);
        void Delete(CustomerDTO customerDTO);
    }
}
