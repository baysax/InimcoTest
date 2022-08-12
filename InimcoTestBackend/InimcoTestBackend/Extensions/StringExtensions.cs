namespace InimcoTestBackend.Extensions;

public static class StringExtensions
{
    private static readonly char[] Vowels = {'a', 'e', 'i', 'o', 'u'};
    private static readonly char[] Consonants =
        {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};

    public static int CountVowels(this string word)
    {
        return word.Count(c => Vowels.Contains(char.ToLower(c)));
    }

    public static int CountConsonants(this string word)
    {
        return word.Count(c => Consonants.Contains(char.ToLower(c)));
    }
    
    public static string Reverse(this string word)
    {
        var charArray = word.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}