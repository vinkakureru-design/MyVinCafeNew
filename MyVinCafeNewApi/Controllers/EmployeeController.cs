using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using MyVinCafeNewApi.Feature.EmployeeManagement;
using System.Diagnostics;
using MyVinCafeNewApi.Feature.UserManagement;
using MyVinCafeNewLibrary.Dtos.UserDto;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeService _employeeService;
        public EmployeeController(IEmployeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeeAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(AddEmployeeDto request)
        {
            var createdEmployee = await _employeeService.CreateEmployeeAsync(request);
            return Ok(createdEmployee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, AddEmployeeDto employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employee);
            return Ok(updatedEmployee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            return Ok(result);
        }
    }
}
