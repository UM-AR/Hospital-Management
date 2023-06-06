using Hospital_Management.DB_Classes;
using Hospital_Management.Models;

namespace Hospital_Management.Repository.IRepository
{
    public interface IUserRole
    {
        List<User_Role> GetUserRole();
        ResponseClass UserRoleInsertion(UserRole_Insertion Obj1);
        ResponseClass UpdateUserRole(UserRole_Updation Obj1);
        ResponseClass UserRoleDeletion(UserRole_Deletion Obj1);
    }
}
