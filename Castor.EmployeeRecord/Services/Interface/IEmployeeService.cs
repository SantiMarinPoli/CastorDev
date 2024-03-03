using Castor.EmployeeRecord.Models;

namespace Castor.EmployeeRecord.Services.Interface
{
    public interface IEmployeeService
    {
        public Task<bool> CreateEmployee(Employee employee);

        public List<Employee> ListEmployees();

        public Employee GetEmployeeById(int id);

        public Task<bool> UpdateEmployee(Employee employee);

        public bool DeleteEmployee(int id);
    }
}
