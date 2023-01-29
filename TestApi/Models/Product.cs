using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public DateTime creationDate { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime duration { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public int categoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Collection<CustomGroup> CustomGroup { get; set; }
    }
}
