using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public virtual Collection<Product> CategoryDescription { get; set; }
    }
}
