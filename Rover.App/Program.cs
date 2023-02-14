using Rover.Core;
using Rover.Service;
using Rover.Service.Interface;

namespace Rover.App
{
    class Program
    {
        public static IPleateauService? _platoService;
        public static IRoverService? _roverService;
        public static int roverCount = 1;

        static void Main(string[] args)
        {
            _platoService = new PlateauService();
            _roverService = new RoverService();
            List<Rovers> roverList = new();
            Pleateau platoEntity;

            while (true)
            {
                Console.Write("Digite as dimensoes: ");
                string? platoWidthHeight = Console.ReadLine();

                platoEntity = _platoService.GeneratePlateau(platoWidthHeight);

                if (platoEntity != null)
                    break;
                else
                    Console.WriteLine("Dado invalido. Example: 5 5");
            }

            while (roverCount < 3)
            {
                try
                {
                    Console.Write("{0}. Direção do solo Rover: ", roverCount);
                    string? roverCoordinate = Console.ReadLine();

                    Console.Write("{0}. Comandos Rover: ", roverCount);
                    string? roverCommand = Console.ReadLine();

                    Rovers roverEntity = _roverService.GenerateRover(roverCoordinate, roverCommand, platoEntity);

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
