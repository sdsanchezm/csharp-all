using System.Collections;
using System.Reflection;
using System.Text;

namespace singleResponsibilityPrinciple
{
    public class ExportHelper2<T>
    {
        public void ExportToCSV2(IEnumerable<T> items)
        {
            var stringBuilder = new StringBuilder();
            var header = GetTitleProperties();
            stringBuilder.AppendLine(header);

            foreach (var item in items)
            {
                var dataLine = GetLineCSV(item);
                stringBuilder.AppendLine(dataLine);
            }

            var pathOfFile = SetPathOfFile();
            File.WriteAllText(pathOfFile, stringBuilder.ToString(), Encoding.Unicode);
        }

        private string GetTitleProperties()
        {
            var properties = typeof(T).GetProperties();
            var header = string.Join(";", properties.Select(prop => prop.Name));
            return header;
        }

        private string GetLineCSV(T item)
        {
            var properties = typeof(T).GetProperties();
            var dataRow = string.Join(";", properties.Select(prop => GetPropertyValue(prop, item)));
            return dataRow;
        }

        private string GetPropertyValue(PropertyInfo prop, T item)
        {
            var propValue = prop.GetValue(item);
            var propType = prop.PropertyType;

            if (propType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(propType))
            {
                var enumerable = (IEnumerable)propValue;
                var values = enumerable.Cast<object>().Select(x => x.ToString());
                return string.Join("|", values);
            }

            return propValue?.ToString();
        }

        private string SetPathOfFile()
        {
            var typeOfData = typeof(T).Name;
            var nameOfFile = $"File.{typeOfData}.csv";
            var pathOfFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nameOfFile);
            return pathOfFile;
        }

    }
}
