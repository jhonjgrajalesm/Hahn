using HahnTest.Server.Entities;

namespace HahnTest.Server.Interfaces
{
    public interface IEmployeeService
    {
        Employee CalculareSalaryIncrement(string id);
    }
}