public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] res = new int[size, size];

        int minRow = 0;
        int maxRow = size;
        int minCol = 0;
        int maxCol = size;

        int rowStep = 0;
        int colStep = 1;

        int rowInd = minRow;
        int colInd = minCol;

        foreach (int el in Enumerable.Range(1, size * size))
        {
            res[rowInd, colInd] = el;

            rowInd += rowStep;
            if (rowInd < minRow || rowInd == maxRow)
            {
                if (colInd == minCol)
                {
                    ++minCol;
                }
                if (colInd == (maxCol - 1))
                {
                    --maxCol;
                }

                rowInd -= rowStep;

                colStep = -1 * rowStep;
                rowStep = 0;
            }

            colInd += colStep;
            if (colInd < minCol || colInd == maxCol)
            {
                if (rowInd == minRow)
                {
                    ++minRow;
                }
                else if (rowInd == (maxRow - 1))
                {
                    --maxRow;
                }

                colInd -= colStep;

                rowStep = colStep;
                colStep = 0;

                rowInd += rowStep;
            }
        }

        return res;
    }
}
