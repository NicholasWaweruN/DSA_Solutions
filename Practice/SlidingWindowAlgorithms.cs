namespace Practice;

public static class SlidingWindowAlgorithms
{
    public static int MaximumSubArraySizeK(int[] nums, int k)
    {
        ValidateWindow(nums, k);
        var currentSum = 0;
        for (var i = 0; i < k; i++)
            currentSum += nums[i];

        var maxSum = currentSum;
        for (var i = k; i < nums.Length; i++)
        {
            currentSum += nums[i];
            currentSum -= nums[i - k];
            maxSum = Math.Max(maxSum, currentSum);
        }
        return maxSum;
    }

    public static double AverageSubArraySizeK(int[] nums, int k)
    {
        ValidateWindow(nums, k);
        var currentSum = 0;
        for (var i = 0; i < k; i++)
            currentSum += nums[i];

        var maxAverage = (double)currentSum / k;
        for (var i = k; i < nums.Length; i++)
        {
            currentSum += nums[i];
            currentSum -= nums[i - k];
            maxAverage = Math.Max(maxAverage, (double)currentSum / k);
        }
        return maxAverage;
    }

    public static int CountSubarraysSizeKWithSumAtLeastTarget(int[] nums, int k, int target)
    {
        ValidateWindow(nums, k);
        var sum = 0;
        var count = 0;

        for (var i = 0; i < k; i++)
            sum += nums[i];
        if (sum >= target)
            count++;

        for (var i = k; i < nums.Length; i++)
        {
            sum += nums[i];
            sum -= nums[i - k];
            if (sum >= target)
                count++;
        }
        return count;
    }

    public static int MaximumNumberOfVowels(string str, int k)
    {
        if (string.IsNullOrEmpty(str) || k <= 0 || k > str.Length)
            return 0;

        const string vowels = "aeiouAEIOU";
        var current = 0;
        for (var i = 0; i < k; i++)
            if (vowels.Contains(str[i])) current++;

        var max = current;
        for (var i = k; i < str.Length; i++)
        {
            if (vowels.Contains(str[i])) current++;
            if (vowels.Contains(str[i - k])) current--;
            max = Math.Max(max, current);
        }
        return max;
    }

    public static int DistinctElementsInSizeK(string str, int k)
    {
        if (string.IsNullOrEmpty(str) || k <= 0 || k > str.Length)
            return 0;

        var freq = new Dictionary<char, int>();
        for (var i = 0; i < k; i++)
            freq[str[i]] = freq.GetValueOrDefault(str[i]) + 1;

        var maxDistinct = freq.Count;
        for (var i = k; i < str.Length; i++)
        {
            var outgoing = str[i - k];
            freq[outgoing]--;
            if (freq[outgoing] == 0)
                freq.Remove(outgoing);

            var incoming = str[i];
            freq[incoming] = freq.GetValueOrDefault(incoming) + 1;
            maxDistinct = Math.Max(maxDistinct, freq.Count);
        }
        return maxDistinct;
    }

    public static List<int> FirstNegativeNumberInEveryWindow(int[] nums, int k)
    {
        ValidateWindow(nums, k);
        var result = new List<int>();
        var negatives = new Queue<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 0)
                negatives.Enqueue(i);

            if (i >= k - 1)
            {
                while (negatives.Count > 0 && negatives.Peek() <= i - k)
                    negatives.Dequeue();
                result.Add(negatives.Count > 0 ? nums[negatives.Peek()] : 0);
            }
        }
        return result;
    }

    private static void ValidateWindow(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k <= 0 || k > nums.Length)
            throw new ArgumentException("Invalid sliding window input.");
    }
}
