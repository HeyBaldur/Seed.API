using Microsoft.EntityFrameworkCore;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;
using Seed.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Seed.Models.V1.Models.DimSolutionFilter;

namespace Seed.Repositories.Repositories
{
    public class SolutionRespository : ISolution
    {
        private readonly DataContext _dataContext;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="dataContext"></param>
        public SolutionRespository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<DimSolution> Create(DimSolution solution)
        {
            await _dataContext.AddAsync(solution);
            await _dataContext.SaveChangesAsync();
            return solution;
        }

        public async Task<DimSolutionFilter> CreateFilter(DimSolutionFilter filter)
        {
            await _dataContext.AddAsync(filter);
            await _dataContext.SaveChangesAsync();
            return filter;
        }

        public async Task<IEnumerable<DimSolution>> GetAll()
        {
            var solution = await _dataContext.DimSolutions.Include(p => p.Filters).ToListAsync();
            return solution;
        }

        public async Task<DimSolution> Update(DimSolution solution)
        {
            // Get all solutions from DB
            var filtersFromRepo = _dataContext
                        .DimSolutionFilters
                        .FromSqlInterpolated($"EXECUTE dbo.GetSolutions @DimSolutionID={solution.Id}")
                        .ToList();
            var filterFromRequest = solution.Filters.Where(filter => filter.SolutionId != 0).ToList();
            var missingFilters = filtersFromRepo.Except(filterFromRequest, new FilterComparer());

            // Validate if there are missing filters
            if (missingFilters.Any())
            {
                throw new Exception("User cannot modify filters that belongs to a solution");
            }

            // Filters cannot be edited here
            solution.Filters = null;

            _dataContext.Update(solution);
            await _dataContext.SaveChangesAsync();
            return solution;
        }
    }
}
