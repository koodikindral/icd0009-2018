namespace WebApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}