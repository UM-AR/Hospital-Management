using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Models.Reg_Data;
using Hospital_Management.Models.ViewModels;

namespace Hospital_Management.Repository.IRepository
{
    public interface IHospitalManager
    {
        List<Patient_Login> Get_Patient_Data_List();
        ResponseClass Login_User(Login_User User_Info);
        public List<Reg_Data> Get_Patient_Data();
        public ResponseClass Register_Patient(Patient_Registration Obj);
        public ResponseClass UpdateRoll(Reg_Role_Update Obj1);
    }
}
