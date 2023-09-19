using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class FindMinimumInARotatedSortedArray
    {
        // suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array 
        // nums = [0,1,2,4,5,6,7] might become
        // [4,5,6,7,0,1,2] if it is rotated  4 times
        // [0,1,2,4,5,6,7] if it is rotated 7 times
        public void RunSolution()
        {
            var result = FindMid2(new int[] { 6, 7, 0, 1, 2 });
            //var result = GETFindMinimumInARotatedSortedArray(new int[] { 1, 2, 3, 4, 5, 6 });
        }

        private object GETFindMinimumInARotatedSortedArray(int[] array)
        {
            int l = 0;
            int r = array.Length - 1;
            int m = int.Parse(Math.Floor((decimal)(array.Length / 2)).ToString());

            while (r > l)
            {
                if (array[m] < array[m - 1] && array[m] < array[m + 1])
                {
                    return array[m];
                }
                if (array[m] > array[m + 1])
                {
                    m = m + 1;
                    l = m;
                }
                else if (array[m] > array[m - 1])
                {
                    m = m - 1;
                    r = m;
                }
            }

            return m;
        }

        private int FindMid(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Min(nums[0], nums[1]);
            if (nums[0] < nums[nums.Length - 1]) return nums[0];

            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[mid + 1]) return nums[mid + 1];
                if (nums[mid - 1] > nums[mid]) return nums[mid];
                if (nums[left] < nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return 0;
        }

        private int FindMid2(int[] nums)
        {
            int result = nums[0];
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                if (nums[l] < nums[r])
                {
                    result = Math.Min(result, nums[l]);
                    break;
                }
                int m = (l + r) / 2;
                result = Math.Min(result, nums[m]);
                if (nums[m] >= nums[l])
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
            return result;
        }
    }
}
