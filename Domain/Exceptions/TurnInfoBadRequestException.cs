namespace Domain.Exceptions;

public sealed class TurnInfoBadRequestException : BadRequestException
{
    public TurnInfoBadRequestException() : base("Bad request: ошибка выполнения запроса.")
    {
    }
}