namespace Practice;

public static class StackQueueAlgorithms
{
    public static bool ValidateParenthesisReplace(string str)
    {
        if (string.IsNullOrEmpty(str) || str.Length % 2 != 0)
            return false;

        string current = str;
        string previous;
        do
        {
            previous = current;
            current = current.Replace("()", string.Empty)
                             .Replace("[]", string.Empty)
                             .Replace("{}", string.Empty);
        } while (current.Length != previous.Length);

        return current.Length == 0;
    }

    public static bool ValidateParenthesisStack(string str)
    {
        if (string.IsNullOrEmpty(str) || str.Length % 2 != 0)
            return false;

        var stack = new Stack<char>();
        var matching = new Dictionary<char, char>
        {
            [')'] = '(',
            [']'] = '[',
            ['}'] = '{'
        };

        foreach (var ch in str)
        {
            if (ch is '(' or '[' or '{')
            {
                stack.Push(ch);
            }
            else if (matching.TryGetValue(ch, out var expected))
            {
                if (stack.Count == 0 || stack.Pop() != expected)
                    return false;
            }
            else
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}
