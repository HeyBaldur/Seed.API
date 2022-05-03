using Seed.Models.V1.Models;
using Seed.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seed.Interfaces.V1
{
    public interface IEmployee
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        Task<GenericApiResponse<IEnumerable<DimEmployee>>> GetAllEmployees();

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<GenericApiResponse<DimEmployee>> CreateEmployee(DimEmployee employee);
    }
}
