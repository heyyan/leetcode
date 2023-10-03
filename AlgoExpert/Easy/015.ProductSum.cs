using System.Collections.Generic;

namespace leetcode.AlgoExpert.Easy
{
    public class ProductSum
    {
        // input [5,2, [7,-1], 3,[6,[-13,8],4]]
        // output 12
        public void RunSolution()
        {
            List<object> arr = new List<object> { 5, 2, new List<object> { 7, -1 }, 3, new List<object> { 6, new List<object> { -13, 8 }, 4 } };
            var r = GetProductSum(arr, 0);
        }

        private int GetProductSum(List<object> arr, int depth)
        {
            int result = 0;
            foreach (var item in arr)
            {
                if (item is List<object>)
                {
                    var ret = GetProductSum((List<object>)item, depth + 1);
                    result += ret;
                }
                else
                {
                    result += (int)item;
                }
            }
            if (depth > 0)
            {
                result *= depth;
            }
            return result;
        }

        private int GetProductSum2(List<object> array, int mulitplier = 1)
        {
            int sum = 0;
            foreach (var item in array)
            {
                if (item is List<object>)
                {
                    sum += GetProductSum((List<object>)item, mulitplier + 1);
                }
                else
                {
                    sum += (int)item;
                }
            }
            return sum *= mulitplier;
        }
    }
}
