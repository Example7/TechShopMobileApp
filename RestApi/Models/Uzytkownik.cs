namespace RestApi.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string HasloHash { get; set; } = null!;
        public string Rola { get; set; } = "User";
    }
}
