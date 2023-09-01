using Minesweeper.Abstractions;
using Minesweeper.Exceptions;

namespace Minesweeper;

public class TurnManager : ITurnManager
{
    /// <summary>
    /// Открывает ячейку (yPosition, xPosition).
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="originField">полное поле</param>
    /// <param name="yPosition">позиция ячейки x</param>
    /// <param name="xPosition">позиция ячейки y</param>
    /// <returns>true, если в ячейке есть мина, иначе - false</returns>
    public static bool Open(List<List<string>> field, List<List<string>> originField, int yPosition, int xPosition)
    {
        if (IsOpened(field, yPosition, xPosition)) throw new BoxOpenedException(yPosition, xPosition);
        
        field[yPosition][xPosition] = originField[yPosition][xPosition];

        switch (field[yPosition][xPosition])
        {
            case "0":
                try { Open(field, originField, yPosition - 1, xPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, yPosition - 1, xPosition); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, yPosition - 1, xPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, yPosition, xPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, yPosition + 1, xPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, yPosition + 1, xPosition); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, yPosition + 1, xPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, yPosition, xPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                break;

            case "X":
                return true;
        }

        return false;
    }

    private static bool IsOpened(List<List<string>> field, int xPosition, int yPosition)
    {
        return field[xPosition][yPosition] != " ";
    }
}