using System;

public class RailFenceCipher(int rails)
{
    public string Encode(string input)
    {
        var matrix = InitializeMatrix(input.Length);

        //fill matrix
        int ind = 0;
        bool goingDown = false;
        for (int i=0; i<input.Length; i++)
        {
            if (ind == 0 || ind == (rails - 1))
            {
                goingDown = !goingDown;
            }

            matrix[ind][i] = input[i];

            ind += goingDown ? 1: -1;
        }

        //read matrix for encoded output
        var encoded = new char[input.Length];
        ind = 0;
        for (int i=0; i<matrix.Length; ++i)
        {
            for (int j=0; j<matrix[i].Length; ++j)
            {
                if (matrix[i][j].HasValue)
                {
                    encoded[ind++] = matrix[i][j].Value;
                }
            }
        }

        return new string(encoded);
    }

    public string Decode(string input)
    {
        var matrix = InitializeMatrix(input.Length);

        // mark in matrix positions requiring char
        int ind = 0;
        bool goingDown = false;
        for (int i = 0; i < input.Length; i++)
        {
            if (ind == 0 || ind == (rails - 1))
            {
                goingDown = !goingDown;
            }

            matrix[ind][i] = (char)0;

            ind += goingDown ? 1 : -1;
        }

        // fill matrix with chars from encoded string
        var encodedEnumerator = input.GetEnumerator();
        for (int i=0; i<matrix.Length; ++i)
        {
            for (int j=0; j<matrix[i].Length; ++j)
            {
                if (matrix[i][j].HasValue && encodedEnumerator.MoveNext())
                {
                    matrix[i][j] = encodedEnumerator.Current;
                }
            }
        }

        //read matrix for decoded output
        var decoded = new char[input.Length];
        ind = 0;
        goingDown = false;
        for (int i = 0; i < input.Length; i++)
        {
            if (ind == 0 || ind == (rails - 1))
            {
                goingDown = !goingDown;
            }

            decoded[i] = matrix[ind][i].Value;

            ind += goingDown ? 1 : -1;
        }

        return new string(decoded);
    }

    private char?[][] InitializeMatrix(int length)
    {
        var matrix = new char?[rails][];
        for (int i = 0; i < matrix.Length; ++i)
        {
            matrix[i] = new char?[length];
        }
        return matrix;
    }
}