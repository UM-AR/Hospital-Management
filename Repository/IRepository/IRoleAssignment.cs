using Hospital_Management.DB_Classes;
using Hospital_Management.Models;
using Hospital_Management.Models.ViewModels;

namespace Hospital_Management.Repository.IRepository
{
    public interface IRoleAssignment
    {
        List<Permissions> GetUserPermissions();
        List<AssigmentRole_Data> GetRoleAssignmentDATA();
        ResponseClass InsertRoleAssignment(RoleAssignment_Insertion userObject);
        ResponseClass UpdateUserRole(RoleAssigmnet_Updation Obj1);
         ResponseClass DeleteUserRole(RoleAssignment_Deletion Obj1);
    }
}
