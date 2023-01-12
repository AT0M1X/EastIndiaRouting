using System.ComponentModel.DataAnnotations;

namespace EIT.DTOs
{
    public class RouteDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public int Time { get; set; }
    }
}
