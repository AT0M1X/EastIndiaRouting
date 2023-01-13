using System.ComponentModel.DataAnnotations;

namespace CESAPI.DTOs
{
    public class WeightClassDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int MinimumWeight { get; set; }
        [Required]
        public int MaximumWeight { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
