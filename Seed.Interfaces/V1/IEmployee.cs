using Seed.Models.V1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seed.Interfaces.V1
{
    public interface IEmployee
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DimEmployee>> GetAllEmployees();

        Task<DimEmployee> CreateEmployee(DimEmployee employee);
    }
}
