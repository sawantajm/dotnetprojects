using System;
using ClosedXML.Excel;

class Program
{
    static void Main()
    {
        string filePath = @"D:\Project dairy\Rate.xlsx";

        double snfStart = 8.0;
        double snfEnd = 9.0;
        double fatStart = 3.0;
        double fatEnd = 9.0; 

        GenerateSNFAndFatGrid(filePath, snfStart, snfEnd, fatStart, fatEnd);
        Console.WriteLine("Excel with SNF and Fat ranges generated successfully.");
    }

    static void GenerateSNFAndFatGrid(string filePath, double snfStart, double snfEnd, double fatStart, double fatEnd)
    {
        using (var workbook = new XLWorkbook())
        {
            var sheet = workbook.AddWorksheet("MilkRates");

            // 🔹 Write header: "SNF/Fat"
            sheet.Cell(1, 1).Value = "SNF/Fat";

            // 🔹 Write Fat values across row 1
            int fatCol = 2;
            for (double fat = fatStart; fat <= fatEnd + 0.001; fat += 0.1)
            {
                sheet.Cell(1, fatCol).Value = Math.Round(fat, 1);
                fatCol++;
            }

            // 🔹 Write SNF values down column A
            int snfRow = 2;
            for (double snf = snfStart; snf <= snfEnd + 0.001; snf += 0.1)
            {
                sheet.Cell(snfRow, 1).Value = Math.Round(snf, 1);
                snfRow++;
            }

            // Optional: Style header row and column
            sheet.Range("A1:Z1").Style.Font.Bold = true;
            sheet.Range("A1:A100").Style.Font.Bold = true;

            workbook.SaveAs(filePath);
        }
    }
}
