namespace leetcode.HackerEarth
{
    public class JumpGame
    {
        // you are given an array arr. you start form index 0, and the element at each index denotes,
        // the maximun distance you can jump from that index. For instance, in the following example:
        // 3 1 2 1 7
        // if you start form index 0, the element at arr[0][3] indicates that the maximum index you can 
        // jump to is 3
        // if it is possible to reach the last index print 1. if not print 0
        public void RunSolution()
        {
            int[] input = { 1, 2, 5, 6, 7 };
            //int[] input = { 4, 1, 1, 1, 0, 9 };
            var result = NoOfJumps(input);
        }

        private int NoOfJumps(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length ; i++)
            {
                if(i > max)
                {
                    return 0;
                }
                if(max < i + arr[i])
                {
                    max = i + arr[i];
                }
            }
            return 1;
        }
    }
}
