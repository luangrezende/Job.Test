namespace Rover.Shared.Helpers.Interfaces
{
    public interface IPlatoHelper
    {
        bool PlateauCoordinateCalculate(string value, ref int xCoordinateLength, ref int yCoordinateLength);
    }
}
