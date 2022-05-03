using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;

namespace Seed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _iEmployee;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iEmployee"></param>
        public EmployeeController(IEmployee iEmployee)
        {
            _iEmployee = iEmployee;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _iEmployee.GetAllEmployees();
            return Ok(employees);
        }

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(DimEmployee employee)
        {
            var result = await _iEmployee.CreateEmployee(employee);
            return Ok(result);
        }
    }
}
