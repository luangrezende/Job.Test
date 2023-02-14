using Rover.Shared.Helpers.Interfaces;

namespace Rover.Shared.Helpers
{
    public class PlateauHelper
    {
        public bool PlateauCoordinateCalculate(string value, ref int xCoordinate, ref int yCoordinate)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(value))
            {
                string[] plateaAttributes = value.Trim().Split(' ');

                if (plateaAttributes.Length == 2)
                {
                    bool xCoordinateResult = int.TryParse(plateaAttributes[0], out xCoordinate);
                    bool yCoordinateResult = int.TryParse(plateaAttributes[1], out yCoordinate);

                    if (xCoordinateResult && yCoordinateResult)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
