using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup(int month, int year)
{
    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        if (schedule == Schedule.Teenth)
        {
            DateTime res = new DateTime(year, month, 13);

            return MoveDateToDayOfWeek(res, dayOfWeek);
        }
        else if (schedule == Schedule.Last)
        {
            DateTime res = new DateTime(year, month, 1).AddMonths(1);
            res = MoveDateToDayOfWeek(res, dayOfWeek);
            
            return res.AddDays(-7);
        }
        else
        {
            DateTime res = new DateTime(year, month, 1);
            res = MoveDateToDayOfWeek(res, dayOfWeek);
            int sequenceNumber = schedule switch
            {
                Schedule.First => 0,
                Schedule.Second => 1,
                Schedule.Third => 2,
                Schedule.Fourth => 3,
                _ => 0
            };
        
            return res.AddDays(7 * sequenceNumber);
        }
    }

    private static DateTime MoveDateToDayOfWeek(DateTime date, DayOfWeek dayOfWeek) 
        => date.AddDays((int)dayOfWeek - (int)date.DayOfWeek + (dayOfWeek < date.DayOfWeek ? 7 : 0));
}