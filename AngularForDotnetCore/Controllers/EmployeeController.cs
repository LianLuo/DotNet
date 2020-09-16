using System.Collections.Generic;
using System.Threading.Tasks;
using AngularForDotnetCore.Components;
using AngularForDotnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularForDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeComponent _ec;
        public EmployeeController(EmployeeComponent ec)
        {
            this._ec = ec;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await this._ec.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int employeeId)
        {
            var employee = await this._ec.GetEmployeeById(employeeId);
            return Ok(employee);
        }

        [HttpPut("{employeeId}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int employeeId, Employee emp)
        {
            var employee = await this._ec.GetEmployeeById(employeeId);
            if(null == employee)
            {
                return NotFound();
            }

            employee.EMPCode = emp.EMPCode;
            employee.FullName = emp.FullName;
            employee.Mobile = emp.Mobile;
            employee.Position = emp.Position;
            await this._ec.UpdateEmployee(employee);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee emp)
        {
            await this._ec.AddEmployee(emp);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            await this._ec.DeleteEmployee(id);
            return Ok();
        }

    }
}