using HahnTest.Server.Entities;
using HahnTest.Server.Interfaces;
using HahnTest.Server.Repositories;

namespace HahnTest.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee CalculareSalaryIncrement(string id)
        {
            var employee = this._employeeRepository.GetEmployeeById(id);
            employee.Salary = employee.Salary + 500;
            this._employeeRepository.Update(employee);
            return employee;
        }
    }
}
