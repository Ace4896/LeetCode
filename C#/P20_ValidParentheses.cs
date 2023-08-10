using System.Collections.Generic;

namespace LeetCode;

public class P20_ValidParentheses
{
    public bool IsValid(string s)
    {
        Stack<char> openParentheses = new();
        char openParenthesis;

        foreach (char c in s)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    openParentheses.Push(c);
                    break;

                case ')':
                    if (!openParentheses.TryPop(out openParenthesis) || openParenthesis != '(')
                    {
                        return false;
                    }

                    break;

                case ']':
                    if (!openParentheses.TryPop(out openParenthesis) || openParenthesis != '[')
                    {
                        return false;
                    }

                    break;

                case '}':
                    if (!openParentheses.TryPop(out openParenthesis) || openParenthesis != '{')
                    {
                        return false;
                    }

                    break;
            }
        }

        return openParentheses.Count == 0;
    }
}
