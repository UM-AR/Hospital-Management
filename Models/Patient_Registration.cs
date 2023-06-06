using Hospital_Management.DB_Classes;

namespace Hospital_Management.Models
{
	public class Patient_Registration
	{
		public string Name { get; set; }
        public string Email { get; set; }
        public double Ph_Number { get; set; }
        public string Password { get; set; }
        public int UserRole_Id { get; set; }
        public bool status { get; set; }
    }
}
