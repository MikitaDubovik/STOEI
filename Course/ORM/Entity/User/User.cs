using System.ComponentModel.DataAnnotations;

namespace ORM.Entity
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        
        public int RoleId { get; set; }

        public Role Roles { get; set; }

        [Required]
        public string Login { get; set; }

        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }

        public byte[] ProfilePhoto { get; set; }
    }
}