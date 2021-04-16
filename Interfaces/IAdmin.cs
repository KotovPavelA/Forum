using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Interfaces
{
    public interface IAdmin
    {
        User UpdateRole(int userId, int roleId);
        User Ban(User user, DateTime term);

        bool DeleteSection(Section section);
        bool DeleteSection(QSection section);

        bool EditSection(Section section, string Name);
        bool EditSection(QSection section, string Name);

        bool DeleteMessage(int messageId);
        bool EditMessage(Message message, string text);
    }
}
