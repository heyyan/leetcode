using System;

namespace leetcode.Blind_75_LeetCode
{
    public class SearchInARotatedArray
    {
        // suppose an array sorted in ascending order is rotated at some pivot unkown to you beforehand
        // ie [0,1,2,3,4,6,7] might be [4,5,6,7,0,1,2]
        // you are given a target value to search. if found in the array return its index. otherwise return -1;
        //you may assume no duplicate exists int eharray
        // you alogorigth's runtime complexity must be in the order of O(logn)
        public void RunSolution()
        {
            var result = GetSearchInARotatedArray(new int[] { 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 } ,5);
            //var result = GETFindMinimumInARotatedSortedArray(new int[] { 1, 2, 3, 4, 5, 6 });
        }

        private int GetSearchInARotatedArray(int[] nums , int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target) return mid;
                if (nums[left] <= nums[mid])
                {
                    // left to right is sorted
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    // mid to right is sorted
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}
