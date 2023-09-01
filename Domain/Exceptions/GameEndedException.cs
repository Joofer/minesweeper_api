namespace Domain.Exceptions;

public sealed class GameEndedException : BadRequestException
{
    public GameEndedException() : base("Bad request: игра уже закончилась.")
    {
    }
}