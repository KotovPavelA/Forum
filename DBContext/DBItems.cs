using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DBContext
{
    public class DBItems
    {
        public static void Initial(ApplicationContext context)
        {
            
            Role adminRole = new Role()
            {
                Name = "Admin",
            };
            Role moderRole = new Role()
            {
                Name = "Moderator"
            };
            Role userRole = new Role()
            {
                Name = "User"
            };
            User adam = new User() 
            {
                Name = "Adam",
                SecondName = "Sendler",
                Nickname = "AdminSendler",
                Password = "Yap_Admin25",
                Role = adminRole,
                IsBanned = false

            };
            User veronica = new User()
            {
                Name = "Veronica",
                SecondName = "Thomas",
                Nickname = "VThomas11",
                Password = "25.July",
                Role = moderRole,
                IsBanned = false
            };
            User garry = new User()
            {
                Name = "Garry",
                SecondName = "Axe",
                Nickname = "x_AXE7AXE_x",
                Password = "love.mom888",
                Role = userRole,
                IsBanned = false
            };

            Section section  = new Section(){Name = "Природа"};
            Section msection = new Section() { Name = "Самые интересные фильмы" };
            QSection qsection = new QSection() { Name = "Тату. За или против?" };


            if (!context.Roles.Any())
                context.Roles.AddRange(adminRole, moderRole, userRole);

            if (!context.Sections.Any())
                context.Sections.AddRange(section,msection,qsection);

            if (!context.Users.Any())
                context.Users.AddRange(adam,veronica,garry);

            if (!context.QSectionAnswers.Any())
            {
                context.QSectionAnswers.AddRange(
                    new QSectionAnswer()
                    {
                        Name = "За",
                        VolumeOfVote = 1,
                        Section = qsection
                    },
                    new QSectionAnswer()
                    {
                        Name = "Против",
                        VolumeOfVote = 0,
                        Section = qsection
                    }
                    );
            }
            if (!context.Messages.Any())
            {
                context.Messages.AddRange(
                    new Message()
                    {
                        User = adam,
                        Text = "Люблю животных",
                        Section = section,
                        Date = DateTime.Now,
                    },
                    new Message()
                    {
                        User = veronica,
                        Text = "Посмотрите старое кино",
                        Section = msection,
                        Date = DateTime.Now
                    },
                    new Message()
                    {
                        User = garry,
                        Text = "На зоне по другому никак, ауф",
                        Section = qsection,
                        Date = DateTime.Now
                    }
                    );

            }
            
            context.SaveChanges();

        }
        
    }
}
