using System.Text;

namespace singleResponsibilityPrinciple
{
    public class UserRepo
    {
        private static UserStorage<User> _storage;

        public UserRepo()
        {
            _storage = new();
            InitializeData();
        }

        private void InitializeData()
        {
            _storage.Add(new User()
            {
                Id = 1,
                Username = "jamecho",
                UserCodes = new List<double>() { 4.1, 2.1 }
            });
            _storage.Add(new User() { Id = 2, Username = "jara", UserCodes = new List<double>() { 4.5, 4.1 } });
            _storage.Add(new User() { Id = 3, Username = "tiche", UserCodes = new List<double>() { 3.2, 5.0 } });
        }

        public IEnumerable<User> GetAllUsers() 
        {
            return _storage.GetAll();
        }

        // This method is not following SPR
        // This should be in a different class for example "ExportHelper"
        // So a new class named "ExportHelper" will be created
        //public void Export()
        //{
        //    IEnumerable<User> users = GetAllUsers();
        //    string csv = String.Join(",", users.Select(x => x.ToString()).ToArray());
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("Id;Username;UserCodes");
        //    foreach (User user in users)
        //    {
        //        sb.AppendLine($"{user.Id};{user.Username};{string.Join("|", user.UserCodes)}");
        //    }
        //    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.csv"), sb.ToString(), Encoding.Unicode);
        //}
    }
}
