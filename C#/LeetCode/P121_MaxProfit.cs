using System;

namespace LeetCode;

public class P121_MaxProfit
{
    public int MaxProfit(int[] prices)
    {
        // Naive Solution: O(n^2) - too slow for one of the test cases
        //int maxProfit = 0;

        //for (int buy = 0; buy < prices.Length - 1; buy++)
        //{
        //    for (int sell = buy + 1; sell < prices.Length; sell++)
        //    {
        //        maxProfit = Math.Max(maxProfit, prices[sell] - prices[buy]);
        //    }
        //}

        //return maxProfit;

        // Sliding Window Solution: O(n)
        // Had to look at solutions for this one; got confused by the "can only sell in the future" part for the pointers.
        // The sliding window essentially lets us calculate the maximum profit for a certain time period
        // If we encounter a lower buy value to start with, then we "move on" to the next time period
        int lowest = int.MaxValue;
        int maxProfit = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            // If we found a new buy value that is smaller than the previous, update it
            if (prices[i] < lowest)
            {
                lowest = prices[i];
            }

            // Determine the profit if sold today, and see if it's greater
            int profit = prices[i] - lowest;
            maxProfit = Math.Max(maxProfit, profit);
        }

        return maxProfit;
    }
}
