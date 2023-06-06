using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Models.ViewModels;
using Hospital_Management.Repository.IRepository;

namespace Hospital_Management.Repository.Repository_Class
{
    public class RoleAssignmetnRep : IRoleAssignment
    {
        HospitalManager _manager;
        IConfiguration _config;
        public RoleAssignmetnRep(HospitalManager manager, IConfiguration config)
        {
            this._manager = manager;
            _config = config;
        }


        //get User Per
        public List<Permissions> GetUserPermissions()
        {
            int Userid = 13;

            List<Permissions> UserPermission = (from Patient in _manager.Patients_Login_Data.Where(x => x.Patient_Id == Userid)
                                                join RoleAssign in _manager.Role_Assignment
                                                on Patient.UserRole_Id equals RoleAssign.UserRole_Id
                                                join Permissions in _manager.Permissions
                                                on RoleAssign.Permission_Id equals Permissions.Permission_Id
                                                select Permissions).ToList();
            return UserPermission;
        }

        //get roleAssingment Data
        public List<AssigmentRole_Data> GetRoleAssignmentDATA()
        {
            List<AssigmentRole_Data> GetRoleAssignment = (from RA in _manager.Role_Assignment
                                                          join UsrRole in _manager.User_Role
                                                          on RA.UserRole_Id equals UsrRole.UserRole_Id
                                                          join Per in _manager.Permissions on RA.Permission_Id equals Per.Permission_Id
                                                          select new AssigmentRole_Data
                                                          {
                                                              Role_Assignment_Id = RA.Role_Assignment_Id,
                                                              UserRole_Id = UsrRole.UserRole_Id,
                                                              Permission_Id = Per.Permission_Id,
                                                              UserRole_Title = UsrRole.UserRole_Title,
                                                              Permission_Title = Per.Permission_Title,
                                                              Permission_URL = Per.Permission_URL
                                                          }).ToList();
            return GetRoleAssignment;
        }

        //insert roleAssignment
        public ResponseClass InsertRoleAssignment(RoleAssignment_Insertion userObject)
        {
            ResponseClass response = new ResponseClass();

            Role_Assignment role_Assignment = _manager.Role_Assignment.Where(row => row.Role_Assignment_Id == userObject.Role_Assignment_Id).FirstOrDefault();


            if (role_Assignment == null)
            {
                Role_Assignment roleAssignment = new Role_Assignment();
                roleAssignment.Role_Assignment_Id = userObject.Role_Assignment_Id;
                roleAssignment.Permission_Id = userObject.Permission_Id;
                roleAssignment.UserRole_Id = userObject.UserRole_Id;
                roleAssignment.Status = true;
                _manager.Role_Assignment.Add(roleAssignment);

                _manager.SaveChanges();

                response.Result = "Inserted successfully";
                response.ObjectData = roleAssignment;
                return response;
            }
            else
            {
                response.Result = "Already Exists";
                return response;
            }
        }

        //update userRole
        public ResponseClass UpdateUserRole(RoleAssigmnet_Updation Obj1)
        {
            ResponseClass response = new ResponseClass();
            Role_Assignment role = _manager.Role_Assignment.Where(row => row.Role_Assignment_Id == Obj1.Role_Assignment_Id).FirstOrDefault();

            if (role == null)
            {
                response.Result = "Already Exists";
                return response;
            }
            else
            {

                role.UserRole_Id = Obj1.UserRole_Id;
                role.Permission_Id = Obj1.Permission_Id;
                role.Status = true;
                _manager.Role_Assignment.Update(role);
                _manager.SaveChanges();
                response.Result = "Updated successfully";
                response.ObjectData = role;
                return response;
            }
        }

        //delete userRole
        public ResponseClass DeleteUserRole(RoleAssignment_Deletion Obj1)
        {
            ResponseClass response = new ResponseClass();

            Role_Assignment role = _manager.Role_Assignment.Where(row => row.Role_Assignment_Id == Obj1.Role_Assignment_Id).FirstOrDefault();
            if (role == null)
            {
                response.Result = "Invalid ID";
                return response;
            }
            else
            {

                role.Status = false;
                _manager.Role_Assignment.Update(role);
                _manager.SaveChanges();
                response.Result = "Deleted successfully";
                response.ObjectData = Obj1;
                return response;
            }

        }
    }
}
