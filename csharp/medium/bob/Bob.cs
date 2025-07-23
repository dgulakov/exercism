using System;

public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.IsSilence())
        {
            return "Fine. Be that way!";
        }
        else if (statement.IsYelling())
        {
            return statement.IsQuestion() ? "Calm down, I know what I'm doing!" : "Whoa, chill out!";
        }
        else if (statement.IsQuestion())
        {
            return "Sure.";
        }

        return "Whatever.";
    }

    public static bool IsSilence(this string statement) => string.IsNullOrWhiteSpace(statement);

    public static bool IsQuestion(this string statement) => statement.TrimEnd().EndsWith("?");

    public static bool IsYelling(this string statement)
    {
        string capitalizedStatement = statement.ToUpper();

        //capitalizedStatement != statement.ToLower() - that will work only if sentence has any char that actually can be upper or lower cased.
        //If a statement consists only of numbers and signs, it won't be an yelling statement.
        //Same check can be done if we check if any char in sentence is Char.IsLetter 
        return capitalizedStatement == statement && capitalizedStatement != statement.ToLower();
    }
}