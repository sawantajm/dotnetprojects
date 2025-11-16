using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MilkManagementSystem.Excel
{
    public class Rates
    {
        private Dictionary<(double SNF, double Fat), double> _rateMatrix = new();
    
        double rate = 0;
        public void CalculateMilkRate(double FatRate, double SNFRate)
        {
            double fatRate = FatRate;
            double snfRate = SNFRate;
            string filePath = @"D:\Project dairy\Rate.xlsx";
            
            LoadMatrix(filePath, fatRate,snfRate);

            // AddOrUpdateRate(filePath, snf, fat, rate);

        }

        static void AddOrUpdateRate(string filePath, double snf, double fat, double rate)
        {

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);

                int snfRow = -1;
                int fatCol = -1;

                // 🔍 Find Fat Column from row 1
                for (int col = 2; col <= 100; col++)
                {
                    var cellValue = worksheet.Cell(1, col).GetValue<double>();
                    if (Math.Abs(cellValue - fat) < 0.001)
                    {
                        fatCol = col;
                        break;
                    }
                }

                // 🔍 Find SNF Row from column A
                for (int row = 2; row <= 100; row++)
                {
                    var cellValue = worksheet.Cell(row, 1).GetValue<double>();
                    if (Math.Abs(cellValue - snf) < 0.001)
                    {
                        snfRow = row;
                        break;
                    }
                }

                // If SNF or Fat not found, throw error
                if (snfRow == -1 || fatCol == -1)
                {
                    Console.WriteLine("SNF or Fat not found in the sheet.");
                    return;
                }

                // ✅ Write rate at the matching cell
                worksheet.Cell(snfRow, fatCol).Value = rate;

                // 💾 Save changes
                workbook.Save();
            }

        }


        public void LoadMatrix(string filePath,double fatRate, double snfRate)
        {
            using var workbook = new XLWorkbook(filePath);
            var sheet = workbook.Worksheets.First();

            // Read Fat headers from row 1 (starting column 2)
            var fatHeaders = new List<double>();
            var snfList = new List<double>();
            int col = 2;
            while (!sheet.Cell(1, col).IsEmpty())
            {
                if (double.TryParse(sheet.Cell(1, col).GetValue<string>(), out double fat))
                    fatHeaders.Add(fat);
                col++;
            }

            // Read SNF and prices
            int row = 2;
            while (!sheet.Cell(row, 1).IsEmpty())
            {
                if (!double.TryParse(sheet.Cell(row, 1).GetValue<string>(), out double snf))
                {
                    
                    row++;
                    continue;
                }
                snfList.Add(snf);
                row++;
            }

            foreach(var fatitem in fatHeaders)
            {
                foreach (var SNFitem in snfList)
                {
                    rate = (fatRate * fatitem) +(snfRate * SNFitem);
                    AddOrUpdateRate(filePath, SNFitem, fatitem, rate);
                }
               
            }
        }
    }
}