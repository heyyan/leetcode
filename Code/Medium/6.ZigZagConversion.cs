using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    public class ZigZagConversion
    {
        public void RunConvertTest()
        {

            Console.WriteLine($"PAYPALISHIRING  3 rows [PAHNAPLSIIGYIR] => { Convert("PAYPALISHIRING", 3) }");
            Console.WriteLine($"PAYPALISHIRING  4 rows [PINALSIGYAHRPI] => { Convert("PAYPALISHIRING", 4) }");

            Console.WriteLine($"PAYPALISHIRING  3 rows [PAHNAPLSIIGYIR] => { Convert2("PAYPALISHIRING", 3) }");
            Console.WriteLine($"PAYPALISHIRING  4 rows [PINALSIGYAHRPI] => { Convert2("PAYPALISHIRING", 4) }");
        }

        public string Convert2(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            string[] arr = new string[numRows];
            int row = 0;
            bool down = true;
            for (int i = 0; i < s.Length; i++)
            {
                // append current character to the current
                arr[row] += s[i];
                // if last row is reached change direction to up
                if (row == numRows - 1)
                {
                    down = false;
                }
                else if (row == 0)
                {
                    down = true;
                }
                if (down)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            return string.Join("",arr);
        }
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            List<string> resuts = new List<string>();
            for (int i = 0; i < numRows; i++)
            {
                resuts.Add("");
            }
            bool increment = true;
            int ro = 0;
            foreach (var c in s)
            {
                if (increment)
                {
                    resuts[ro] += c;

                    if (ro == numRows - 1)
                    {
                        increment = false;
                        ro--;
                        continue;
                    }
                    ro++;
                }
                else
                {
                    resuts[ro] += c;

                    if (ro == 0)
                    {
                        increment = true;
                        ro++;
                        continue;
                    }
                    ro--;
                }
            }

            StringBuilder builder = new StringBuilder();
            foreach (var item in resuts)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
    }
}