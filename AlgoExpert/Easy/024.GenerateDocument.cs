using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class GenerateDocument
    {
        //input BSte!hetsi OgEAxpelrt x 
        // output AlgoExpert is the best!
        public void RunSolution()
        {
            var r = GetGenerateDocument("Bste!hetsi ogEAxpelrt x ", "AlgoExpert is the Best!");
        }

        private bool GetGenerateDocument(string chars, string doc)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in chars)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c] + 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            foreach (char c in doc)
            {
                if (!dict.ContainsKey(c))
                { 
                    return false; }

                if(dict.ContainsKey(c))
                {
                    if (dict[c] == 0)
                    {
                        return false;
                    }
                    dict[c] = dict[c] - 1;
                }
            }
            return true;

        }
        //private bool GetGenerateDocument2(string chars, string doc)
        //{
        //    var one = chars.ToArray();
        //    var two = doc.ToArray();
        //    Array.Sort(one);
        //    Array.Sort(two);
        //    return one == two;

        //}

        }
}
