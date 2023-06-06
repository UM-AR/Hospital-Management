using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.DB_Classes
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Patient_Id { get; set; }
        public bool status { get; set; }
        public string Patient_Name { get; set; }
        public string Email { get; set; }
        public double Ph_Number { get; set; }
        public string Password { get; set; }
    }
}
