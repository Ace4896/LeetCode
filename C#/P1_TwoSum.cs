using System;
using System.Collections.Generic;

namespace LeetCode;

public class P1_TwoSum
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Naive Solution: O(n^2)
        //for (int first = 0; first < nums.Length - 1; first++)
        //{
        //    for (int last = first + 1; last < nums.Length; last++)
        //    {
        //        if (nums[first] + nums[last] == target)
        //        {
        //            return new int[] { first, last };
        //        }
        //    }
        //}

        // Dictionary Solution: O(n)
        Dictionary<int, int> indices = new();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (indices.TryGetValue(complement, out int complementIndex))
            {
                return new int[] { complementIndex, i };
            }

            indices[nums[i]] = i;
        }

        throw new InvalidOperationException("No solution");
    }
}
