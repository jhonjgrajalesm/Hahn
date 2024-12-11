using HahnTest.Server.Entities;

namespace HahnTest.Server.Interfaces
{
    public interface IEmployeeRepository
    {
        string DataLocation { get; }

        void DeleteEmployee(string id);
        Employee GetEmployeeById(string id);
        List<Employee> GetEmployees();
        void Insert(Employee newEmployee);
        void Update(Employee updatedEmployee);
    }
}