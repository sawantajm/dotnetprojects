using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractis
{
    public static class Data
    {
        public static List<Employee> GetEmployee()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 60000.0m,
                IsManager = true,
                Departmentid = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jemison",
                AnnualSalary = 80000.0m,
                IsManager = true,
                Departmentid = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Dougles",
                LastName = "Robert",
                AnnualSalary = 630000.0m,
                IsManager = false,
                Departmentid = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "jane",
                LastName = "stevens",
                AnnualSalary = 30000.0m,
                IsManager = false,
                Departmentid = 1
            };
            employees.Add(employee);

            return employees;
        }


        public static List<Department> GetDepartment()
        {
            List<Department> departmentList = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resource"
            };
            departmentList.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departmentList.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departmentList.Add(department);

            return departmentList;
        }
    }
}
