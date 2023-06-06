using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.DB_Classes
{
    public class Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Permission_Id { get; set; }
        public string Permission_Title { get; set; }
        public string Permission_URL { get; set; }
        public int UserRole_Id { get; set; }
        public bool Status { get; set; }
    }

}
