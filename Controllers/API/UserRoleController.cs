using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using V1.Login.Controllers.API;
namespace Hospital_Management.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : MyParentController
    {


            HospitalManager hospitalManager;
        IUserRole _userRole;
        IConfiguration _config;
        ILogger _logger;

            public UserRoleController(HospitalManager hospitalManager,IUserRole userRole,IConfiguration config,ILogger<UserRoleController> logger)
            {
                this.hospitalManager = hospitalManager;
            _config = config;
              _userRole=userRole;
            _logger = logger;
        }

        //Get USerRole


        //        try
        //        {
        //            _logger.LogInformation("Getting customer details");

        //            var result = _customerService.GetCustomers();
        //            if (result == null)
        //                throw new ApplicationException("Getting errors while fetching customer details");

        //            return Ok(result);
        //    }
        //        catch (Exception e)
        //        {
        //            _logger.LogError(e.Message);
        //            return BadRequest("Internal server error");
        //}


        //_logger.LogInformation("Getting customer details");

        //var result = _customerService.GetCustomers();
        //if (result.Count == 0)
        //    throw new ApplicationException("Invalid Token");

        //return Ok(result);

        [HttpGet]
            [Route("GetUserRole")]           
            public List<User_Role> GetUserRole()
            {
            _logger.LogInformation("Getting user role");

            var result = _userRole.GetUserRole();
            if (result.Count == 0)
            throw new ApplicationException("Invalid Token");

            return _userRole.GetUserRole();
        }




        //UserRole Insertion
        [HttpPost]
            [Route("UserRoleInsertion")]
            public ResponseClass UserRoleInsertion(UserRole_Insertion Obj1)
            {
            return _userRole.UserRoleInsertion(Obj1);
            }
            //Update UserROle
            [HttpPut]
            [Route("UpdateUserRole")]
            public ResponseClass UpdateUserRole(UserRole_Updation Obj1)
            {
            return _userRole.UpdateUserRole(Obj1);
            }

            //UserRole delete
            [HttpDelete]
            [Route("UserRoleDeletion")]
            public ResponseClass UserRoleDeletion(UserRole_Deletion Obj1)
            {
            return _userRole.UserRoleDeletion(Obj1);
            }
        }
}
