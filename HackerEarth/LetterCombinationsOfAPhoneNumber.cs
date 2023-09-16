using System;
using System.Collections.Generic;

namespace leetcode.HackerEarth
{
    public class LetterCombinationsOfAPhoneNumber
    {
        //Letter Combinations of a Phone Number 
        // you are given a string str containg only digits from 2 to 9 (includting 2 and 9). you are also give the following mapping of digits, such as they are on a telephone.
        // return all possible letter combinations that the number could represent. The resultant array must be in ascedning order
        // 1    2       3
        //     abc     def
        // 4    5       6
        //ghi  jkl     mno
        // 7     8      9
        //pqrs  tuv    wxyz

        //input 68
        // output mt mu mv nt nu nv ot ou ov


        public void RunSolution()
        {
            var res = new List<string>();
            var result = GetLetterCombinationsOfAPhoneNumber("68");
        }

        private List<string> GetLetterCombinationsOfAPhoneNumber(string str)
        {
            Dictionary<char, string> numToChar = new Dictionary<char, string>
            {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" }
            };

            List<string> result = new List<string>();
            result.Add("");

            for (int i = 0; i < str.Length; i++)
            {
                while (result[0].Length == i)
                {
                    string temp = result[0];
                    result.RemoveAt(0);
                    string letters = numToChar[str[i]];
                    for (int j = 0; j < letters.Length; j++)
                    {
                        result.Add(temp + letters[j]);
                    }
                }
            }

            return result;

        }
    }
}
