using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        StringBuilder res = new();

        int counter = 0;
        char? currentChar = null;

        foreach (char c in input)
        {
            if (currentChar == c)
            {
                ++counter;
            }
            else
            {
                if (currentChar.HasValue)
                {
                    if (counter > 1)
                    {
                        res.Append(counter);
                    }
                    res.Append(currentChar);
                }

                currentChar = c;
                counter = 1;
            }
        }

        if (currentChar.HasValue)
        {
            if (counter > 1)
            {
                res.Append(counter);
            }
            res.Append(currentChar);
        }

        return res.ToString();
    }

    public static string Decode(string input)
    {
        StringBuilder res = new();

        int ind = 0;

        while (ind < input.Length) {
            string counter = new string([..input.Skip(ind).TakeWhile((ch, ind) => char.IsDigit(ch))]);
            char currentChar = input[ind + counter.Length];

            res.Append(new string(currentChar, int.TryParse(counter, out int count) ? count : 1));

            ind += counter.Length + 1;
        }

        return res.ToString();
    }
}
