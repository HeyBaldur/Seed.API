using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Seed.Interfaces.V1;
using Seed.XUnit.V1.Data;
using Seed.XUnit.V1.Mocks;
using System.Diagnostics.CodeAnalysis;

namespace Seed.XUnit.Repositories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SolutionRespositoryTest
    {
        private Mock<ISolution> _iSolutionMock;

        [TestInitialize]
        public void Init()
        {
            _iSolutionMock = ConfigureServiceMock.Initialize();
        }

        /// <summary>
        /// It should return true
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void CreateTest()
        {
            //  Arrange
            var data = SolutionRepositoryFakeData.solution;

            // Act
            var request = _iSolutionMock.Object.Create(data);
            var response = request.Result;

            // Assert
            Assert.IsFalse(response.IsError);
        }
    }
}
