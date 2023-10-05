using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SpiralTraverse
    {
        //input |1, 2, 3, 4|
        //      |12,13,14,5|
        //      |11,16,15,6|
        //      |10,9,8,7  |
        // output [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16]
        public void RunSolution()
        {
            var r = GetSpiralTraverseRec(new int[,] { { 1, 2, 3, 4, },
                                                   { 12,13,14,5  },
                                                   { 11,16,15,6 },
                                                   { 10,9,8,7 } });
        }

        private int[] GetSpiralTraverseRec(int[,] array)
        {
            List<int> list = new List<int>();
            int sC = 0;
            int sR = 0;
            int eC = array.GetLength(0) - 1;
            int eR = array.GetLength(1) - 1;
            SprialFill(array, sC, eC, sR, eR, list);
            return list.ToArray();
        }

        private void SprialFill(int[,] array, int sC, int eC, int sR, int eR, List<int> list)
        {
            if (sC > eR || sR > eR)
            {
                return;
            }
            for (int i = sC; i <= eC; i++)
            {
                list.Add(array[sC, i]);
            }

            for (int i = sR + 1; i <= eR; i++)
            {
                list.Add(array[i, eC]);
            }

            for (int i = eC - 1; i >= sC; i--)
            {
                list.Add(array[eR, i]);
            }

            for (int i = eR - 1; i > sR; i--)
            {
                list.Add(array[i, sC]);
            }

            sC++;
            sR++;
            eR--;
            eC--;
            SprialFill(array, sC, eC, sR, eR, list);
        }

        private int[] GetSpiralTraverse(int[,] array)
        {
            List<int> list = new List<int>();
            int sC = 0;
            int sR = 0;
            int eC = array.GetLength(0) - 1;
            int eR = array.GetLength(1) - 1;
            while (sC <= eC && sR <= eR)
            {
                for (int i = sC; i <= eC; i++)
                {
                    list.Add(array[sC, i]);
                }

                for (int i = sR + 1; i <= eR; i++)
                {
                    list.Add(array[i, eC]);
                }

                for (int i = eC - 1; i >= sC; i--)
                {
                    list.Add(array[eR, i]);
                }

                for (int i = eR - 1; i > sR; i--)
                {
                    list.Add(array[i, sC]);
                }

                sC++;
                sR++;
                eR--;
                eC--;
            }
            return list.ToArray();
        }
        private int[] GetSpiralTraverseFail(int[,] array)
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            //for (int i = 0; i < array.GetLength(0); i++)
            //{
            //    for(int j = 0; j < array.GetLength(1); j++)
            //    {
            //        list.Add(array[i,j]);
            //    }
            //}

            int sC = 0;
            int sR = 0;
            int eC = array.GetLength(0) - 1;
            int eR = array.GetLength(1) - 1;
            while (list.Count < array.GetLength(0) * array.GetLength(1))
            {
                string key = $"{sR},{sC}";
                if (!list.ContainsKey(key))
                {
                    list.Add(key, array[sR, sC]);
                }

                if (sR != eR && sC < eC)
                {
                    sC++;
                    continue;
                }

                if (sC == eC && sR < eR)
                {
                    sR++;
                    continue;
                }

                if (sR == eR && sC > 0)
                {
                    sC--;
                    continue;
                }

                if (eR - 1 < sR && sC != eC)
                {
                    sR--;
                    continue;
                }
                sC++;
                sR++;
                eC--;
                eR--;
            }
            //int i = 0;
            //int j = 0;
            //int x = 1;
            //int y = 1;
            //while (list.Count < array.GetLength(0) * array.GetLength(1))
            //{
            //    list.Add(array[i, j]);
            //    if (j < array.GetLength(1) - y && i == 0)
            //    {
            //        j++;
            //        continue;
            //    }
            //    if (j == array.GetLength(1) - y && i < array.GetLength(0) - x)
            //    {
            //        i++;
            //        continue;

            //    }
            //    if (j > 0 && i == array.GetLength(0) - x)
            //    {
            //        j--;
            //        continue;

            //    }

            //    if (i > 0 + x && j == 0)
            //    {
            //        i--;
            //        continue;

            //    }
            //    x++;
            //    y++;
            //}
            return list.Values.ToArray();
        }
    }
}
