using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Bid> Bids { get; set; }

        public Product()
        {
            Bids = new Collection<Bid>();
        }
    }
}
