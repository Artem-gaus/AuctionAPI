using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.DTO;

namespace BusinessLogic.Interfaces.IServices
{
    public interface IProductSevice : IService<ProductDTO>
    {
        List<ProductDTO> GetProductsByProducer(int id);
        List<ProductDTO> GetProductsByCategory(int id);
    }
}
