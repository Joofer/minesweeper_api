namespace Minesweeper.Exceptions;

public sealed class BoxOpenedException : BadRequestException
{
    public BoxOpenedException(int yPosition, int xPosition) : base($"Bad request: ячейка ({yPosition}, {xPosition}) уже открыта.")
    {
    }
}