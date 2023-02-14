using Rover.Core;
using Rover.Service.Interface;
using Rover.Shared.Helpers;
using Rover.Shared.Helpers.Interfaces;

namespace Rover.Service
{
    public class platoService : IPleateauService
    {
        public IPlatoHelper _pleteauHelper;

        public Pleateau GerarPlato(string value)
        {
            Pleateau entity = null;

            _pleteauHelper = new PlateauHelper();

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
