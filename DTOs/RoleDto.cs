using System.ComponentModel.DataAnnotations;

namespace EIT.DTOs
{
    public class RoleDto
    {
        [Required]
        public string Role { get; set; }
    }
}
