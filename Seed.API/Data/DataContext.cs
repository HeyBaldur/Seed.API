using Microsoft.EntityFrameworkCore;

namespace Seed.API.Data
{
    /// <summary>
    /// Data context to add connect with DB
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
