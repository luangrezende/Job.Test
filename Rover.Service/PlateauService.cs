using Rover.Core;
using Rover.Service.Interface;
using Rover.Shared.Helpers;

namespace Rover.Service
{
    public class PlateauService : IPlateauService
    {
        public Pleateau GeneratePlateau(string value)
        {
            Pleateau entity = null;
            var _pleteauHelper = new PlateauHelper();
            int xCoordinate = -1, yCoordinate = -1;

            bool result = _pleteauHelper.PlateauCoordinateCalculate(value, ref xCoordinate, ref yCoordinate);
            if (result)
            {
                entity = new Pleateau()
                {
                    XCoordinateLength = xCoordinate,
                    YCoordinateLength = yCoordinate
                };
            }

            return entity;
        }
    }
}
