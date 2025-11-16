using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQOperator
{
    public class Program
    {

        public static void Main(String[] args)
        {
            //query syntax
            List<Employee> Basicquery = (from emp in Employee.GetEmployee() select emp).ToList();

           foreach(var e in Basicquery)
            {
                Console.WriteLine($"ID : {e.ID} \t Name : {e.FirstName} {e.LastName}");
            }

            //Method Syntax

            Console.WriteLine("\n Method Syntax");
            var Methodsyntax = Employee.GetEmployee().ToList();

            foreach (var e in Methodsyntax) 
            {

                Console.WriteLine($"ID : {e.ID}  \t Name : {e.FirstName} {e.LastName}");
            }

            //How do you Select a Few Properties using LINQ Select Operator or Select Method in C#
            //Query syntax
            Console.WriteLine("\n How do you Select a Few Properties using LINQ Select Operator or Select Method in C# : \n\n  **********Query syntax***********");
            IEnumerable<Employee> QueryFewProperties = (from emp in Employee.GetEmployee()
                                                   select new Employee()
                                                   {
                                                       FirstName = emp.FirstName,
                                                       LastName = emp.LastName,
                                                       Salary = emp.Salary
                                                   });

            foreach (var e in QueryFewProperties)
            {
                Console.WriteLine($"Name : {e.FirstName} {e.LastName} \t Salary : {e.Salary}");
            }

            //method syntax 
            Console.WriteLine(" \n ************method syntax**************");
            List<Employee> MethodFewProperties = Employee.GetEmployee().
                Select(emp => new Employee()
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Salary = emp.Salary
                }).ToList();
            foreach(var emp in MethodFewProperties)
            {
                Console.WriteLine($"Name : {emp.FirstName} {emp.LastName} \t  Salary : {emp.Salary}");
            }
        }


    }
}
