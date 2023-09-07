namespace Minesweeper.Game.Core.Abstractions;

public interface ITurnManager
{
    static abstract int Turn(List<List<int>> field, List<List<int>> originField, int minesCount, int xPosition, int yPosition);
}