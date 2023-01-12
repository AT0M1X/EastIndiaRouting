using System;
using System.ComponentModel.DataAnnotations;

namespace EIT.DTOs
{
    public class FindRouteDto
    {
        [Required]
        public int From { get; set; }
        [Required]
        public int To { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Lenght { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public string PackageType { get; set; }
        [Required]
        public DateTime SendTime { get; set; }
    }
}
