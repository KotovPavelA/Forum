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
            //Инициализация начальных объектов и добавление в базу данных

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
                Email = "AdamS@mail.ru",
                Password = "Yap_Admin25",
                Role = adminRole,
                IsBanned = false

            };
            User veronica = new User()
            {
                Name = "Veronica",
                SecondName = "Thomas",
                Nickname = "VThomas11",
                Email = "ThomVer@mail.ru",
                Password = "25.July",
                Role = moderRole,
                IsBanned = false
            };
            User garry = new User()
            {
                Name = "Garry",
                SecondName = "Axe",
                Nickname = "x_AXE7AXE_x",
                Email = "love.mom88@mail.ru",
                Password = "love.mom888",
                Role = userRole,
                IsBanned = false
            };

            

            Section section  = new Section(){Name = "Природа", Creater = adam};
            Section msection = new Section() { Name = "Самые интересные фильмы", Creater = veronica, CreaterId = veronica.Id };
            QSection qsection = new QSection() { Name = "Тату. За или против?", Creater = garry, CreaterId = garry.Id };

            Chapter chapter = new Chapter() { Name = "Природа", Sections = new List<Section>() { section, msection } };
            Chapter chapter1 = new Chapter() { Name = "Тату", Sections = new List<Section>() { qsection } };


            if (!context.Chapters.Any())
                context.Chapters.AddRange(chapter,chapter1);
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
                        Likes = new List<Like>()
                        {
                            new Like(){User = veronica},
                            new Like(){User = adam}
                        },
                        Date = DateTime.Now,
                    },
                    new Message()
                    {
                        User = veronica,
                        Text = "Посмотрите старое кино",
                        Section = msection,
                        Likes = new List<Like>()
                        {
                            new Like(){User = veronica},
                            new Like(){User = adam}
                        },
                        Date = DateTime.Now
                    },
                    new Message()
                    {
                        User = garry,
                        Text = "На зоне по другому никак",
                        Section = qsection,
                        Date = DateTime.Now,
                        Likes = new List<Like>()
                    }
                    );;

            }
            
            context.SaveChanges();

        }
        
    }
}
