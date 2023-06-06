using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models.ViewModels
{
    public class Reg_Data
    {
        public int Patient_Id { get; set; }

      
        public string Email { get; set; }
       
        public string Password { get; set; }
        public string Patient_Name { get; set; }
        public double Ph_Number { get; set; }
        public int UserRole_Id { get; set; }
        public string UserRole_Title { get; set; }



    }
}
