using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;
using Seed.Repositories.Data;
using Seed.Services.ErrorHandling;
using Seed.Services.Models;
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

        /// <summary>
        /// Create a new solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public async Task<DimSolution> Create(DimSolution solution)
        {
            await _dataContext.AddAsync(solution);
            await _dataContext.SaveChangesAsync();
            return solution;
        }

        /// <summary>
        /// Create a new filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<DimSolutionFilter> CreateFilter(DimSolutionFilter filter)
        {
            await _dataContext.AddAsync(filter);
            await _dataContext.SaveChangesAsync();
            return filter;
        }

        /// <summary>
        /// Get all solutions
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DimSolution>> GetAll()
        {
            var solution = await _dataContext.DimSolutions.Include(p => p.Filters).ToListAsync();
            return solution;
        }

        /// <summary>
        /// Update solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public async Task<ContentHandler<string>> Update(DimSolution solution)
        {
            // Get all solutions from DB
            var response = new SeedContentHandler();
            var filtersFromRepo = _dataContext
                        .DimSolutionFilters
                        .FromSqlInterpolated($"EXECUTE dbo.GetSolutions @DimSolutionID={solution.Id}")
                        .ToList();
            var filterFromRequest = solution.Filters.Where(filter => filter.SolutionId != 0).ToList();
            var missingFilters = filtersFromRepo.Except(filterFromRequest, new FilterComparer());

            // Validate if there are missing filters
            if (missingFilters.Any())
            {
                var error = new ErrorHandling
                {
                    ErrorMessage = "User cannot modify object",
                    IssueId = Guid.NewGuid()
                };

                // TODO: Make it one single method
                var objectToReturn = JsonConvert.SerializeObject(error);

                var responseToReturn = response.HandleResponse(objectToReturn, false, "Fail");
                return responseToReturn;
            }

            try
            {
                // Filters cannot be edited here
                solution.Filters = null;

                _dataContext.Update(solution);
                await _dataContext.SaveChangesAsync();

                // TODO: Make it one single method
                var objectToReturn = JsonConvert.SerializeObject(solution);

                var responseToReturn = response.HandleResponse(objectToReturn, false, "Successs");
                return responseToReturn;
            }
            catch (Exception ex)
            {
                var error = new ErrorHandling
                {
                    ErrorMessage = ex.ToString(),
                    IssueId = Guid.NewGuid()
                };

                // TODO: Make it one single method
                var objectToReturn = JsonConvert.SerializeObject(error);

                var responseToReturn = response.HandleResponse(objectToReturn, false, "Fail");
                return responseToReturn;
            }
        }

        //private Task<ContentHandler<string>> ResponseBuilder<T>(T obj, re)
        //{

        //}
    }
}
