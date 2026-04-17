namespace Practice;

public static class ArrayAlgorithms
{
    public static int MaximumElement(int[] numbers)
    {
        ValidateArray(numbers);
        return numbers.Max();
    }

    public static Dictionary<string, int> MaximumAndMinimumElements(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return new Dictionary<string, int> { ["max"] = 0, ["min"] = 0 };

        var max = numbers[0];
        var min = numbers[0];
        foreach (var n in numbers)
        {
            if (n > max) max = n;
            if (n < min) min = n;
        }

        return new Dictionary<string, int> { ["max"] = max, ["min"] = min };
    }

    public static double AverageOfAllElements(int[] numbers) => numbers == null || numbers.Length == 0 ? 0 : numbers.Average();

    public static Dictionary<string, int> CountOddAndEvenNumbers(int[] numbers)
    {
        var result = new Dictionary<string, int> { ["odd"] = 0, ["even"] = 0 };
        if (numbers == null)
            return result;

        foreach (var n in numbers)
        {
            if (n % 2 == 0) result["even"]++;
            else result["odd"]++;
        }
        return result;
    }

    public static int SecondLargestNumber(int[] numbers)
    {
        ValidateArray(numbers, 2);
        return numbers.Distinct().OrderByDescending(x => x).Skip(1).First();
    }

    public static int[] ReverseAnArray(int[] elements) => elements?.Reverse().ToArray() ?? Array.Empty<int>();

    public static bool CheckIfArrayIsSortedAscending(int[] elements)
    {
        if (elements == null || elements.Length < 2)
            return true;

        for (var i = 1; i < elements.Length; i++)
            if (elements[i] < elements[i - 1])
                return false;
        return true;
    }

    public static int[] RemoveDuplicates(int[] elements) => elements?.Distinct().ToArray() ?? Array.Empty<int>();

    public static int FindMissingNumber(int[] elements)
    {
        if (elements == null || elements.Length == 0)
            return 0;

        var n = elements.Length + 1;
        var expected = n * (n + 1) / 2;
        var actual = elements.Sum();
        return expected - actual;
    }

    public static int[] TwoSumIndices(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return Array.Empty<int>();

        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (map.TryGetValue(complement, out var index))
                return new[] { index, i };

            map[nums[i]] = i;
        }
        return Array.Empty<int>();
    }

    public static int[] TwoSumValues(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return Array.Empty<int>();

        var seen = new HashSet<int>();
        foreach (var num in nums)
        {
            var complement = target - num;
            if (seen.Contains(complement))
                return new[] { complement, num };
            seen.Add(num);
        }
        return Array.Empty<int>();
    }

    public static HashSet<(int, int)> TwoSumAllUniquePairs(int[] nums, int target)
    {
        var seen = new HashSet<int>();
        var result = new HashSet<(int, int)>();
        if (nums == null)
            return result;

        foreach (var num in nums)
        {
            var complement = target - num;
            if (seen.Contains(complement))
                result.Add((Math.Min(num, complement), Math.Max(num, complement)));
            seen.Add(num);
        }
        return result;
    }

    public static List<(int, int)> TwoSumAllIndexPairs(int[] nums, int target)
    {
        var result = new List<(int, int)>();
        if (nums == null)
            return result;

        var map = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (map.TryGetValue(complement, out var indices))
                foreach (var index in indices)
                    result.Add((index, i));

            if (!map.ContainsKey(nums[i]))
                map[nums[i]] = new List<int>();
            map[nums[i]].Add(i);
        }
        return result;
    }

    public static (int, int) TwoSumClosest(int[] nums, int target)
    {
        ValidateArray(nums, 2);
        var sorted = nums.OrderBy(x => x).ToArray();
        var left = 0;
        var right = sorted.Length - 1;
        var best = (sorted[left], sorted[right]);
        var minDiff = Math.Abs(target - (best.Item1 + best.Item2));

        while (left < right)
        {
            var sum = sorted[left] + sorted[right];
            var diff = Math.Abs(target - sum);
            if (diff < minDiff)
            {
                minDiff = diff;
                best = (sorted[left], sorted[right]);
            }

            if (sum < target) left++;
            else right--;
        }
        return best;
    }

    private static void ValidateArray(int[] numbers, int minLength = 1)
    {
        if (numbers == null || numbers.Length < minLength)
            throw new ArgumentException("Array input is invalid.");
    }
}
