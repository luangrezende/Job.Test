using Rover.Core;
using Rover.Service.Interface;
using Rover.Shared.Enums;
using Rover.Shared.Helpers;
using Rover.Shared.Helpers.Interfaces;
using System;

namespace Rover.Service
{
    public class RoverService : IRoverService
    {
        public IRoverHelper _roverHelper;

        public Rovers GenerateRover(string roverCoordinate, string roverCommand, Pleateau plato)
        {
            _roverHelper = new RoverHelper();
            int xCoordinate = -1;
            int yCoordinate = -1;
            Direction direction = Direction.Undefined;

            bool result = _roverHelper.CalculateCoordinates(roverCoordinate, ref xCoordinate, ref yCoordinate, ref direction);

            Rovers entity;
            if (result)
            {
                entity = new Rovers()
                {
                    XCoordinate = xCoordinate,
                    YCoordinate = yCoordinate,
                    Direction = direction
                };

                bool pointResult = _roverHelper.CalculateRoverPoint(plato, entity);

                if (pointResult)
                {
                    bool roverCommandResult = _roverHelper.CalculateCommands(roverCommand);

                    if (roverCommandResult)
                    {
                        entity.Command = roverCommand;
                    }
                    else
                    {
                        Console.WriteLine("Os comandos inseridos não são válidos para o rover! Basta digitar L, R ou M.");
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
                            _roverHelper.TurnLeft(entity);
                            break;
                        case 'R':
                            _roverHelper.TurnRight(entity);
                            break;
                        case 'M':
                            _roverHelper.Move(entity);
                            break;
                    }
                }

            }
           

            return entity;
        }
    }
}
