namespace OutsourceSystem.Api.Business.Models.Main
{
    public class Outsourcer
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }
    }
}