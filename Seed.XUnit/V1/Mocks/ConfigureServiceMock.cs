using Moq;
using Seed.Interfaces.V1;
using Seed.Models.V1.Models;
using Seed.Repositories.Data;
using Seed.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seed.XUnit.V1.Mocks
{
    public static class ConfigureServiceMock
    {
        private static readonly Mock<ISolution> _solutionMocks = new Mock<ISolution>();

        public static Mock<ISolution> Initialize()
        {
            _solutionMocks.Setup(m => m.Create(It.IsAny<DimSolution>()))
                .ReturnsAsync(new ResultOperationResponse<DimSolution>(false, "Success"));

            return _solutionMocks;
        } 
    }
}
