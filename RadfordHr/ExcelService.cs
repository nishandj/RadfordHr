using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadfordHr
{
    public class ExcelService
    {
        public static XLWorkbook GenerateExcel<T>(List<T> data, string sheetName = "Sheet1", int[] width = null)
        {
            var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add(sheetName);

                // Assuming T is a class with properties
                var properties = typeof(T).GetProperties();

                // Add header row with bold style
                for (int i = 0; i < properties.Length; i++)
                {
                    var propertyNameWithSpaces = ConvertCamelCaseToSpaces(properties[i].Name);
                    var cell = worksheet.Cell(1, i + 1);
                    cell.Value = propertyNameWithSpaces;

                    // Apply bold style to the header cell
                    cell.Style.Font.Bold = true;
                }

                // Freeze the header row
                worksheet.SheetView.FreezeRows(1);

                // Add data rows
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < properties.Length; j++)
                    {
                        var value = properties[j].GetValue(data[i]);
                        var cellValue = (value != null) ? value.ToString() : "";

                        // Check if the value is an integer
                        if (int.TryParse(cellValue, out int intValue))
                        {
                            // Assign the integer value to the cell
                            worksheet.Cell(i + 2, j + 1).Value = intValue;
                        }
                        else
                        {
                            // Not an integer, proceed with the default string value
                            worksheet.Cell(i + 2, j + 1).Value = cellValue;
                        }
                    }
                }

                // Set column widths to the maximum of default width (15) or header text length
                for (int i = 0; i < properties.Length; i++)
                {
                    int colWidth = 6;
                    if (width != null && width.Length > i)
                    {
                        colWidth = width[i];
                    }
                    var headerText = ConvertCamelCaseToSpaces(properties[i].Name);
                    var columnWidth = Math.Max(15, (headerText.Length + colWidth));
                    //worksheet.Column(i + 1).Width = columnWidth;
                    worksheet.Column(i + 1).AdjustToContents();
                }

                //using (var stream = new MemoryStream())
                //{
                //    workbook.SaveAs(stream);
                //    return stream.ToArray();
                //}
                return workbook;
            
        }
        public static string ConvertCamelCaseToSpaces(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var result = new StringBuilder(input[0].ToString());

            for (int i = 1; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    result.Append(' ');
                }

                result.Append(input[i]);
            }

            return result.ToString();
        }
    }
}
