using System.Collections.Generic;

namespace DemoFunctionApp
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
    }
}