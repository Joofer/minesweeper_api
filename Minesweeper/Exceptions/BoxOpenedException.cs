namespace Minesweeper.Exceptions;

public sealed class BoxOpenedException : BadRequestException
{
    public BoxOpenedException(int xPosition, int yPosition) : base($"Bad request: ячейка ({xPosition}, {yPosition}) уже открыта.")
    {
    }
}