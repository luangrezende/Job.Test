using Rover.Shared.Enums;
using System;

namespace Rover.Shared.Helpers
{
    public class EnumHelper
    {
        public bool DirectionIsDefined(string value)
        {
            bool result = false;

            if (Enum.IsDefined(typeof(Direction), value))
            {
                result = true;
            }

            return result;
        }

        public bool CommandIsDefined(string value)
        {
            bool result = false;

            if (Enum.IsDefined(typeof(Command), value))
            {
                result = true;
            }

            return result;
        }
    }
}
