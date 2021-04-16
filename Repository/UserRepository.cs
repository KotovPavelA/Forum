using Forum.DBContext;
using Forum.Interfaces;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class UserRepository : IUsers
    {
        private readonly ApplicationContext context;
        public UserRepository(ApplicationContext _context)
        {
            context = _context;
        }
        public User FindUserById(int id)
        {
            var u = context.Users.Include(m => m.Messages).First(i => i.Id == id);
            u.Messages = context.Messages.Include(s => s.Section).Where(i => i.UserId == id).OrderBy(d => d.Date).ToList();
            return u;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }
        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return context.Roles.Find(id);
        }
    }
}
