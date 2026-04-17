namespace Practice;

public static class StringAlgorithms
{
    public static string ReverseString(string str) => string.IsNullOrEmpty(str) ? string.Empty : new string(str.Reverse().ToArray());

    public static string ReverseString2(string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;

        var sb = new StringBuilder(str.Length);
        for (var i = str.Length - 1; i >= 0; i--)
            sb.Append(str[i]);

        return sb.ToString();
    }

    public static bool IsPalindrome(string input)
    {
        if (input is null)
            return false;

        return input.Equals(ReverseString(input), StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsPalindrome2(string input)
    {
        if (input is null)
            return false;

        var left = 0;
        var right = input.Length - 1;
        while (left < right)
        {
            if (char.ToLowerInvariant(input[left]) != char.ToLowerInvariant(input[right]))
                return false;
            left++;
            right--;
        }
        return true;
    }

    public static string RemoveAllWhiteSpaces(string str) => string.IsNullOrWhiteSpace(str) ? string.Empty : new string(str.Where(c => !char.IsWhiteSpace(c)).ToArray());

    public static string ReplaceVowelsWithStar(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return string.Empty;

        const string vowels = "aeiouAEIOU";
        var sb = new StringBuilder(sentence.Length);
        foreach (var ch in sentence)
            sb.Append(vowels.Contains(ch) ? '*' : ch);
        return sb.ToString();
    }

    public static string TitleCase(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return string.Empty;

        return string.Join(' ', str.ToLowerInvariant()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => char.ToUpperInvariant(word[0]) + word[1..]));
    }

    public static string TitleCaseTwoPointer(string str) => TitleCase(str);

    public static int CountVowels(string str)
    {
        if (string.IsNullOrEmpty(str))
            return 0;

        const string vowels = "aeiouAEIOU";
        return str.Count(c => vowels.Contains(c));
    }

    public static Dictionary<char, int> EachCountVowels(string str)
    {
        var result = new Dictionary<char, int>();
        if (string.IsNullOrEmpty(str))
            return result;

        const string vowels = "aeiou";
        foreach (var ch in str.ToLowerInvariant())
        {
            if (!vowels.Contains(ch))
                continue;
            result[ch] = result.GetValueOrDefault(ch) + 1;
        }
        return result;
    }

    public static Dictionary<string, int> CountVowelConsonants(string sentence)
    {
        var result = new Dictionary<string, int> { ["vowels"] = 0, ["consonants"] = 0 };
        if (string.IsNullOrEmpty(sentence))
            return result;

        const string vowels = "aeiou";
        foreach (var ch in sentence.ToLowerInvariant())
        {
            if (!char.IsLetter(ch))
                continue;
            if (vowels.Contains(ch))
                result["vowels"]++;
            else
                result["consonants"]++;
        }
        return result;
    }

    public static string[] RemoveDuplicates(string[] words) => words?.Distinct(StringComparer.OrdinalIgnoreCase).ToArray() ?? Array.Empty<string>();

    public static Dictionary<char, int> CharacterOccurrence(string sentence)
    {
        var result = new Dictionary<char, int>();
        if (string.IsNullOrWhiteSpace(sentence))
            return result;

        foreach (var ch in sentence)
        {
            if (char.IsWhiteSpace(ch))
                continue;
            var key = char.ToLowerInvariant(ch);
            result[key] = result.GetValueOrDefault(key) + 1;
        }
        return result;
    }

    public static string ReverseWordsSimpleMethod(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return string.Empty;

        var words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(' ', words);
    }

    public static string ReverseWordsTwoPointer(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return string.Empty;

        var sb = new StringBuilder();
        var right = str.Length - 1;
        while (right >= 0)
        {
            while (right >= 0 && str[right] == ' ')
                right--;
            if (right < 0)
                break;

            var left = right;
            while (left >= 0 && str[left] != ' ')
                left--;

            sb.Append(str.Substring(left + 1, right - left)).Append(' ');
            right = left - 1;
        }
        return sb.ToString().TrimEnd();
    }

    public static string FirstNonRepeatingChars(string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;

        var counts = new Dictionary<char, int>();
        foreach (var ch in str)
            counts[ch] = counts.GetValueOrDefault(ch) + 1;

        foreach (var ch in str)
            if (counts[ch] == 1)
                return ch.ToString();

        return string.Empty;
    }

    public static bool IsStringsAnagrams(string one, string two)
    {
        if (string.IsNullOrWhiteSpace(one) || string.IsNullOrWhiteSpace(two))
            return false;

        var normalizedOne = new string(one.Where(c => !char.IsWhiteSpace(c)).Select(char.ToLowerInvariant).OrderBy(c => c).ToArray());
        var normalizedTwo = new string(two.Where(c => !char.IsWhiteSpace(c)).Select(char.ToLowerInvariant).OrderBy(c => c).ToArray());
        return normalizedOne == normalizedTwo;
    }

    public static KeyValuePair<string, int> LengthLongestWordInASentence(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return new KeyValuePair<string, int>(string.Empty, 0);

        var word = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .OrderByDescending(x => x.Length)
            .First();

        return new KeyValuePair<string, int>(word, word.Length);
    }

    public static bool HasAllUniqueCharacters(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        var set = new HashSet<char>();
        foreach (var ch in input)
            if (!set.Add(ch))
                return false;
        return true;
    }

    public static string ReverseWordsKeepSameOrder(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return string.Empty;

        return string.Join(' ', sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new string(word.Reverse().ToArray())));
    }

    public static string DecodeString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var countStack = new Stack<int>();
        var stringStack = new Stack<StringBuilder>();
        var current = new StringBuilder();
        var k = 0;

        foreach (var ch in input)
        {
            if (char.IsDigit(ch))
            {
                k = k * 10 + (ch - '0');
            }
            else if (ch == '[')
            {
                countStack.Push(k);
                stringStack.Push(current);
                current = new StringBuilder();
                k = 0;
            }
            else if (ch == ']')
            {
                var repeat = countStack.Pop();
                var parent = stringStack.Pop();
                for (var i = 0; i < repeat; i++)
                    parent.Append(current);
                current = parent;
            }
            else
            {
                current.Append(ch);
            }
        }

        return current.ToString();
    }
}
