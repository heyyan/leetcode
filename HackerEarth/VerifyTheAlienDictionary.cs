using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class VerifyTheAlienDictionary
    {
        // you are given a string key that contains the 26 English alphabets, jumbled in some order
        // you are also given n words stord in an array str
        // check if hte wordsin the str are sorted lexicographically according to string key
        // input  HECABDFGIJKLMNOPQRSTUVWXYZ
        // 3
        // HACKER
        // EARTHS
        // CODEEXPLAINED
        //output 1

        public void RunSolution()
        {
           // var result = GetVerifyTheAlienDictionary(new List<string> { "HACKER", "EARTHS", "CODEEXPLAINED" }, "HECABDFGIJKLMNOPQRSTUVWXYZ");
            var result = GetVerifyTheAlienDictionary(new List<string> { "HACKER", "HACKER", "HACKERED" }, "HECABDFGIJKLMNOPQRSTUVWXYZ");

        }

        private bool GetVerifyTheAlienDictionary(List<string> words, string order)
        {
            Dictionary<char, int> orderInd = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                orderInd.Add(order[i], i);
            }
            for (int i = 0; i < words.Count - 1; i++)
            {
                string w1 = words[i];
                string w2 = words[i + 1];

                for (int j = 0; j< Math.Min(w1.Length, w2.Length);j++)
                {
                    if (w1[j] != w2[j])
                    {
                        if (orderInd[w1[j]] > orderInd[w2[j]])
                        {
                            return false;
                        }
                        break;
                    }
                }
            }

            return true;
        }
    }
}
