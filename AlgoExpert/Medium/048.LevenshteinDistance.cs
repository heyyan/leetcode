using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class LevenshteinDistance
    {
        // input "abc","yabd"
        // output 2 
        public void RunSolution()
        {
            var rest = LevenshteinDistance3(" abc", " yabd");
        }

        private int levenshteinDistance(string str1, string str2)
        {
            // var Ee = new int[str1.Length, str2.Length]();
            //var E = new int[,]{ {0,0,0,0,0 },
            //                    {0,0,0,0,0 },
            //                    {0,0,0,0,0 },
            //                    {0,0,0,0,0 } };

            var E = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                E[i, 0] = i;
            }
            for (int i = 0; i <= str2.Length; i++)
            {
                E[0, i] = i;
            }

            for (int r = 1; r <= str1.Length; r++)
            {
                for (int c = 1; c <= str2.Length; c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        E[r, c] = E[r - 1, c - 1];
                    }
                    else
                    {
                        E[r, c] = 1 + Math.Min(E[r, c - 1], Math.Min(E[r - 1, c], E[r - 1, c - 1]));
                    }
                }
            }

            return E[str1.Length, str2.Length];
        }


        private int levenshteinDistance2(string str1, string str2)
        {
            var small = str1.Length < str2.Length ? str1 : str2;
            var big = str1.Length >= str2.Length ? str1 : str2;

            var evenEdits = new int[small.Length + 1];
            for (int i = 0; i <= small.Length; i++)
            {
                evenEdits[i] = i;
            }

            var oddEdit = new int[small.Length + 1];
            var currentEdits = oddEdit;
            var previousEdits = oddEdit;

            for (int i = 1; i < big.Length + 1; i++)
            {
                if (i % 2 == 1)
                {
                    currentEdits = oddEdit;
                    previousEdits = evenEdits;
                }
                else
                {
                    currentEdits = evenEdits;
                    previousEdits = oddEdit;
                }
                currentEdits[0] = i;

                for (int j = 1; j < small.Length + 1; j++)
                {
                    if (big[i - 1] == small[j - 1])
                    {
                        currentEdits[j] = previousEdits[j - 1];
                    }
                    else
                    {
                        currentEdits[j] = 1 + Math.Min(previousEdits[j - 1], Math.Min(previousEdits[j ], currentEdits[j - 1]));
                    }
                    
                }
            }

            if(big.Length %2 == 0)
            {
                return evenEdits[evenEdits.Length - 1] ;
            }
            else
            {
                return oddEdit[oddEdit.Length - 1] ;
            }
        }

        public static int LevenshteinDistance3(string str1, string str2)
        {
            string small = str1.Length < str2.Length ? str1 : str2;
            string big = str1.Length >= str2.Length ? str1 : str2;

            int[] evenEdits = new int[small.Length + 1];
            int[] oddEdits = new int[small.Length + 1];

            for (int i = 0; i <= small.Length; i++)
            {
                evenEdits[i] = i;
            }

            for (int i = 1; i <= big.Length; i++)
            {
                int[] currentEdits;
                int[] previousEdits;

                if (i % 2 == 1)
                {
                    currentEdits = oddEdits;
                    previousEdits = evenEdits;
                }
                else
                {
                    currentEdits = evenEdits;
                    previousEdits = oddEdits;
                }

                currentEdits[0] = i;

                for (int j = 1; j <= small.Length; j++)
                {
                    if (big[i - 1] == small[j - 1])
                    {
                        currentEdits[j] = previousEdits[j - 1];
                    }
                    else
                    {
                        currentEdits[j] = 1 + Math.Min(previousEdits[j - 1], Math.Min(previousEdits[j], currentEdits[j - 1]));
                    }
                }
            }

            return (big.Length % 2 == 0) ? evenEdits[small.Length] : oddEdits[small.Length];
        }

    }
}
