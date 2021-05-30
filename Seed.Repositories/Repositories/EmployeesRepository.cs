using Microsoft.EntityFrameworkCore;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;
using Seed.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seed.Repositories
{
    public class EmployeesRepository : IEmployee
    {
        private readonly DataContext _dataContext;
        
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="dataContext"></param>
        public EmployeesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Create an employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<DimEmployee> CreateEmployee(DimEmployee employee)
        {
            await _dataContext.AddAsync(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        /// <summary>
        /// Get all employees that 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DimEmployee>> GetAllEmployees()
        {
            var employees = await _dataContext.DimEmployees.ToListAsync();
            return employees;
        }
    }
}
