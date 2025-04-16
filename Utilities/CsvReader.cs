using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace TestAutomation.Utilities
{
    public class CsvReader
    {
       public static List<Dictionary<string, string>> ReadCsv(string filePath)
{
    var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
    var records = new List<Dictionary<string, string>>();

    using (var reader = new StreamReader(fullPath))
    using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
    {
        csv.Read();
        csv.ReadHeader();
        while (csv.Read())
        {
            var row = new Dictionary<string, string>();
            foreach (var header in csv.HeaderRecord)
            {
                row[header] = csv.GetField(header);
            }
            records.Add(row);
        }
    }

    return records;
}

    }
}
