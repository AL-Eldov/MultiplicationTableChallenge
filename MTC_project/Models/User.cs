namespace MTC_project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int Money { get; set; }
        public Ranks Rank { get; set; }
        public int Rating { get; set; }

    }
}
