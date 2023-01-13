using System.ComponentModel.DataAnnotations;

namespace CESAPI.DTOs
{
    public class CityDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
