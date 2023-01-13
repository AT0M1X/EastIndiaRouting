using System.ComponentModel.DataAnnotations;

namespace CESAPI.DTOs
{
    public class PackageTypeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Supported { get; set; }
    }
}
