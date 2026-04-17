namespace Practice;

public static class ListAlgorithms
{
    public static List<int> ReverseList(List<int> list) => list?.AsEnumerable().Reverse().ToList() ?? new List<int>();

    public static List<int> ReverseListUsingStack(List<int> list)
    {
        if (list == null)
            return new List<int>();

        var stack = new Stack<int>(list);
        return stack.ToList();
    }

    public static List<int> RemoveDuplicates(List<int> list) => list?.Distinct().ToList() ?? new List<int>();

    public static List<(int, int)> PairsWithSumK(List<int> ints, int k)
    {
        var result = new List<(int, int)>();
        if (ints == null)
            return result;

        var seen = new HashSet<int>();
        var used = new HashSet<(int, int)>();
        foreach (var num in ints)
        {
            var complement = k - num;
            if (seen.Contains(complement))
            {
                var pair = (Math.Min(num, complement), Math.Max(num, complement));
                if (used.Add(pair))
                    result.Add(pair);
            }
            seen.Add(num);
        }
        return result;
    }
}
