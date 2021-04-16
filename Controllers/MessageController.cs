using Forum.Interfaces;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class MessageController : Controller
    {
        private readonly IAllSections allSections;
        private readonly IAllMessages allMessages;
        private readonly IUsers allUsers;


        public MessageController(IAllSections _allSections, IAllMessages _allMessages, IUsers _allUsers)
        {
            allSections = _allSections;
            allMessages = _allMessages;
            allUsers = _allUsers;
        }

        [Authorize]
        public IActionResult CreateMessage(int id, string text)
        {
            
            var c = int.Parse(User.Identity.Name);
            User user = allUsers.FindUserById(c);
            Section section = allSections.FindSectionById(id);
            allMessages.CreateMessage(user, section, text);
            return Redirect($"~/Section/Section/{section.Id}");
        }
        public IActionResult Like(int id)
        {
            Message message = allMessages.Like(id);
            return Redirect($"~/Section/Section/{message.SectionId}");
        }
    }
}
