using System;
using System.ComponentModel.DataAnnotations;

namespace CESAPI.DTOs
{
    public class ServiceAccountDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public Guid CollaborationID { get; set; }
    }
}
