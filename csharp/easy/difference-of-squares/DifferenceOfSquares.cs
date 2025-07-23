using System;

public static class DifferenceOfSquares
{
    //it's just the squared sum of the terms in an arithmetic progression: S*S, S=n/2 * [2 * a + (n-1) * d].
    //Where n - number of terms in progression, in our case it's 'max';
    //      d - difference between terms and = '1'
    //      a - is the first member, that is in our case again '1'
    //So, in summary we will have S= max / 2 * (2 * 1 + (max - 1) * 1) = max * (2 + max - 1) / 2 = (max + 1) * max / 2
    public static int CalculateSquareOfSum(int max) =>  ((1 + max) * max / 2) * ((1 + max) * max / 2);

    //S = n(n+1)(2n+1)/6
    public static int CalculateSumOfSquares(int max) => max * (max + 1) * (2 * max + 1) / 6;

    public static int CalculateDifferenceOfSquares(int max) => DifferenceOfSquares.CalculateSquareOfSum(max) - DifferenceOfSquares.CalculateSumOfSquares(max);
}