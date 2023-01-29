using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class CustomGroup
    {
        [Key]
        public int customGroupId { get; set; }
        public string customGroupTitle { get; set; }

        public virtual Collection<Custom> customDescription { get; set; }

        public int productId { get; set; }

        public virtual Product Product { get; set; }
    }
}
