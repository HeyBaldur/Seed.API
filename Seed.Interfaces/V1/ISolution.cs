using Seed.Models.V1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seed.Interfaces.V1
{
    public interface ISolution
    {
        Task<DimSolution> Create(DimSolution solution);
        Task<IEnumerable<DimSolution>> GetAll();
        Task<DimSolution> Update(DimSolution solution);
        Task<DimSolutionFilter> CreateFilter(DimSolutionFilter filter);
    }
}
