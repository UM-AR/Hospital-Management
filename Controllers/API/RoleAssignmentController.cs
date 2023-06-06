using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Models.ViewModels;
using Hospital_Management.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using V1.Login.Controllers.API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management.Controllers.API
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignmentController : MyParentController
    {

        HospitalManager hospitalManager;
        IRoleAssignment _role;

        //Iconfiguration

        public RoleAssignmentController(HospitalManager hospitalManager,IRoleAssignment roleAssignment)
        {
            this.hospitalManager = hospitalManager;
            _role = roleAssignment;
        }


        
        //Get Permissions against UserRole Id
       
        // [Authorize]
        [HttpGet]
        [Route("GetUserPermissions")]
        public List<Permissions> GetUserPermissions()
        {
            return _role.GetUserPermissions();
        }


        //Role_Assignment
        //GET_ROle_ASsignment
        [HttpGet]
        [Route("GetRoleAssignmentDATA")]
        public List<AssigmentRole_Data> GetRoleAssignmentDATA()
        {
            return _role.GetRoleAssignmentDATA();
        }

        //insert
        [HttpPost]
        [Route("InsertRoleAssignment")]

        public ResponseClass InsertRoleAssignment(RoleAssignment_Insertion userObject)
        {
            return _role.InsertRoleAssignment(userObject);
        }
        //Update Role_Assignment
        [HttpPut]
        [Route("UpdateUserRole")]
        public ResponseClass UpdateUserRole(RoleAssigmnet_Updation Obj1)
        {
            return _role.UpdateUserRole(Obj1);
        }

        // Role_Assignment delete
        [HttpDelete]
        [Route("DeleteUserRole")]
        public ResponseClass DeleteUserRole(RoleAssignment_Deletion Obj1)
        {
            return _role.DeleteUserRole(Obj1);
        }
    }
} 