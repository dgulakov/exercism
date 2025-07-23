public class Anagram(string baseWord)
{
    public string[] FindAnagrams(string[] potentialMatches)
    {
        string normalizedBaseWord = NormalizeWord(baseWord);

        return [.. potentialMatches
            .Where(word => !string.Equals(baseWord, word, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(normalizedBaseWord, NormalizeWord(word), StringComparison.CurrentCultureIgnoreCase))];
    }

    private string NormalizeWord(string word) => string.Concat(word.ToUpper().Order());
}