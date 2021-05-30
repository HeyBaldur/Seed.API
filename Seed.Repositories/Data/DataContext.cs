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

        public virtual DbSet<DimEmployee> DimEmployees { get; set; }
        public DbSet<DimSolution> DimSolutions { get; set; }
        public virtual DbSet<DimSolutionFilter> DimSolutionFilters { get; set; }

    }
}
