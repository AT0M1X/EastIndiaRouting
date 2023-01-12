using Microsoft.AspNetCore.Identity;

namespace EIT.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
