using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Models.Reg_Data;
using Hospital_Management.Models.ViewModels;
using Hospital_Management.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using V1.Login.Controllers.API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : MyParentController
    {
        HospitalManager Helper;
        IConfiguration _config;
        IHospitalManager _hospitalManager;

        public HospitalController(HospitalManager HospitalManager_Object, IConfiguration config,IHospitalManager hospitalManager) 
        {
            this.Helper = HospitalManager_Object;
            _config = config;
            _hospitalManager = hospitalManager;
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("Patient_Login")]
        public ResponseClass Login_User(Login_User User_Info)
        {
            return _hospitalManager.Login_User(User_Info);           
        }


        // GET: api/<HospitalController>
        [HttpGet]
        [Route("Get_Patient_Data_List")]
        public List<Patient_Login> Get_Patient_Data_List()
        {
            return _hospitalManager.Get_Patient_Data_List();

        }

        [HttpGet]
        [Route("Get_Patient_Data")]
        public List<Reg_Data> Get_Patient_Data()
        {
            return _hospitalManager.Get_Patient_Data();
        }


        [HttpPost]
        [Route("UserRegistration")]
        public ResponseClass Register_Patient(Patient_Registration Obj)
        {
          return _hospitalManager.Register_Patient(Obj);
        }

            [HttpPut]
            [Route("UpdateRoll")]

            public ResponseClass UpdateRoll(Reg_Role_Update Obj1)
            {
            return _hospitalManager.UpdateRoll(Obj1);
            }
        }
    }


