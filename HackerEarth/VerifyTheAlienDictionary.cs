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
            var result = GetVerifyTheAlienDictionary("HECABDFGIJKLMNOPQRSTUVWXYZ", "HACKER");

        }

        private bool GetVerifyTheAlienDictionary(string key, string str)
        {
            Dictionary<char,int> hm = new Dictionary<char,int>();
            for (int i = 0; i < key.Length; i++) 
            {
                hm.Add(key[i], i);
            }

            return true;
        }
    }
}
