using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models
{
    public abstract class BaseEntity {}
    public class Quote : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        public string Content { get; set; }


    }
}