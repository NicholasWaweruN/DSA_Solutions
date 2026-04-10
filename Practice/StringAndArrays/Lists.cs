using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Practice.StringAndArrays
{
    public class Lists
    {
        public Lists() { }

        public List<int> ReverseList(List<int> list)
        {
          var array =  list.ToArray().Reverse();
           return array.ToList();
        }
        public static List<int> ReverseList2(List<int> list)
        {
           
            var stack = new Stack<int>();
            var list2 = new List<int>();
            foreach (var item in list) 
            {
                stack.Push(item);
            }
            foreach(var item in stack)
            {
                var pop = stack.Pop();
                list2.Add(pop);
            }

            return list2;
        }

        public List<int> RemoveDuplicates(List<int> list) 
        {
            var map = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if(!map.Contains(list[i]))
                {
                    map.Add(list[i]);
                }

            }
            return map;
        }

        //Find All Pairs with Sum K

        public List<int> PairsWithSumK(List<int> ints, int k)
        {
            var right = ints.Count();
            var left = 0;
            var theList = new List<int>();

            for (int i = 1; i < right && left != right; i++)
            {
                
                var currentSum = ints[i] + ints[left];
                if (currentSum == k)
                {
                    theList.Add(ints[i]);
                    theList.Add(ints[left]);
                    return theList;
                }
                if (i == right)
                    left++;
            }
            return theList;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complete = target - nums[i];
                if(map.TryGetValue(complete, out var result))
                {
                    return [result,i];
                }
                map.TryAdd(nums[i], i);
            }
            return [];
        }

     
   
    }
}
