namespace Practice;

public static class PrefixSumAlgorithms
{
    public static int SubarraySumEqualsK(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        var prefixCount = new Dictionary<int, int> { [0] = 1 };
        var sum = 0;
        var count = 0;

        foreach (var num in nums)
        {
            sum += num;
            if (prefixCount.TryGetValue(sum - k, out var freq))
                count += freq;
            prefixCount[sum] = prefixCount.GetValueOrDefault(sum) + 1;
        }
        return count;
    }
}
