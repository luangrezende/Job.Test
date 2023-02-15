using Rover.Core;
using Rover.Service.Interface;
using Rover.Shared.Helpers;

namespace Rover.Service
{
    public class PlateauService : IPlateauService
    {
        public Plateau BuildPlateau(string value)
        {
            Plateau entity = null;
            int xCoordinate = -1, yCoordinate = -1;

            bool result = PlateauHelper.PlateauCoordinateCalculate(value, ref xCoordinate, ref yCoordinate);
            if (result)
            {
                entity = new Plateau()
                {
                    XCoordinateLength = xCoordinate,
                    YCoordinateLength = yCoordinate
                };
            }

            return entity;
        }
    }
}
