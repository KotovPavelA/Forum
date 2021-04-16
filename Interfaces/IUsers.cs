using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interfaces
{
    public interface IUsers
    {
        User FindUserById(int id);
        List<User> GetAllUsers();
        Role GetRoleById(int id);
        List<Role> GetAllRoles();

    }
}
