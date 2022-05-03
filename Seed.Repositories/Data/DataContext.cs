using Microsoft.EntityFrameworkCore;
using Seed.Models.V1.Models;

namespace Seed.Repositories.Data
{
    /// <summary>
    /// Data context to add connect with DB
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Employee list
        /// </summary>
        public virtual DbSet<DimEmployee> DimEmployees { get; set; }
        
        /// <summary>
        /// Solutions 
        /// </summary>
        public DbSet<DimSolution> DimSolutions { get; set; }
        
        /// <summary>
        /// Dime solution filters
        /// </summary>
        public virtual DbSet<DimSolutionFilter> DimSolutionFilters { get; set; }

        /// <summary>
        /// New employee list
        /// This list of employees has been created only for rxjs purposes
        /// </summary>
        public DbSet<DimCreatedEmployees> NewEmployeeList { get; set; }

    }
}
