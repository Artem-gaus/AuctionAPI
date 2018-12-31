using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class ProductCategoryDTO : KeyValuePairDTO
    {
        public string Description { get; set; }

        public ICollection<ProductDTO> Products { get; set; }
        public ProductCategoryDTO()
        {
            Products = new Collection<ProductDTO>();
        }
    }
}
