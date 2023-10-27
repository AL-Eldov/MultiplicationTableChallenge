using System.ComponentModel.DataAnnotations;

namespace MTC_project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина логина должна быть от 3 до 20 символов")] 
        public string? Name { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть от 3 до 20 символов")]
        public string? Password { get; set; }
        public Ranks Rank { get; set; }
        public int Rating { get; set; }

    }
}
