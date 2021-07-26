using Seed.Models.V1.Models;
using System.Diagnostics.CodeAnalysis;

namespace Seed.XUnit.V1.Data
{
    [ExcludeFromCodeCoverage]
    public static class SolutionRepositoryFakeData
    {
        public static DimSolution solution = new DimSolution
        {
            Description = "Some",
            EmployeeId = 1,
            Id = 1,
            Name = "Name",
            PhotoUrl = "url"
        };
    }
}
