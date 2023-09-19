using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class ThreeSum
    {
        // Given an array of n intgers, are three elemetsn a,b,c in nums such that a + b + c =0? Find all uniqure triplets in the array 
        // which gives the sum of zero
        // input [-1,0,1,2,-1,4]
        // output { [-1,0,1], [-1,-1,2] }
        public void RunSolution()
        {
            var result = GETThreeSum2(new int[] { -1, 0, 1, 2, -1, 4 });
            // var result = GETThreeSum(new int[] { -3,3,4,-3,1,2 });
        }

        private int[] GETThreeSum(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                int a = nums[i];
                if (i > 0 && a == nums[i - 1])
                {
                    continue;
                }
                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r)
                {
                    int threeSum = a + nums[l] + nums[r];
                    if (threeSum > 0)
                    {
                        r--;
                    }
                    else if (threeSum < 0)
                    {
                        l++;
                    }
                    else
                    {
                        list.Add(new List<int>() { a, nums[l], nums[r] });
                        l++;
                        while (nums[l] == nums[l - 1] && l < r)
                        {
                            l++;
                        }
                    }
                }
            }
            return list[0].ToArray();
        }

        private int[] GETThreeSum2(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int low = i + 1;
                    int high = nums.Length - 1;
                    int sum = 0 - nums[i];
                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            list.Add(new List<int>() { nums[i], nums[low], nums[high] });

                            while (low < high && nums[low] == nums[low + 1])
                            {
                                low++;
                            }
                            while (low < high && nums[high] == nums[high - 1])
                            {
                                high--;
                            }
                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] > sum)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }
            }
            return list[0].ToArray();
        }
    }
}
