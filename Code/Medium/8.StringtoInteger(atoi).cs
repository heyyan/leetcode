using System;

namespace leetcode
{
    public class StringtoIntegerATOI
    {
        public void RunMyAtoiTest()
        {

            //Console.WriteLine($"'+1' should be 1 => { atoi("+1")}");
            //Console.WriteLine($"'-' should be 0 => { atoi("-")}");
            // Console.WriteLine($"'1-1' should be 1 => { atoi("1-1")}");
            // Console.WriteLine($"'1-1' should be 1 => { MyAtoi("1-1")}");
            // Console.WriteLine($"'-13+8' should be -13 => { atoi("-13+8")}");
            Console.WriteLine($"'2147483646' should be 2147483646 => { atoi("2147483646")}");
            Console.WriteLine($"'2147483646' should be 2147483646 => { MyAtoi2("2147483646")}");
            Console.WriteLine($"'2147483646' should be 2147483646 => { MyAtoi("2147483646")}");
            // Console.WriteLine($"'+-2' should be 0 => { atoi("+-2")}");
            // Console.WriteLine($"'+-2' should be 0 => { MyAtoi2("+-2")}");
            // Console.WriteLine($"'+-2' should be 0 => { MyAtoi("+-2")}");
            // Console.WriteLine($"'-+2' should be 2 => { atoi("-+2")}");
            // Console.WriteLine($"'-+2' should be 2 => { MyAtoi2("-+2")}");
            // Console.WriteLine($"'42' should be 42 => { atoi("42")}");
            // Console.WriteLine($"'   -42' should be 42 => { atoi("   -42")}");
            // Console.WriteLine($"'4193 with words 9' should be 4193 => { atoi("4193 with words 9")}");
            // Console.WriteLine($"'words and 987' should be 0 => { atoi("words and 987")}");
            // Console.WriteLine($"'-91283472332' should be -2147483648 => { atoi("-91283472332")}");


        }

        public int MyAtoi2(string str)
        {
            int index = 0, sign = 1, total = 0;
            //1. Remove spaces
            while (index < str.Length && str[index] == ' ') index++;
            //2. Get sign
            sign = index < str.Length && (str[index] == '+' || str[index] == '-') ? str[index++] == '+' ? 1 : -1 : 1;
            //3. Calculate it and take care of overflow
            while (index < str.Length)
            {
                int digit = str[index++] - '0';
                if (digit < 0 || 9 < digit) break;
                if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digit)
                    return sign == -1 ? int.MinValue : int.MaxValue;
                total = total * 10 + digit;
            }
            return total * sign;
        }
        public int atoi(string str)
        {
            int result = 0;
            bool isNegitive = false;
            str = str.Trim();
            bool beginining = true;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '-')
                {
                    if (!beginining) break;
                    beginining = false;
                    isNegitive = true;
                    continue;
                }
                if (str[i] == '+')
                {
                    if (!beginining) break;
                    beginining = false;
                    isNegitive = false;
                    continue;
                }

                if (48 <= str[i] && str[i] <= 57)
                {
                    beginining = false;
                    if (int.MaxValue / 10 < result || int.MaxValue / 10 == result && int.MaxValue % 10 < int.Parse(str[i].ToString()))
                    {
                        return (isNegitive) ? int.MinValue : int.MaxValue;
                    }
                    result = result * 10 + int.Parse(str[i].ToString());
                }
                else
                {
                    break;
                }
            }

            if (isNegitive) result *= -1;
            return result;
        }

        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length == 0)
            {
                return 0;
            }
            var newstr = str.Trim();
            bool isNegative = newstr[0] == '-';
            int j = 0;
            if (isNegative) j = 1;
            int result = 0;
            //if (newstr[j] < 48 || newstr[j] > 57) return 0;
            for (int i = j; i < newstr.Length; i++)
            {
                if (48 <= newstr[i] && newstr[i] <= 57)
                {
                    result = result * 10;
                    result += int.Parse(newstr[i].ToString());
                    int threshold = (int.MaxValue - int.Parse(newstr[i].ToString())) / 10;
                    if (result > threshold)
                    {
                        if (isNegative) return int.MinValue;
                        return int.MaxValue;
                    }
                }
                else
                {
                    break;
                }
            }
            if (isNegative) result = result * -1;
            return result;
        }
    }
}