using Seed.Models.V1.Models;
using Seed.Services.ErrorHandling;
using Seed.Services.Models;
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
        Task<ContentHandler<string>> Update(DimSolution solution);
        Task<DimSolutionFilter> CreateFilter(DimSolutionFilter filter);
    }
}
