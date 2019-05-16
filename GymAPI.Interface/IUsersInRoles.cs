using System.Collections.Generic;
using GymAPI.Models;
using GymAPI.ViewModels;

namespace GymAPI.Interface
{
    public interface IUsersInRoles
    {
        bool AssignRole(UsersInRoles usersInRoles);
        bool CheckRoleExists(UsersInRoles usersInRoles);
        bool RemoveRole(UsersInRoles usersInRoles);
        List<AssignRolesViewModel> GetAssignRoles();
    }
}
