using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class CaesrCipherEncryptor
    {
        //input xyz key 2
        // output zab
        public void RunSolution()
        {
            var r = GetCaesrCipherEncryptor("xyz", 54);
        }

        private string GetCaesrCipherEncryptor(string str, int key)
        {
            key = key % 26;
            string result = "";
            foreach (char c in str)
            {
                int ext = Convert.ToInt32(c) + key;

                if (ext > 122)
                {
                    int s = 96 - (122 - ext);
                    result += Convert.ToChar(s);
                }
                else
                {
                    result += Convert.ToChar(ext);
                }
            }
            return result;
        }

        private string GetCaesrCipherEncryptor2(string str, int key)
        {
            key = key % 26;
            string result = "";
            foreach (char c in str)
            {
                int nLc = Convert.ToInt32(c) + key;

                if (nLc > 122)
                {
                    int s = 96 + (nLc % 122);
                    result += Convert.ToChar(s);
                }
                else
                {
                    result += Convert.ToChar(nLc);
                }
            }
            return result;
        }
    }
}
