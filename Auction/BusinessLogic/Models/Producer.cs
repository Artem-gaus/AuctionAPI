using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
        public Producer()
        {
            Products = new Collection<Product>();
        }
    }
}
