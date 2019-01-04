using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class SaveProductDTO : KeyValuePairDTO
    {
        public string Description { get; set; }

        public int ProductCategoryId { get; set; }
        public int ProducerId { get; set; }
        public int SellerId { get; set; }
    }
}
