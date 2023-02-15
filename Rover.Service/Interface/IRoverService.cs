using Rover.Core;

namespace Rover.Service.Interface
{
    public interface IRoverService
    {
        Rovers BuildRover(string roverCoordinate, string roverCommand, Plateau pleateau);

        Rovers ExecuteRoverCommand(Rovers entity);
    }
}
