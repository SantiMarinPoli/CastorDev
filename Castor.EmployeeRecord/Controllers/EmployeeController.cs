using Castor.EmployeeRecord.Models;
using Castor.EmployeeRecord.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Castor.EmployeeRecord.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("ListEmployee")]
        public IActionResult ListEmployee()
        {
            List<Employee> listEmployees = _employeeService.ListEmployees();
            return listEmployees.Count != 0? Ok(listEmployees) : BadRequest("Worng display list employees");
        }

        [HttpGet("EmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _employeeService.GetEmployeeById(id);
            return employee != null ? Ok(employee) : BadRequest("Worng display list employees");
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            bool exito = _employeeService.CreateEmployee(employee).Result;

            return  exito?Ok(exito): BadRequest("Wrong insert employee");
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee) 
        {
            bool exito = _employeeService.UpdateEmployee(employee).Result;
            return exito ? Ok(exito) : BadRequest("Wrong update employee");
        }

        [HttpDelete("{*id}")]
        public IActionResult DeleteEmployee(int id)
        {
            bool exito = _employeeService.DeleteEmployee(id);
            return exito ? Ok(exito) : BadRequest("Wrong delete employee");
        }
    }
}
