using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Seller : Person
    {
        public ICollection<Product> Products { get; set; }
        public Seller()
        {
            Products = new Collection<Product>();
        }
    }
}
