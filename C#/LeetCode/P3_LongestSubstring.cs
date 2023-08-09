using System;
using System.Collections.Generic;

namespace LeetCode;

public class P3_LongestSubstring
{
    public int LengthOfLongestSubstring(string s)
    {
        int longest = 0;
        int start = 0;
        int end;

        HashSet<char> currentChars = new();

        for (end = 0; end < s.Length; end++)
        {
            if (currentChars.Contains(s[end]))
            {
                // See if the sequence up until now is longer
                longest = Math.Max(longest, end - start);

                // Keep incrementing the start index until the duplicate is removed
                while (currentChars.Contains(s[end]))
                {
                    currentChars.Remove(s[start]);
                    start++;
                }
            }

            // Keep track of this character
            currentChars.Add(s[end]);
        }

        // See if the final subsequence is longer
        longest = Math.Max(longest, end - start);

        return longest;
    }
}
