namespace Rover.Shared.Helpers
{
    public static class PlateauHelper
    {
        public static bool PlateauCoordinateCalculate(string value, ref int xCoordinate, ref int yCoordinate)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(value))
            {
                string[] plateauAttributes = value.Trim().Split(' ');

                if (plateauAttributes.Length == 2)
                {
                    bool xCoordinateResult = int.TryParse(plateauAttributes[0], out xCoordinate);
                    bool yCoordinateResult = int.TryParse(plateauAttributes[1], out yCoordinate);

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
