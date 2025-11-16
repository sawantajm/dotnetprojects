using System;
using ClosedXML.Excel;
using MilkManagementSystem.Models;

class Program
{

    static void Main()
    {
        string filePath = @"D:\Project dairy\Rate.xlsx";
        double snf = 8.5;
        double fat = 3.5;
        double rate = 35;

        AddOrUpdateRate(filePath, snf, fat, rate);
        Console.WriteLine("Rate added to Excel successfully.");
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
}