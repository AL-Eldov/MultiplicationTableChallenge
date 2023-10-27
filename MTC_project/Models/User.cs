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

        public void CheckRise()
        {
            switch (Rating)
            {
                case 0:
                    Rank = Ranks.Rank0;
                    break;
                case <= 10:
                    Rank = Ranks.Rank1;
                    break;
                case <= 50:
                    Rank = Ranks.Rank2;
                    break;
                case <= 100:
                    Rank = Ranks.Rank3;
                    break;
                case <= 200:
                    Rank = Ranks.Rank4;
                    break;
                case <= 300:
                    Rank = Ranks.Rank5;
                    break;
                case <= 400:
                    Rank = Ranks.Rank6;
                    break;
                case <= 500:
                    Rank = Ranks.Rank7;
                    break;
                case <= 750:
                    Rank = Ranks.Rank8;
                    break;
                case <= 1000:
                    Rank = Ranks.Rank9;
                    break;
                case > 1000:
                    Rank = Ranks.Rank10;
                    break;
            }
        }
    }
}
