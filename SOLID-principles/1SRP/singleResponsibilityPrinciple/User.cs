namespace singleResponsibilityPrinciple
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<double> UserCodes { get; set; }

        public User()
        {
            Name = string.Empty;
            UserCodes = new List<double>();

        }
        public User(int id, string username, List<double> usercodes)
        {
            Id = id;
            Username = username;
            UserCodes = usercodes;
        }
    }
}
