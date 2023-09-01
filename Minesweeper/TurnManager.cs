﻿using Minesweeper.Abstractions;
using Minesweeper.Exceptions;

namespace Minesweeper;

public class TurnManager : ITurnManager
{
    public static bool Open(List<List<string>> field, List<List<string>> originField, int xPosition, int yPosition)
    {
        if (IsOpened(field, xPosition, yPosition)) throw new BoxOpenedException(xPosition, yPosition);
        
        field[xPosition][yPosition] = originField[xPosition][yPosition];

        switch (field[xPosition][yPosition])
        {
            case "0":
                try { Open(field, originField, xPosition - 1, yPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, xPosition - 1, yPosition); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, xPosition - 1, yPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, xPosition, yPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, xPosition + 1, yPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, xPosition + 1, yPosition); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, xPosition + 1, yPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, xPosition, yPosition - 1); }
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