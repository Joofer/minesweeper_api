namespace Minesweeper.Abstractions;

public interface IGameManager
{
    static abstract List<List<string>> CreateGame(int width, int height, int minesCount);
}