using NUnit.Framework;
using Rover.Core;
using Rover.Service;
using Rover.Service.Interface;

namespace Rover.Tests
{
    public class PleteauTest
    {
        public IPlateauService _pleteauService;

        public PleteauTest()
        {
            _pleteauService = new PlateauService();
        }

        [Test]
        public void GeneratePlateauTestMethod()
        {
            Plateau plateau = _pleteauService.BuildPlateau("aaa bbb");
            Assert.IsNull(plateau);

            plateau = _pleteauService.BuildPlateau("5  5");
            Assert.IsNull(plateau);

            plateau = _pleteauService.BuildPlateau("5  ccc");
            Assert.IsNull(plateau);

            plateau = _pleteauService.BuildPlateau("5 5");
            Assert.IsNotNull(plateau);
        }
    }
}