using Forum.DBContext;
using Forum.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationContext context;
        private readonly IUsers allUsers;
        private readonly IAllMessages allMessages;
        public AdminRepository(ApplicationContext _context, IUsers _users, IAllMessages _allMessages)
        {
            context = _context;
            allUsers = _users;
            allMessages = _allMessages;
        }

        public User UpdateRole(int userId, int roleId)//Изменить роль пользователя
        {
            User user = allUsers.FindUserById(userId);
            Role role = allUsers.GetRoleById(roleId);
            user.Role = role;
            context.SaveChanges();
            return user;
        }
        public User Ban(int userId)//Забанить пользователя
        {
            User user = allUsers.FindUserById(userId);
            user.IsBanned = true;
            context.SaveChanges();
            return user;
        }
        public User Unban(int userId)//Забанить пользователя
        {
            User user = allUsers.FindUserById(userId);
            user.IsBanned = false;
            context.SaveChanges();
            return user;
        }

        public bool DeleteMessage(int messageId)
        {
            Message message = allMessages.FindMessageById(messageId);
            context.Remove(message);
            context.SaveChanges();
            return true;
        }

        public bool DeleteSection(QSection section)
        {
            context.Remove(section);
            context.SaveChanges();
            return true;

        }

        public bool DeleteSection(Section section)
        {
                context.Remove(section);
                context.SaveChanges();
                return true;
        }

        public bool EditMessage(Message message, string text)
        {
            message.Text = text;
            context.SaveChanges();
            return true;

        }

        public bool EditSection(Section section, string Name)
        {
            return true;
        }

        public bool EditSection(QSection section, string Name)
        {
            return true;
        }

        
    }
}
