using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTO
{
    public class ProductDTO : KeyValuePairDTO
    {
        public DateTime PublicationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public ICollection<BidDTO> Bids { get; set; }

        public ProductDTO()
        {
            Bids = new Collection<BidDTO>();
        }
    }
}
