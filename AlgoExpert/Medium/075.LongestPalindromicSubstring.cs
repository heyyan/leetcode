using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class LongestPalindromicSubstring2
    {
        // input  abaxyzzyxf
        // output xyzzyx
        public void RunSolution()
        {
            var result = LongestPalindromicSubstring("abaxyzzyxf");
        }

        public string LongestPalindromicSubstring(string str)
        {
            int[] currentLongest = { 0, 1 };
            for (int i = 1; i < str.Length; i++)
            {
                int[] odd = GetLongestPalindromeFrom(str, i - 1, i + 1);
                int[] even = GetLongestPalindromeFrom(str, i - 1, i);
                int[] longest = Max(odd, even, (x) => x[1] - x[0]);
                currentLongest = Max(longest, currentLongest, (x) => x[1] - x[0]);
            }

            return str.Substring(currentLongest[0], currentLongest[1] - currentLongest[0]);
        }

        private int[] GetLongestPalindromeFrom(string str, int leftIdx, int rightIdx)
        {
            while (leftIdx >= 0 && rightIdx < str.Length)
            {
                if (str[leftIdx] != str[rightIdx])
                    break;

                leftIdx--;
                rightIdx++;
            }

            return new int[] { leftIdx + 1, rightIdx };
        }

        private int[] Max(int[] array1, int[] array2, Func<int[], int> keySelector)
        {
            return keySelector(array1) > keySelector(array2) ? array1 : array2;
        }

        private string GetLongestPalindromicSubstring2(string input)
        {
            string result = string.Empty;
         
            for (int i = 1; i < input.Length; i++)
            {
                int start = i - 1, end = i + 1;
                int evenStart = i;
                while (start >= 0 && end < input.Length)
                {
                    bool oddPalbol = false,evenPalbol = false;
                    var pal = input.Substring(start, end - start + 1);

                    if (isPalaindrom(pal))
                    {
                        oddPalbol = true;

                        if (result.Length < pal.Length)
                        {
                            result = pal;
                        }
                    }

                    var evenPal = input.Substring(evenStart, end - evenStart + 1);
                    if (isPalaindrom(evenPal))
                    {
                        evenPalbol = true;

                        if (result.Length < evenPal.Length)
                        {
                            result = evenPal;
                        }
                    }
                    if(!oddPalbol && !evenPalbol)
                    {
                        break;
                    }
                    start--;
                    evenStart--;
                    end++;
                }
            }

            return result;
        }


        private string GetLongestPalindromicSubstring(string input)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        if (isPalaindrom(input.Substring(i, j - i + 1)))
                        {
                            result.Add(input.Substring(i, j - i + 1));
                        }
                    }
                }
            }

            return result.OrderByDescending(x => x.Length).First();
        }

        public bool isPalaindrom(string input)
        {
            int start = 0, end = input.Length - 1;
            while (start < end)
            {
                if (input[start] == input[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
