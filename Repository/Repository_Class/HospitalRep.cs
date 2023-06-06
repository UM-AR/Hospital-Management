using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Models.Reg_Data;
using Hospital_Management.Models.ViewModels;
using Hospital_Management.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital_Management.Repository.Repository_Class
{
    public class HospitalRep : IHospitalManager
    {
        private readonly HospitalManager _manager;
        private readonly IConfiguration _config;
         public HospitalRep(HospitalManager manager, IConfiguration config)
        {
            this._manager = manager;
            _config = config;
        }
        public List<Patient_Login> Get_Patient_Data_List()
        {
            return _manager.Patients_Login_Data.Where(rows => rows.status == true).ToList();

        }

        public ResponseClass Login_User(Login_User User_Info)
        {
            ResponseClass response = new ResponseClass();
            Patient_Login login = _manager.Patients_Login_Data.Where(row => row.Email == User_Info.Email && row.Password == User_Info.Password).FirstOrDefault();


            if (login != null)
            {
                response.Result = "Login Successfully";
                response.ObjectData = GenerateJSOWebToken(login);
            }
            else
            {
                response.Result = "Invalid Email/Password";
                return response;
            }

            return response;
        }
        private string GenerateJSOWebToken(Patient_Login user_Info)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[]
            { new Claim("Email", user_Info.Email),
             new Claim("UserId", user_Info.Patient_Id.ToString()),
            };


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],

                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(480),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public List<Reg_Data> Get_Patient_Data()
        {
            List<Reg_Data> Get_Patient = (from PD in _manager.Patients_Login_Data
                                          join userRole in _manager.User_Role
                                         on PD.UserRole_Id equals userRole.UserRole_Id
                                          select new Reg_Data
                                          {
                                              Patient_Id = PD.Patient_Id,
                                              Patient_Name = PD.Patient_Name,
                                              Email = PD.Email,
                                              Ph_Number = PD.Ph_Number,
                                              UserRole_Id = userRole.UserRole_Id,
                                              UserRole_Title = userRole.UserRole_Title

                                          }).ToList();


            return Get_Patient;
        }

        public ResponseClass Register_Patient(Patient_Registration Obj)
        {
            ResponseClass response = new ResponseClass();


            //if (patient1 == null)
            //{
            Patient_Login patient = new Patient_Login();
            patient.Patient_Name = Obj.Name;
            patient.Email = Obj.Email;
            patient.Ph_Number = Obj.Ph_Number;
            patient.Password = Obj.Password;
            patient.UserRole_Id = 18;
            patient.status = true;
            _manager.Add(patient);
            _manager.SaveChanges();
            response.Result = "Inserted successfully";
            response.ObjectData = patient;
            return response;
            //}
            //else
            //{
            //    response.Result = "user already exists";
            //    return response;
            //}
        }

        public ResponseClass UpdateRoll(Reg_Role_Update Obj1)
        {
            ResponseClass response = new ResponseClass();
            Patient_Login patient = _manager.Patients_Login_Data.Where(row => row.Patient_Id == Obj1.Patient_Id).FirstOrDefault();

            if (patient == null)
            {
                response.Result = "Already Exists";
                return response;
            }
            else
            {

                //     patient.Patient_Id = Obj1.Patient_Id;
                patient.UserRole_Id = Obj1.UserRole_Id;
                patient.status = true;
                _manager.Patients_Login_Data.Update(patient);
                _manager.SaveChanges();
                response.Result = "Updated successfully";
                response.ObjectData = patient;
                return response;
            }
        }


    }
}
