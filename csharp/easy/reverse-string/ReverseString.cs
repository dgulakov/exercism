using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        Func<string, string>[] reverseFunctions = [StringReverse, ArrayReverse, StringBuilderReverse, SpanReverse];

        return reverseFunctions[Random.Shared.Next(reverseFunctions.Length)](input);
    }

    private static string StringReverse(string input) => new([.. input.Reverse()]);

    private static string ArrayReverse(string input)
    {
        var charArray = input.ToCharArray();
        Array.Reverse(charArray);

        return new(charArray);
    }

    private static string StringBuilderReverse(string input)
    {
        StringBuilder sb = new(input.Length);

        //this is actually can be done via foreach statement, but it will allocate enumerator etc
        for (int i=input.Length-1; i >= 0; --i)
        {
            sb.Append(input[i]);
        }

        return sb.ToString();
    }

    private static string SpanReverse(string input)
    {
        Span<char> span = stackalloc char[input.Length];
        input.AsSpan().CopyTo(span);
        span.Reverse();

        return new(span);
    }
}