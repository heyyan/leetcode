using System.Linq;

namespace leetcode.HackerEarth
{
    public class StuffThenCandiesIn
    {
        // you are given an array of candies where candies[i] define how many candies the i-th kid has. you are also given
        // and integer, extra_candies, which can be distributed among the kids
        // for each kid, check if there is a way to distribute extra_candy such that the kid has maximum number of candies. 
        // Multiple kids can have maximum candies

        // input 5
        // 2 3 5 1 3
        // 3

        // output 
        // 1 1 1 0 1

        public void RunSolution()
        {
            var result = GETStuffThenCandiesIn(new int[] { 2, 3, 5, 1, 3 }, 3);
        }

        private int[] GETStuffThenCandiesIn(int[] arr, int extra)
        {
            int max = arr.Max();
            int[] result = new int[max];    
            for (int i = 0;i< arr.Length;i++)
            {
                result[i]= (arr[i] + extra) >= max ? 1: 0;
            }
            return result;
        }
    }
}
