using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;
using Seed.Repositories.Data;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var solutions = await _iSolution.GetAll();
            return Ok(solutions);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DimSolution solution)
        {
            var solutions = await _iSolution.Create(solution);
            return Ok(solutions);
        }

        [HttpPost("AddFilter")]
        public async Task<IActionResult> AddFilter(DimSolutionFilter filter)
        {
            var filterToAdd = await _iSolution.CreateFilter(filter);
            return Ok(filterToAdd);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DimSolution solution)
        {
            var solutions = await _iSolution.Update(solution);
            return Ok(solutions);
        }
    }
}