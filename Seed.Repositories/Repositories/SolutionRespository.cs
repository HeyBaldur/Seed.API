using Microsoft.EntityFrameworkCore;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;
using Seed.Repositories.Data;
using Seed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Seed.Models.V1.Models.DimSolutionFilter;

namespace Seed.Repositories.Repositories
{
    public class SolutionRespository: ISolution
    {
        private readonly DataContext _dataContext;

        // public override T Result => base.Result;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="dataContext"></param>
        public SolutionRespository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Create a new solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public async Task<GenericApiResponse<DimSolution>> Create(DimSolution solution)
        {
            try
            {
                await _dataContext.AddAsync(solution);
                await _dataContext.SaveChangesAsync();
                return new GenericApiResponse<DimSolution>(solution, "Success");
            }
            catch (Exception ex)
            {
                return new GenericApiResponse<DimSolution>(true, ex.Message);
            }
        }

        /// <summary>
        /// Create a new filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<GenericApiResponse<DimSolutionFilter>> CreateFilter(DimSolutionFilter filter)
        {
            try
            {
                await _dataContext.AddAsync(filter);
                await _dataContext.SaveChangesAsync();
                return new GenericApiResponse<DimSolutionFilter>(filter, "Success");
            }
            catch (Exception)
            {
                return new GenericApiResponse<DimSolutionFilter>(true, "Fail to add filter");
            }
        }

        /// <summary>
        /// Get all solutions
        /// </summary>
        /// <returns></returns>
        public async Task<GenericApiResponse<IEnumerable<DimSolution>>> GetAll()
        {
            var solutionList = await _dataContext.DimSolutions.Include(p => p.Filters).ToListAsync();
            return new GenericApiResponse<IEnumerable<DimSolution>>(solutionList, "Fail to add filter");
        }

        /// <summary>
        /// Update solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public async Task<GenericApiResponse<DimSolution>> Update(DimSolution solution)
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
                return new GenericApiResponse<DimSolution>(true, "User cannot modify object");

            try
            {
                solution.Filters = null;
                _dataContext.Update(solution);
                await _dataContext.SaveChangesAsync();
                return new GenericApiResponse<DimSolution>(solution, "Success");
            }
            catch (Exception)
            {
                return new GenericApiResponse<DimSolution>(true, "Uncaught error, please verify your request and try again");
            }
        }
    }
}
