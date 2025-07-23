using System;

public static class Gigasecond
{
    private const double GIGASECOND_VALUE = 1_000_000_000;
    
    public static DateTime Add(DateTime moment) => moment.AddSeconds(GIGASECOND_VALUE);
}