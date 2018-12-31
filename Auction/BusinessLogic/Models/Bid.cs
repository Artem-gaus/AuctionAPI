using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Bid
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 100000)]
        public int Price { get; set; }
        [Required]
        public DateTime TimeOfBit { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
