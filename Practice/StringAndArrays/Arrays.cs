using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.StringAndArrays
{
    internal class Arraies : IArraies
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complete = target - nums[i];
                if (map.TryGetValue(complete, out var value))
                {
                    return [value, nums[i]];
                }

                map.Add(complete, nums[i]);
            }
            return [];
        }

     

    }
}
