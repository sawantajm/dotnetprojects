using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace LINQPractis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployee();
            //created the Filter extention method and implement it and use it.
            //var FilterEmployee = employeeList.Filter(emp => emp.IsManager == true);

            //foreach (Employee emp in FilterEmployee)
            //{
            //    Console.WriteLine($"First Name is : {emp.FirstName}");
            //    Console.WriteLine($"Last Name is : {emp.LastName}");
            //    Console.WriteLine($"Anual Salary : {emp.AnnualSalary}");
            //    Console.WriteLine($"Manager : {emp.IsManager}");

            //    Console.WriteLine();
            //}

            List<Department> DepartmentList = Data.GetDepartment();
            //created the Filter extention method and implement it and use it
            //var FilterDepartment = DepartmentList.Filter(dept => dept.ShortName == "HR");

            //insted of use extention method which is implemented by own we can use LINQ inbuilt menthod which is under in System.Linq namespace
            // var FilterDepartment = DepartmentList.Where(dept => dept.ShortName == "HR");
            //foreach (Department dept in FilterDepartment)
            //{
            //    Console.WriteLine($"Department Id is : {dept.Id}");
            //    Console.WriteLine($"Department is : {dept.ShortName}");
            //    Console.WriteLine($"Department long name : {dept.LongName}");

            //    Console.WriteLine();
            //}


            /* //Join
             List<Employee> employeeList = Data.GetEmployee();
             List<Department> DepartmentList = Data.GetDepartment();

             var joinresult = from emp in employeeList
                              join dept in DepartmentList
                              on emp.Departmentid equals dept.Id
                              select new
                              {
                                 FirstName= emp.FirstName,
                                 LastName= emp.LastName,
                                 Salary= emp.AnnualSalary,
                                 Manager= emp.IsManager,
                                 Department = dept.LongName
                              };
             foreach (var emp in joinresult)
             {
                 Console.WriteLine($" Name is : {emp.FirstName} {emp.LastName}");

                 Console.WriteLine($"Anual Salary : {emp.Salary}");
                 Console.WriteLine($"Manager : {emp.Manager}");
                 Console.WriteLine($"Manager : {emp.Department}");

                 Console.WriteLine();
             }

             //Average Anuual salary

             var averageAnualSalary = joinresult.Average(a => a.Salary);
             var highestAnualSalary = joinresult.Max(a => a.Salary);
             var minimumAnualSalary = joinresult.Min(a => a.Salary);


             Console.WriteLine($"averageAnualSalary : {averageAnualSalary}");
             Console.WriteLine($"highestAnualSalary : {highestAnualSalary}");
             Console.WriteLine($"minimumAnualSalary : {minimumAnualSalary}");

             */

            /*
           //Method sysntax

           var employeeMethodSysntax = employeeList.Select(e => new
           {
               FullName = e.FirstName + " " + e.LastName,
               Salary = e.AnnualSalary

           }).Where( e => e.Salary >3000);

           foreach (var employee in employeeMethodSysntax)
           {
               Console.WriteLine($"{employee.FullName,-20} {employee.Salary, 10}");
           }
           

            //QuerySysntax

            var Employeequerysysntax = from emp in employeeList
                                       where emp.AnnualSalary>=500000
                                       select new 
                                       {
                                           fullName = emp.FirstName + " " + emp.LastName,
                                           Salary = emp.AnnualSalary
                                       };
            foreach (var employee in Employeequerysysntax)
            {
                Console.WriteLine($"{employee.fullName,-20} {employee.Salary,10}");
            }
            */

            /*
            //deffered execution

            var Employeedefferedexecution = from emp in employeeList
                                       where emp.AnnualSalary >= 50000
                                       select new
                                       {
                                           fullName = emp.FirstName + " " + emp.LastName,
                                           Salary = emp.AnnualSalary
                                       };

            employeeList.Add(new Employee
            {
                Id = 5,
                FirstName = "Sam",
                LastName = "David",
                AnnualSalary = 100000.20m,
                IsManager = true,
            });
            foreach (var employee in Employeedefferedexecution)
            {
                Console.WriteLine($"{employee.fullName,-20} {employee.Salary,10}");
            }
            */

            /*
            //join using method syntax
            
            var resultMethodsyntax = DepartmentList.Join
                (employeeList,
                department => department.Id,
                employee => employee.Departmentid,
                (department, employee) => new
                {
                    Department = department.LongName,
                    FullName  = employee.FirstName + " "+ employee.LastName,
                    Salary = employee.AnnualSalary,
                });
            foreach(var item in resultMethodsyntax)
            {
                Console.WriteLine($"{item.FullName,-20} {item.Salary, 10} {item.Department,-20}");
            }*/

            /*
            //Group join using method syntax/ Left join

            var LeftJoinMethodsyntax = DepartmentList.GroupJoin(employeeList,
                department => department.Id,
                employee => employee.Departmentid,
                (department, employeegroup) => new

                {
                    employee= employeegroup,
                   DepartmentName = department.LongName
                });

            foreach(var item in LeftJoinMethodsyntax)
            {
                Console.WriteLine($"{item.DepartmentName}");
                foreach(var emp in item.employee)
                {
                    Console.WriteLine($"\t{emp.LastName} {emp.FirstName}");
                }
            }
           */

            //Group Join using query syntax

            var result = from dept in DepartmentList
                         join emp in employeeList on
                         dept.Id equals emp.Departmentid
                         into EmployeeGroup
                         select new
                         {
                             employee = EmployeeGroup,
                             Department = dept.LongName,
                         };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Department}");
                foreach (var emp in item.employee)
                {
                    Console.WriteLine($"\t{emp.LastName} {emp.FirstName}");
                }
            }
        }
    }
}
