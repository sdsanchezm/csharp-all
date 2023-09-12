
namespace DependencyInversionPrinciple3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<double> UserNumbers { get; set; }

        public User()
        {
            Username = string.Empty;
            UserNumbers = new List<double>();
        }

        public User(int id, string username, List<double> usernumber)
        {
            Id = id;
            Username = username;
            UserNumbers = usernumber;
        }
    }
}
