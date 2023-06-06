using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.DB_Classes
{
    public class User_Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRole_Id { get; set; }
        public string UserRole_Title { get; set; }
        public bool Status { get; set; }
    }
}
