using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;

namespace Seed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : ControllerBase
    {
        private readonly ISolution _iSolution;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="dataContext"></param>
        public SolutionsController(ISolution iSolution)
        {
            _iSolution = iSolution;
        }

        /// <summary>
        /// Get all solutions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var solutions = await _iSolution.GetAll();
            return Ok(solutions);
        }

        /// <summary>
        /// Add a new solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(DimSolution solution)
        {
            var solutionResult = await _iSolution.Create(solution);
            if (!solutionResult.IsError)
                return Ok(solutionResult);

            return BadRequest(solutionResult.Message);
        }

        /// <summary>
        /// Create a new filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("AddFilter")]
        public async Task<IActionResult> AddFilter(DimSolutionFilter filter)
        {
            var filterToAdd = await _iSolution.CreateFilter(filter);
            return Ok(filterToAdd);
        }

        /// <summary>
        /// Update a solution
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(DimSolution solution)
        {
            var solutions = await _iSolution.Update(solution);
            return Ok(solutions);
        }
    }
}