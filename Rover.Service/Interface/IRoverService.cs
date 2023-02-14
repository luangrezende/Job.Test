using Rover.Core;

namespace Rover.Service.Interface
{
    public interface IRoverService
    {
        Rovers GenerateRover(string roverCoordinate, string roverCommand, Plateau pleateau);

        Rovers ExecuteRoverCommand(Rovers entity);
    }
}
