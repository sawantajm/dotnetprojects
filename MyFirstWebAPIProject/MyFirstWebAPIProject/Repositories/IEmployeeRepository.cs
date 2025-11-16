using MyFirstWebAPIProject.Models;

namespace MyFirstWebAPIProject.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetALLEmployee();
        Employee? GetById(int id);
        void Addemployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void Delete(int id);
        bool IsExist(int id);
    }
}
