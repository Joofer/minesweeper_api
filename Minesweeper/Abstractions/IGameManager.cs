namespace Minesweeper.Abstractions;

public interface IGameManager
{
    static abstract List<List<int>> CreateGame(int width, int height, int minesCount);
}