namespace Domain.Exceptions;

public sealed class GameInfoBadRequestException : BadRequestException
{
    public GameInfoBadRequestException() : base("Bad request: ошибка выполнения запроса.")
    {
    }
}