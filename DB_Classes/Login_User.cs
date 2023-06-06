using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.DB_Classes
{
    public class Login_User
    {
        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Password { get; set; }
        
    }
}
