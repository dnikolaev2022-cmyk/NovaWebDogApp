namespace WebDogApp.Models.UserComment
{
    public class IndexVM
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Comment { get; set; } = null!;
    }
}