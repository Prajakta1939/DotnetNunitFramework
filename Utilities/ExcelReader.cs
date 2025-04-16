using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;

namespace TestAutomation.Utilities
{
    public class ExcelReader
    {
        public static List<Dictionary<string, string>> ReadExcel(string filePath)
        {
            var data = new List<Dictionary<string, string>>();

            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);

                // Read header
                var headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;

                // Loop rows
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row == null) continue;

                    var rowData = new Dictionary<string, string>();

                    for (int j = 0; j < cellCount; j++)
                    {
                        string header = headerRow.GetCell(j)?.ToString();
                        string cellValue = row.GetCell(j)?.ToString();
                        rowData[header] = cellValue;
                    }

                    data.Add(rowData);
                }
            }

            return data;
        }
    }
}
