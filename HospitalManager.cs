 using Hospital_Management.DB_Classes;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management
{
    public class HospitalManager:DbContext
    {
        public HospitalManager(DbContextOptions ConnectionString):base(ConnectionString)
        {

        }

      public  DbSet<Patient> Patients_List { get; set; }
      public  DbSet<Patient_Login> Patients_Login_Data { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<User_Role> User_Role { get; set; }
        public DbSet<Role_Assignment> Role_Assignment { get; set; }
    }
}
