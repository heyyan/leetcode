using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class PhoneNumberMnemonics
    {
        // input 1905
        // output ["1w0j","1w0k","1w0l","1x0j","1x0k","1x0l","1y0j","1y0k","1y0l","1z0j","1z0k","1z0l"]
        public void RunSolution()
        {
            var values = GetPhoneNumberMnemonicsRecur(1905);
        }

        private List<string> GetPhoneNumberMnemonicsRecur(int phoneNumber)
        {
            List<string> mnemonicsFound = new();
            List<string> currentMnemonices = new();
            for (int i = 0; i < phoneNumber.ToString().Length; i++)
            {
                currentMnemonices.Add("0");
            }
            Dictionary<string, List<string>> DIGIT_LETTERS = new()
            {
                { "0", new List<string> { "0"} },
                { "1", new List<string> {"1" } },
                { "2", new List<string> {"a","b","c"} },
                { "3", new List<string> {"d","e","f"} },
                { "4", new List<string> {"g","h","i"} },
                { "5", new List<string> {"j","k","l"} },
                { "6", new List<string> {"m","n","o"} },
                { "7", new List<string> {"p","q","r","s"} },
                { "8", new List<string> {"t","u","v"} },
                { "9", new List<string> {"w","x","y","z"} }

            };

            PhoneNumberMnemonicsHelper(0, phoneNumber.ToString(), currentMnemonices, mnemonicsFound, DIGIT_LETTERS);
            return mnemonicsFound;
        }

        private void PhoneNumberMnemonicsHelper(int idx, string phoneNumber, List<string> currentMnemonices, List<string> mnemonicsFound, Dictionary<string, List<string>> dIGIT_LETTERS)
        {
            if (idx == phoneNumber.Length)
            {
                var mnemonic = string.Join("", currentMnemonices);
                mnemonicsFound.Add(mnemonic);
            }
            else
            {
                var digit = phoneNumber[idx];
                var letters = dIGIT_LETTERS[digit.ToString()];
                foreach (var letter in letters)
                {
                    currentMnemonices[idx] = letter;
                    PhoneNumberMnemonicsHelper(idx + 1, phoneNumber.ToString(), currentMnemonices, mnemonicsFound, dIGIT_LETTERS);

                }
            }
        }

        private List<string> GetPhoneNumberMnemonics(int number)
        {
            List<string> result = new();
            Dictionary<int, List<char>> map = new()
            {
                { 1, new List<char>() },
                { 2, new List<char> {'a','b','c'} },
                { 3, new List<char> {'d','e','f'} },
                { 4, new List<char> {'g','h','i'} },
                { 5, new List<char> {'j','k','l'} },
                { 6, new List<char> {'m','n','o'} },
                { 7, new List<char> {'p','q','r','s'} },
                { 8, new List<char> {'t','u','v'} },
                { 9, new List<char> {'w','x','y','z'} },
                { 0, new List<char>() }
            };

            var numberList = BreakDownNumber(number);

            List<string> newL = new();
            foreach (var num in numberList)
            {
                if (num == 1 || num == 0)
                {
                    newL.Add(num.ToString());
                    continue;
                }
                newL.Add(map[num].FirstOrDefault().ToString());
            }
            result.Add(string.Join("", newL));
            for (int i = numberList.Count - 1; i > 0; i--)
            {
                if (numberList[i] != 0 && numberList[i] != 1)
                {
                    var item = GetCombinition(result, map, numberList[i], i);
                    result.AddRange(item);
                }
            }

            return result;
        }

        private List<string> GetCombinition(List<string> result, Dictionary<int, List<char>> map, int num, int i)
        {
            List<string> reuslt = new();
            int x = 0;

            foreach (var num2 in map[num])
            {
                if (x == 0)
                {
                    x++;
                    continue;
                }
                foreach (var item in result)
                {
                    var newL = item.ToCharArray();
                    newL[i] = num2;
                    reuslt.Add(new string(newL));
                }
            }

            return reuslt;
        }

        private List<int> BreakDownNumber(int number)
        {
            List<int> result = new();
            int val = number;
            while (val > 0)
            {
                var res = val % 10;
                val = val / 10;
                result.Add(res);
            }

            result.Reverse();

            return result;
        }
    }
}
