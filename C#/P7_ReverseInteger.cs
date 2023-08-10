using System;
using Xunit;

namespace LeetCode;

public class P7_ReverseInteger
{
    public int Reverse(int x)
    {
        //int result = 0;

        //if (x < 0)
        //{
        //    while (x < 0)
        //    {
        //        int tmp = result * 10;
        //        x = Math.DivRem(x, 10, out int digit);
        //        tmp += digit;   // Remainder is negative in this case, so need to add

        //        // See if overflow has occurred
        //        if (tmp > result)
        //        {
        //            return 0;
        //        }

        //        result = tmp;
        //    }
        //}
        //else
        //{
        //    while (x > 0)
        //    {
        //        // This saturates very strangely sometimes
        //        int tmp = result * 10;
        //        x = Math.DivRem(x, 10, out int digit);
        //        tmp += digit;

        //        // See if overflow has occurred
        //        if (tmp < result)
        //        {
        //            return 0;
        //        }

        //        result = tmp;
        //    }
        //}

        //return result;

        // Using 'checked' keyword allows us to catch overflow, but is slower overall
        try
        {
            int result = 0;

            if (x < 0)
            {
                while (x < 0)
                {
                    x = Math.DivRem(x, 10, out int digit);
                    result = checked((result * 10) + digit);
                }
            }
            else
            {
                while (x > 0)
                {
                    x = Math.DivRem(x, 10, out int digit);
                    result = checked((result * 10) + digit);
                }
            }

            return result;
        }
        catch (OverflowException)
        {
            return 0;
        }
    }

    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(1534236469, 0)] // This case overflows on the last digit
    public void ReverseTest(int input, int expected)
    {
        Assert.Equal(expected, Reverse(input));
    }
}
