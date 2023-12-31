﻿namespace CollectionManager;

public static class List2d<T>
{
    /// <summary>
    /// Генерирует 2-мерный динамический массив размера rows x columns, инициализированный default значениями.
    /// </summary>
    /// <param name="rows">количество столбцов</param>
    /// <param name="columns">количество строк</param>
    /// <param name="value">значение элемента (опционально)</param>
    /// <returns>2-мерный динамический массив размера rows x columns, инициализированный default значениями</returns>
    public static List<List<T>> Identity(int rows, int columns, T value = default)
    {
        List<List<T>> list2d = new();
        for (var i = 0; i < rows; i++)
        {
            var list = new List<T>();
            for (var j = 0; j < columns; j++)
                list.Add(value);
            list2d.Add(list);
        }
        return list2d;
    }

    /// <summary>
    /// Конвертирует 2-мерный динамический массив в строковый 2-мерный динамический массив.
    /// </summary>
    /// <param name="list">массив</param>
    /// <returns>строковый 2-мерный динамический массив</returns>
    /// <exception cref="NullReferenceException"></exception>
    public static List<List<string>> ToStringType(List<List<T>> list)
    {
        return list.Select(x =>
            x.Select(y => y.ToString()).ToList()
        ).ToList();
    }
}