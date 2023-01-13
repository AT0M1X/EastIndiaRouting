using System.ComponentModel.DataAnnotations;

namespace CESAPI.DTOs
{
    public class RoleDto
    {
        [Required]
        public string Role { get; set; }
    }
}
