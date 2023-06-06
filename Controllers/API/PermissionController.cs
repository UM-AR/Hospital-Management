using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using V1.Login.Controllers.API;

namespace Hospital_Management.Controllers.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : MyParentController
    {
        HospitalManager hospitalManager;
        IConfiguration _config;
        IPermimssions _permimssions;
        public PermissionController(HospitalManager hospitalManager, IConfiguration config, IPermimssions permimssions)
        {
            this.hospitalManager = hospitalManager;
            _config = config;
            _permimssions = permimssions;
           
        }


        //Get Permission       
        [HttpGet]
        [Route("GetPermissions")]
        public List<Permissions> GetPermissions()
        {
            return _permimssions.GetPermissions();
        }

        //Permission Insertion
        [HttpPost]
        [Route("PermissionsInsertion")]
        public ResponseClass PermissionsInsertion(Permissions_Insertion Obj1)
        {
            return _permimssions.PermissionsInsertion(Obj1);
        }

        //Update Permissions
        [HttpPut]
        [Route("UpdatePermissions")]
        public ResponseClass UpdatePermissions(Permissions_Updation Obj1)
        {
            return _permimssions.UpdatePermissions(Obj1);
        }

        //Delete Permissions
        [HttpDelete]
        [Route("DeletePermission")]

        public ResponseClass DeletePermission(Permission_Deletion Obj)
        {

            return _permimssions.DeletePermission(Obj);
        }
    }
}
