using NUnit.Framework;
using Rover.Core;
using Rover.Service;
using Rover.Service.Interface;

namespace Rover.Tests
{
    public class RoverTest
    {
        public IRoverService _roverService;
        public IPlateauService _pleteauService;

        public RoverTest()
        {
            _roverService = new RoverService();
            _pleteauService = new PlateauService();
        }

        [Test]
        public void GenerateRoverTestMethod()
        {
            Plateau plateauEntity = _pleteauService.BuildPlateau("5 5");

            Rovers rovers = _roverService.BuildRover("1  2 N", "LMLMLMLMMMM", plateauEntity);
            Assert.IsNull(rovers);

            rovers = _roverService.BuildRover("1 2 N", "LML132MLMLMM", plateauEntity);
            Assert.IsNull(rovers);

            rovers = _roverService.BuildRover("1 2 N", "LMLMLMLMM", plateauEntity);
            Assert.IsNotNull(rovers);
        }

        [Test]
        public void ExecuteRoverCommandTestMethod()
        {
            Plateau plateauEntity = _pleteauService.BuildPlateau("5 5"); 
            Rovers rovers = _roverService.BuildRover("1 2 N", "L2MLMLMSSLMM1", plateauEntity);

            rovers = _roverService.ExecuteRoverCommand(rovers);
            Assert.IsNull(rovers);

            rovers = _roverService.BuildRover("1 2  N", "LMLMSLMLMMS", plateauEntity);
            rovers = _roverService.ExecuteRoverCommand(rovers);
            Assert.IsNull(rovers);

            rovers = _roverService.BuildRover("1 2 N", "LMLMLMLMM", plateauEntity);
            rovers = _roverService.ExecuteRoverCommand(rovers);
            Assert.IsNotNull(rovers);
        }
    }
}
