using System.ComponentModel;

namespace Rover.Shared.Enums
{
    public enum RoverError
    {
        [Description("Os comandos inseridos não são válidos para o Rover! Pode digitar apenas L, R ou M.")]
        WrongCommand,

        [Description("Há uma incompatibilidade entre a área a ser visitada e a coordenada móvel..")]
        WrongRoverCoordinate,

        [Description("As informações de localização inseridas para o Rover estão incorretas. Exemplo: 1 2 N")]
        WringDirection
    }
}
