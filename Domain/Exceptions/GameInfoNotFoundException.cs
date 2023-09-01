using Domain.Entities;

namespace Domain.Exceptions;

public sealed class GameInfoNotFoundException : NotFoundException
{
    public GameInfoNotFoundException(object keyValue) : base($"Not found: объект {nameof(GameInfo)} с идентификатором {keyValue} не найден.")
    {
    }
}