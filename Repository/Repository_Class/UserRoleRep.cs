using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Repository.IRepository;

namespace Hospital_Management.Repository.Repository_Class
{
    public class UserRoleRep:IUserRole
    {
        HospitalManager _manager;
        public UserRoleRep(HospitalManager manager)
        {
            this._manager = manager;
        }

        //get UserRole
        public List<User_Role> GetUserRole()
        {
            return _manager.User_Role.Where(rows => rows.Status == true).ToList();
        }

        //insert userRole
        public ResponseClass UserRoleInsertion(UserRole_Insertion Obj1)
        {
            ResponseClass response = new ResponseClass();

            User_Role userRole = _manager.User_Role.Where(row => row.UserRole_Title == Obj1.UserRole_Title).FirstOrDefault();

            if (userRole == null)
            {
                Permissions permissions = new Permissions();
                User_Role userRole1 = new User_Role();

                userRole1.UserRole_Id = Obj1.UserRole_Id;
                userRole1.UserRole_Title = Obj1.UserRole_Title;
                userRole1.Status = true;
                _manager.User_Role.Add(userRole1);
                _manager.SaveChanges();
                response.Result = "Inserted Successfully";
                response.ObjectData = userRole1;
                return response;
            }
            else
            {
                response.Result = "Already Exists";
                return response;
            }
        }

        //update userROle
        public ResponseClass UpdateUserRole(UserRole_Updation Obj1)
        {
            ResponseClass response = new ResponseClass();
            User_Role userRole = _manager.User_Role.Where(row => row.UserRole_Id == Obj1.UserRole_Id).FirstOrDefault();

            if (userRole == null)
            {
                response.Result = "Already Exists";
                return response;
            }
            else
            {


                userRole.UserRole_Id = Obj1.UserRole_Id;
                userRole.UserRole_Title = Obj1.UserRole_Title;
                userRole.Status = true;
                _manager.User_Role.Update(userRole);
                _manager.SaveChanges();
                response.Result = "Updated successfully";
                response.ObjectData = userRole;
                return response;
            }
        }
        //UsereROle Delete
        public ResponseClass UserRoleDeletion(UserRole_Deletion Obj1)
        {
            ResponseClass response = new ResponseClass();

            User_Role userRole = _manager.User_Role.Where(row => row.UserRole_Id == Obj1.UserRole_Id).FirstOrDefault();
            if (userRole == null)
            {
                response.Result = "Invalid ID";
                return response;
            }
            else
            {

                userRole.Status = false;
                _manager.User_Role.Update(userRole);
                _manager.SaveChanges();
                response.Result = "Deleted successfully";
                response.ObjectData = Obj1;
                return response;
            }
        }

    }
}
