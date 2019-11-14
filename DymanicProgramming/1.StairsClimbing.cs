using System;

namespace leetcode
{
    public class StairsClimbing
    {
        // you can climb 1 or 2 stairs with one step. How many different ways can you climb n stairs?

        public void RunClimbTest()
        {
            Console.WriteLine($"Number of ways to  => { ClimbRecursive(10)}");
            Console.WriteLine($"Number of ways to  => { ClimbDyanmic2Steps(10)}");
        }

        public int ClimbRecursive(int stairs)
        {
            if (stairs == 1) return 1;
            if (stairs == 2) return 2;
            return ClimbRecursive(stairs - 1) + ClimbRecursive(stairs - 2);
        }

        public int ClimbDyanmic2Steps(int n)
        {
            int[] s = new int[n + 1];
            s[0] = 1;
            s[1] = 1;
            s[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                s[i] = s[i - 1] + s[i - 2];
            }
            return s[n];
        }
        public int ClimbDyanmic3Steps(int n)
        {
            int[] s = new int[n + 1];
            s[0] = 1;
            s[1] = 1;
            s[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                s[i] = s[i - 1] + s[i - 2] + s[i - 3];
            }
            return s[n];
        }
    }
}