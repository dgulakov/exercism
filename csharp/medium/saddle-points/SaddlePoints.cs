using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var rowsMax = new int[matrix.GetLength(0)];
        var columnsMin = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                columnsMin[j] = i == 0 ? matrix[i, j] : Math.Min(columnsMin[j], matrix[i, j]);
                rowsMax[i] = j == 0 ? matrix[i, j] : Math.Max(rowsMax[i], matrix[i, j]);
            }
        }

        for (int i = 0; i < matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                if (matrix[i, j] == rowsMax[i] && matrix[i, j] == columnsMin[j])
                {
                    yield return (i + 1, j + 1);
                }
            }
        }
    }
}
