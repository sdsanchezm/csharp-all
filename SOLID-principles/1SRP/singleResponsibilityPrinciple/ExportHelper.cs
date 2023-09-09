using System.Text;

namespace singleResponsibilityPrinciple
{
    public class ExportHelper
    {
        public static void ExportCSV(IEnumerable<User> userLocal)
        {
            IEnumerable<User> users = userLocal;
            string csv = String.Join(",", users.Select(x => x.ToString()).ToArray());
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id;Username;UserCodes");
            foreach (User user in users)
            {
                sb.AppendLine($"{user.Id};{user.Username};{string.Join("|", user.UserCodes)}");
            }
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.csv"), sb.ToString(), Encoding.Unicode);
        }
    }
}
