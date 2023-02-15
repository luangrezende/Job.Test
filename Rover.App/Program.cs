using Rover.Core;
using Rover.Service;
using Rover.Service.Interface;

namespace Rover.App
{
    class Program
    {
        public static IPlateauService? _plateauService;
        public static IRoverService? _roverService;

        static void Main()
        {
            _plateauService = new PlateauService();
            _roverService = new RoverService();
            int roverCount = 1;
            int roverCountLimit = 3;
            List<Rovers> roverList = new();
            Plateau plateauEntity;

            while (true)
            {
                Console.Write("Digite as dimensoes: ");
                string? plateauWidthHeight = Console.ReadLine();

                plateauEntity = _plateauService.BuildPlateau(plateauWidthHeight);

                if (plateauEntity != null)
                    break;
                else
                    Console.WriteLine("Dado invalido, insira um dado de dimensao correto. Example: 5 5");
            }

            while (roverCount < roverCountLimit)
            {
                try
                {
                    Console.Write("{0}. Direção do solo Rover: ", roverCount);
                    string? roverCoordinate = Console.ReadLine();

                    Console.Write("{0}. Comandos Rover: ", roverCount);
                    string? roverCommand = Console.ReadLine();

                    Rovers roverEntity = _roverService.BuildRover(roverCoordinate, roverCommand, plateauEntity);

                    if (roverEntity != null)
                    {
                        roverEntity.Order = roverCount;
                        roverCount += 1;

                        roverList.Add(roverEntity);
                    }
                    else
                        Console.WriteLine("Erro inesperado.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nResultado:");
            foreach (Rovers roverItem in roverList)
            {
                Rovers item = _roverService.ExecuteRoverCommand(roverItem);
                Console.WriteLine(item.XCoordinate + " " + item.YCoordinate + " " + item.Direction);
            }
        }
    }
}
