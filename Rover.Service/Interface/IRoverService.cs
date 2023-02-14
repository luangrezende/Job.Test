using Rover.Core;

namespace Rover.Service.Interface
{
    public interface IRoverService
    {
        Rovers GenerateRover(string roverCoordinate, string roverCommand, Pleateau plato);

        Rovers ExecuteRoverCommand(Rovers entity);
    }
}
