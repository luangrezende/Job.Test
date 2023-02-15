using Rover.Core;
using Rover.Service.Interface;
using Rover.Shared.Enums;
using Rover.Shared.Helpers;
using System;

namespace Rover.Service
{
    public class RoverService : IRoverService
    {
        public Rovers BuildRover(string roverCoordinate, string roverCommand, Plateau pleateau)
        {
            Rovers entity;
            int xCoordinate = -1;
            int yCoordinate = -1;
            Direction direction = Direction.Undefined;

            bool result = RoverHelper.CalculateCoordinates(roverCoordinate, ref xCoordinate, ref yCoordinate, ref direction);

            if (result)
            {
                entity = new Rovers()
                {
                    XCoordinate = xCoordinate,
                    YCoordinate = yCoordinate,
                    Direction = direction
                };

                bool pointResult = RoverHelper.CalculateRoverPoint(pleateau, entity);

                if (pointResult)
                {
                    bool roverCommandResult = RoverHelper.CalculateCommands(roverCommand);

                    if (roverCommandResult)
                    {
                        entity.Command = roverCommand;
                    }
                    else
                    {
                        Console.WriteLine("Os comandos inseridos não são válidos para o rover! É permitido digitar apenas L, R ou M.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Há uma incompatibilidade entre a área a ser visitada e a coordenada móvel.");
                    return null;

                }
            }
            else
            {
                Console.WriteLine("As informações de localização inseridas para o Rover estão incorretas. Exemplo: 1 2 N");
                return null;
            }

            return entity;
        }

        public Rovers ExecuteRoverCommand(Rovers entity)
        {
            if(entity != null)
            {
                foreach (var item in entity.Command)
                {
                    switch (item)
                    {
                        case 'L':
                            RoverHelper.TurnLeft(entity);
                            break;
                        case 'R':
                            RoverHelper.TurnRight(entity);
                            break;
                        case 'M':
                            RoverHelper.Move(entity);
                            break;
                    }
                }

            }

            return entity;
        }
    }
}
