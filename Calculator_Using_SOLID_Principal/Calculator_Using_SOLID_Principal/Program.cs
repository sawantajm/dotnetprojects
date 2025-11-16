using System.Collections;

namespace Calculator_Using_SOLID_Principal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculatoroperation = new List<Icalculator>
           { new Addition(),
           new Subtraction(),
           new Multiplication(),
           };

            var Calculators = new Calculators(calculatoroperation);

            Console.WriteLine("Please select which operation you want to perform");
            Console.WriteLine("1. Addition \n 2.Subtraction \n 3. Multiplication");
             string choise = Console.ReadLine();

            Console.WriteLine("enter the First Number");
            double firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter 2nd Number");
            double SecondNumber= Convert.ToDouble(Console.ReadLine());


            try
            {
                var result = Calculators.Execute(firstNumber, SecondNumber, choise);

                Console.WriteLine($"The result is above opeartion is : {result} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
