namespace Minesweeper.Abstractions;

public interface IGameManager
{
    /// <summary>
    /// Генерирует игровое поле width x height с minesCount количеством мин.
    /// </summary>
    /// <param name="width">ширина</param>
    /// <param name="height">высота</param>
    /// <param name="minesCount">количество мин</param>
    /// <returns>игровое поле width x height с minesCount количеством мин</returns>
    static abstract List<List<string>> CreateGame(int width, int height, int minesCount);
}