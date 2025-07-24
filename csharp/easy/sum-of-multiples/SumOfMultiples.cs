using System.Diagnostics;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) => 
        multiples
            .Where(el => el > 0)
            .SelectMany(el => Enumerable.Range(1, (max - 1) / el).Select(ind => ind * el))
            .Distinct()
            .Sum();
}