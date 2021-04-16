using Forum.Interfaces;
using Forum.Models;
using Forum.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{

    public class AdminController : Controller
    {
        private readonly IAdmin adminFunc;
        private readonly IUsers allUsers;
        private readonly IAllMessages allMessages;
        public AdminController(IAdmin _admin, IUsers _users, IAllMessages _allMessages)
        {
            adminFunc = _admin;
            allUsers = _users;
            allMessages = _allMessages;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditSection(Section section)
        {
            return Redirect("~/Admin/Section");
        }
        public IActionResult EditSection(QSection section)
        {
            return Redirect("~/Admin/Section");
        }
        public IActionResult DeleteSection(Section section)
        {
            adminFunc.DeleteSection(section);
            return Redirect("~/Admin/Index");
        }
        public IActionResult DeleteSection(QSection section)
        {
            adminFunc.DeleteSection(section);
            return Redirect("~/Admin/Index");
        }

        public IActionResult Ban(User user, DateTime term)
        {
            adminFunc.Ban(user, term);
            return Redirect("~/Admin/Index");
        }


        [HttpGet]
        public IActionResult UpdateUserRole()
        {
            UserViewModel model = new UserViewModel()
            {
                Users = allUsers.GetAllUsers(),
                Roles = allUsers.GetAllRoles()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateUserRole(int userId, int roleId)
        {

            adminFunc.UpdateRole(userId, roleId);
            return Redirect("~/Admin/UpdateUserRole");
        }

        [HttpGet]
        public IActionResult DeleteMessage()
        {

            MessagesViewModel model = new MessagesViewModel()
            {
                Messages = allMessages.GetAllMessages()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteMessage(int messageId)
        {
            adminFunc.DeleteMessage(messageId);
            return Redirect("~/Admin/DeleteMessage");
        }
        public IActionResult EditMessage(Message message, string text)
        {
            adminFunc.EditMessage(message, text);
            return Redirect("~/Admin/EditMessage");
        }
    }
}
