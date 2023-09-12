using System.Text;

namespace DependencyInversionPrinciple3.Models
{
    public class Logbook : ILogbook
    {
        public void Add(string descriptionString)
        {
            File.AppendAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.logbook.txt"), $"{descriptionString}\n", Encoding.Unicode);
        }
    }
}