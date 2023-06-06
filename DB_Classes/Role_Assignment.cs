using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.DB_Classes
{
    public class Role_Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Role_Assignment_Id { get; set; }
        public int Permission_Id { get; set; }
        public int UserRole_Id { get; set; }
        public bool Status { get; set; }
    }
}
