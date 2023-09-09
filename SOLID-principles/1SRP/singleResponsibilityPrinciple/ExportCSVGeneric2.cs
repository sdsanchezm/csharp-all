using System.Text;

namespace singleResponsibilityPrinciple
{
    public class ExportCSVGeneric2<T>
        {
            public void ExportToCSV2(IEnumerable<T> items)
            {
                StringBuilder sb = new StringBuilder();
                string header = "";
                string[] dataRows = new string[items.Count()];
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += $"{prop.Name};";
                    for (int i = 0; i < items.Count(); i++)
                    {
                        var propValue = prop.GetValue(items.ToArray()[i]);
                        var propType = propValue.GetType();
                        if (propType.Name != nameof(String)
                            && propType.GetInterface(nameof(IEnumerable<T>)) != null)
                        {
                            dataRows[i] += $"{String.Join("|", (propValue as IEnumerable<T>).Cast<object>().Select(x => x.ToString()))};";

                        }
                        else
                        {
                            dataRows[i] += $"{propValue};";
                        }
                    }
                }
                sb.AppendLine(header.Trim(';'));
                foreach (var dataRow in dataRows)
                {
                    sb.AppendLine(dataRow.Trim(';'));
                }
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Export_{typeof(T).ToString()}.csv"), sb.ToString(), Encoding.Unicode);
            }
        }


}
