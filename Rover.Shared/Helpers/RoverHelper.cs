using Rover.Core;
using Rover.Shared.Enums;
using System;

namespace Rover.Shared.Helpers
{
    public static class RoverHelper
    {
        public static bool CalculateCoordinates(string value, ref int xCoordinateLength, ref int yCoordinateLength, ref Direction direction)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(value))
            {
                string[] plateaAttributes = value.Trim().Split(' ');

                if (plateaAttributes.Length == 3)
                {
                    bool xCoordinateResult = int.TryParse(plateaAttributes[0], out xCoordinateLength);
                    bool yCoordinateResult = int.TryParse(plateaAttributes[1], out yCoordinateLength);

                    if (xCoordinateResult && yCoordinateResult)
                    {
                        if (!string.IsNullOrEmpty(plateaAttributes[2]))
                        {
                            bool isDefined = EnumHelper.DirectionIsDefined(plateaAttributes[2]);

                            if (isDefined)
                            {
                                direction = Enum.Parse<Direction>(plateaAttributes[2]);

                                result = true;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static bool CalculateRoverPoint(Plateau pleateau, Rovers rover)
        {
            bool result = false;

            if (pleateau.XCoordinateLength >= rover.XCoordinate 
                && pleateau.YCoordinateLength >= rover.YCoordinate)
            {
                result = true;
            }

            return result;
        }

        public static bool CalculateCommands(string value)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(value))
            {
                foreach (char item in value)
                {
                    result = EnumHelper.CommandIsDefined(item.ToString());

                    if (!result)
                        break;
                }
            }

            return result;
        }

        public static Rovers TurnLeft(Rovers input)
        {
            input.Direction = (Direction)Enum.ToObject(typeof(Direction), (Convert.ToInt32(input.Direction) + 1) % 4);
            
            return input;
        }

        public static Rovers TurnRight(Rovers input)
        {
            input.Direction = (Direction)Enum.ToObject(typeof(Direction), (Convert.ToInt32(input.Direction) + 3) % 4);

            return input;
        }

        public static Rovers Move(Rovers input)
        {
            switch (input.Direction)
            {
                case Direction.E:
                    input.XCoordinate += 1;
                    break;
                case Direction.W:
                    input.XCoordinate -= 1;
                    break;
                case Direction.S:
                    input.YCoordinate -= 1;
                    break;
                case Direction.N:
                    input.YCoordinate += 1;
                    break;
            }

            return input;
        }
    }
}
