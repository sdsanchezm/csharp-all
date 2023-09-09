using System.Reflection;
using System.Text;

namespace singleResponsibilityPrinciple
{
    public class ExportCSVGeneric1<T>
    {
        public static void Export<T>(IEnumerable<T> items) where T : class
        {
            string csv = String.Join(",", items.Select(x => x.ToString()).ToArray());
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id;Username;UserCodes");
            foreach (var item in items)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                var id = properties.FirstOrDefault(prop => prop.Name == "Id")?.GetValue(item);
                var username = properties.FirstOrDefault(prop => prop.Name == "Username")?.GetValue(item);
                //var usercodes = properties.FirstOrDefault(prop => prop.Name == "UserCodes")?.GetValue(item);

                //sb.AppendLine($"{id};{username};{string.Join("|", usercodes as IEnumerable<object>)}");
                sb.AppendLine($"{id};{username};");
            }

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{typeof(T).Name}s.csv"), sb.ToString(), Encoding.Unicode);
        }

    }
}
