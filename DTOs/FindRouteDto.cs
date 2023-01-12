using System;
using System.ComponentModel.DataAnnotations;

namespace EIT.DTOs
{
    public class FindRouteDto
    {
        [Required]
        public Guid CorrelationID { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }

        [Required]
        public string PackageType { get; set; }
        [Required]
        public DateTime SendTime { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public bool Recommended { get; set; }
    }
}
