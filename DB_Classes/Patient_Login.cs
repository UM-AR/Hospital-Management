using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.DB_Classes
{
    public class Patient_Login
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Patient_Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Password { get; set; }
        public string Patient_Name { get; set; }
        public double Ph_Number { get; set; }
       public int UserRole_Id { get; set; }
        public bool status { get; set; }


    }

}
