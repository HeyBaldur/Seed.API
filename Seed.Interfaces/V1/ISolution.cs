using Seed.Models.V1.Models;
using Seed.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seed.Interfaces.V1
{
    public interface ISolution
    {
        /// <summary>
        /// Create a new solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        Task<ResultOperationResponse<DimSolution>> Create(DimSolution solution);
        
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        Task<ResultOperationResponse<IEnumerable<DimSolution>>> GetAll();
        
        /// <summary>
        /// Update an items
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        Task<ResultOperationResponse<DimSolution>> Update(DimSolution solution);
        
        /// <summary>
        /// Create a new filter for item
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<ResultOperationResponse<DimSolutionFilter>> CreateFilter(DimSolutionFilter filter);
    }
}
