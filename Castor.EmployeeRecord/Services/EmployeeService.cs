using Castor.EmployeeRecord.Models;
using Castor.EmployeeRecord.Services.Interface;

namespace Castor.EmployeeRecord.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Context _connection;

        public EmployeeService(Context connection)
        {
            _connection = connection;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            bool exito = true;
            try
            {
                _connection.Employees.Add(employee);
                _connection.SaveChanges();

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                exito = false;
            }

            return exito;


        }

        public List<Employee> ListEmployees()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                employees = _connection.Employees.ToList();

                employees.ForEach(y =>
                {
                    y.Position = _connection.Positions.Where(x => x.idPosition == y.idPosition).FirstOrDefault();
                });

            } catch (Exception ex)
            {
                var messsage = ex.Message;
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            try
            {
                employee = _connection.Employees.Where(x => x.id == id).FirstOrDefault();

            }catch(Exception ex)
            {
                var message = ex.Message;
            }

            return employee;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            bool exito = false;
            try
            {
                Employee changeEmployee = _connection.Employees.Where(x => x.id == employee.id).FirstOrDefault();
                if(changeEmployee != null)
                {
                    changeEmployee.dni = employee.dni;
                    changeEmployee.photo = employee.photo;
                    changeEmployee.name = employee.name;
                    changeEmployee.idPosition = employee.idPosition;

                    _connection.SaveChanges();
                    exito = true;
                }

            }catch(Exception ex)
            {
                var message = ex.Message;
                exito = false;
            }
            return exito;
        }

        public bool DeleteEmployee(int id)
        {
            bool exito = false;
            try
            {
                Employee employeeDeleted = _connection.Employees.Where(x => x.id == id).FirstOrDefault();

                if(employeeDeleted != null)
                {
                    _connection.Remove(employeeDeleted);
                    _connection.SaveChanges();
                    exito = true;
                }

            }catch(Exception ex)
            {
                var message = ex.Message;
                exito = false;
            }

            return exito;
        }

    }
}
