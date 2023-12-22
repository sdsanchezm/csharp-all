using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace csv1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\PATH\\PATH\\csharp-all\\csv1\\file.csv";

            var records = ReadCsvFile<CsvRecord>(filePath);

            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name1}, Number: {record.Number2}, Code: {record.Code3}");
            }
        }

        static List<T> ReadCsvFile<T>(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

    }

    public class CsvRecord
    {
        public string Name1 { get; set; }
        public int Number2 { get; set; }
        public string Code3{ get; set; }
    }
}