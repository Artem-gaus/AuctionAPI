using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Customer : Person
    {
        public ICollection<Bid> Bids { get; set; }

        public Customer()
        {
            Bids = new Collection<Bid>();
        }
    }
}
