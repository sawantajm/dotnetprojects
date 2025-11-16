using MyFirstWebAPIProject.Models;

namespace MyFirstWebAPIProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee> {
            new Employee { Id = 1, Name = "John Doe", Position = "Software Engineer", Age = 30, EmailAddress = "john.doe@example.com" },
                new Employee { Id = 2, Name = "Jane Smith", Position = "Project Manager", Age = 35, EmailAddress = "jane.smith@example.com" }
            };
        }

        public IEnumerable<Employee> GetALLEmployee()
        {
            return _employees;
        }

        public Employee? GetById (int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id); 
        }
        public void Addemployee(Employee employee)
        {
            employee.Id = _employees.Max(E =>E.Id) + 1;
            _employees.Add(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.EmailAddress = employee.EmailAddress;
                existing.Age = employee.Age;
            }
        }

        public void Delete(int id)
        {
            var CheckEmployeePresent = GetById(id);
            if(CheckEmployeePresent !=null)
            {
                _employees.Remove(CheckEmployeePresent);
            }
        }
        public bool IsExist(int id)
        {
            return _employees.Any( e => e.Id==id);
        }
    }
}
