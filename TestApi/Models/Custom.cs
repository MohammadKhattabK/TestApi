using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class Custom
    {
        [Key]
        public int customId { get; set; }
        public string customKey { get; set; }
        public string customValue { get; set; }

        public int customGroupId { get; set; }

        public virtual CustomGroup CustomGroup { get; set; }
    }
}
