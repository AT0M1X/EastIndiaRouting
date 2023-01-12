using System.ComponentModel.DataAnnotations;

namespace EIT.DTOs
{
    public class CityDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
