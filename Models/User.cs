using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class User
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Придумайте никнейм")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Не введен Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не введен пароль")]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public List<Message> Messages { get; set; }

        public bool IsBanned { get; set; }
        public DateTime? DateOfBan { get; set; }
        public DateTime? TermOfBanned { get; set; }
    }
}
