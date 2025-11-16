using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace CurdUsingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeData employeeData = new EmployeeData();
            Console.WriteLine("\n--- Employee CRUD ---");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");

            Console.Write("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    employeeData.Employeedata();
                    break;
                case 2:
                    employeeData.Read();
                    break;
                case 3:
                    employeeData.Updatedata();
                    break;
                case 4:
                    employeeData.Delete();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }


        }
    }

    class EmployeeData
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        List<EmployeeData> employees = new List<EmployeeData>();
        public void Employeedata()
        {
            Console.WriteLine("EnterId");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Last Name");
            string LastName = Console.ReadLine();
            Console.WriteLine("First Name");
            string FirstName = Console.ReadLine();

            employees.Add(new EmployeeData { Id = Id, LastName = LastName, FirstName = FirstName });


        }

        public void Updatedata()
        {
            Console.WriteLine("Update to ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            var emp = employees.Find(x => x.Id == id);
            if (emp != null)
            {
                Console.WriteLine("Update FirstName:");
                emp.FirstName = Console.ReadLine();
                Console.WriteLine("Update LastName:");
                emp.LastName = Console.ReadLine();
            }
        }
       
        public void Read()
        {

        }
        public void Delete()
        {

        }



    }

}

