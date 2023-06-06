using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.DB_Classes
{
    public class SignUp_User 
    {
      
        public string Patient_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public double Ph_Number { get; set; }

    }
}
