using System;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        int hundreds = (value % 1000) / 100;
        int tens = (value % 100) / 10;
        int units = value % 10;

        string res = new string('M', value / 1000);
        res += RomanNumeralExtension.ConvertArabicToRoman(hundreds, 'C', 'D', 'M');
        res += RomanNumeralExtension.ConvertArabicToRoman(tens, 'X', 'L', 'C');
        res += RomanNumeralExtension.ConvertArabicToRoman(units, 'I', 'V', 'X');

        return res;
    }

    private static string ConvertArabicToRoman(int num, char romanDigit, char romanHalf, char romanNextDigit) =>
        num switch
        {
            > 0 and < 10 =>
                (num % 5) switch
                {
                    0 => romanHalf.ToString(),
                    < 4 => $"{(num > 5 ? romanHalf.ToString() : string.Empty)}{new string(romanDigit, num % 5)}",
                    _ => $"{romanDigit}{(num > 5 ? romanNextDigit : romanHalf)}"
                },
            _ => string.Empty
        };
}