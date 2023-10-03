using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class RunLengthEncoding
    {
        //input AAAAAAAAAAAAABBCCCCDD
        // output 9A4A2B4C2D
        public void RunSolution()
        {
            var r = GetRunLengthEncoding2("AAAAAAAAAAAAABBCCCCDD");
        }

        private string GetRunLengthEncoding(string str)
        {
            string output = "";
            List<char> charList = new List<char>();
            foreach (char c in str)
            {
                if (charList.Count == 9 || (charList.Count > 0 && c != charList[0]))
                {
                    output += charList.Count + "" + charList[0];
                    charList = new List<char> { c };
                }
                else
                {
                    charList.Add(c);
                }
            }
            if (charList.Count > 0)
            {
                output += charList.Count + "" + charList[0];
            }
            return output;
        }


        private string GetRunLengthEncoding2(string str)
        {
            List<string> encodedStringCharacters = new List<string>();
            int currentRunlength = 1;
            for (int i = 1; i < str.Length; i++)
            {
                char currentCharacter = str[i];
                char previousCharacter = str[i - 1];

                if (currentCharacter != previousCharacter || currentRunlength == 9)
                {
                    encodedStringCharacters.Add(currentRunlength.ToString());
                    encodedStringCharacters.Add(previousCharacter.ToString());
                    currentRunlength = 0;
                }
                currentRunlength++;
            }
            encodedStringCharacters.Add(currentRunlength.ToString());
            encodedStringCharacters.Add(str[str.Length - 1].ToString());

            return string.Join("", encodedStringCharacters);
        }
    }
}
