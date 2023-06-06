using Hospital_Management.DB_Classes;
using Hospital_Management.Models;

namespace Hospital_Management.Repository.IRepository
{
    public interface IPermimssions
    {
         List<Permissions> GetPermissions();
         ResponseClass PermissionsInsertion(Permissions_Insertion Obj1);
        ResponseClass UpdatePermissions(Permissions_Updation Obj1);
        ResponseClass DeletePermission(Permission_Deletion Obj);
    }
}
