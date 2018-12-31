using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class SellerDTO : PersonDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
        public SellerDTO()
        {
            Products = new Collection<ProductDTO>();
        }
    }
}
