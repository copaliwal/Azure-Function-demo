using System.Collections.Generic;

namespace DemoFunctionApp
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> employees = new List<Employee>()
        {
            new Employee() { EmpId= 1, FirstName="FisrtName1", LastName="LastName1", Department="Department1"},
            new Employee() { EmpId= 2, FirstName="FisrtName2", LastName="LastName2", Department="Department2"},
            new Employee() { EmpId= 3, FirstName="FisrtName3", LastName="LastName3", Department="Department3"},
            new Employee() { EmpId= 4, FirstName="FisrtName4", LastName="LastName4", Department="Department4"},
            new Employee() { EmpId= 5, FirstName="FisrtName5", LastName="LastName5", Department="Department5"}
        };

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.Find(e => e.EmpId == id);
        }

    }
}
