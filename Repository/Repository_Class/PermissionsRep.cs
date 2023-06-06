using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Repository.IRepository;

namespace Hospital_Management.Repository.Repository_Class
{
    public class PermissionsRep:IPermimssions
    {
        private readonly HospitalManager _manager;
        private readonly IConfiguration _configuration;
        public PermissionsRep(HospitalManager manager, IConfiguration configuration)
        {
            this._manager = manager;
            _configuration = configuration;
        }

        //get permissions
        public List<Permissions> GetPermissions()
        {
            return _manager.Permissions.Where(rows => rows.Status == true).ToList();
        }

        //insert permssions
        public ResponseClass PermissionsInsertion(Permissions_Insertion Obj1)
        {
            ResponseClass response = new ResponseClass();
            Permissions permissions1 = _manager.Permissions.Where(row => row.Permission_Title == Obj1.Permission_Title && row.Permission_URL == Obj1.Permission_URL).FirstOrDefault();

            if (permissions1 == null)
            {
                Permissions permissions = new Permissions();
                permissions.Permission_Id = Obj1.Permission_Id;
                permissions.Permission_Title = Obj1.Permission_Title;
                permissions.UserRole_Id = Obj1.UserRole_Id;
                permissions.Permission_URL = Obj1.Permission_URL;

                permissions.Status = true;
                _manager.Permissions.Add(permissions);
                _manager.SaveChanges();
                response.Result = "Inserted Successfully";
                response.ObjectData = permissions;
                return response;
            }
            else
            {
                response.Result = "Already Exists";
                return response;
            }
        }
        //update permissions
        public ResponseClass UpdatePermissions(Permissions_Updation Obj1)
        {
            ResponseClass response = new ResponseClass();


            Permissions permissions1 = _manager.Permissions.Where(row => row.Permission_Id == Obj1.Permission_Id).FirstOrDefault();

            if (permissions1 == null)
            {
                response.Result = "Already Exists";
                return response;
            }
            else
            {


                permissions1.Permission_Id = Obj1.Permission_Id;
                permissions1.Permission_Title = Obj1.Permission_Title;
                permissions1.Permission_URL = Obj1.Permission_URL;
                permissions1.Status = true;
                _manager.Permissions.Update(permissions1);
                _manager.SaveChanges();
                response.Result = "Updated successfully";
                response.ObjectData = permissions1;
                return response;
            }
        }
        //delete permssions
        public ResponseClass DeletePermission(Permission_Deletion Obj)
        {

            ResponseClass response = new ResponseClass();

            Permissions permissions1 = _manager.Permissions.Where(row => row.Permission_Id == Obj.Permission_Id).FirstOrDefault();

            if (permissions1 == null)
            {
                response.Result = "Invalid ID";
                return response;
            }
            else
            {

                permissions1.Status = false;
                _manager.Permissions.Update(permissions1);
                _manager.SaveChanges();
                response.Result = "Deleted successfully";
                response.ObjectData = Obj;
                return response;
            }
        }
    }
}
