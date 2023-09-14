namespace leetcode.HackerEarth
{
    public class NextPermutation
    {
        // you are given an array arr consisting of digits for instance,
        // [1,2,3,4]
        // this array represents the number 1234 (One Thousand Two Hundred and Thirty Four)
        // Find the next greatest number that can be formed using these digits. Update the array in place
        // in this case the result will
        // [1,2,3,4] (One thousand Two hundred and Fourty three)
        // if the number is already at its greated prossible value,then reutn the least value instteds
        public void RunSolution()
        {
            int[] array = { 3, 4, 2, 1 };
            //int[] input = { 4, 1, 1, 1, 0, 9 };
            var result = GetNextPermutation(array);
        }

        private int[] GetNextPermutation(int[] array)
        {
            int pivot = -1;
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    pivot = i - 1; break;
                }
            }

            if (pivot != -1)
            {
                int max = 1000000;
                int max_pos = -1;
                for (int i = pivot + 1; i < array.Length; i++)
                {
                    if (array[i] > array[pivot] && array[i] <= max)
                    {
                        max_pos = i;
                        max = array[i];
                    }
                }

                var temp = array[pivot];
                array[pivot] = max;
                array[max_pos] = temp;
            }

            var j = pivot + 1;
            while (j < (pivot + 1) + (array.Length - (pivot + 1)) / 2)
            {
                var temp = array[j];
                array[j] = array[array.Length - 1 - (j - (pivot + 1))];
                array[array.Length - 1 - (j - (pivot + 1))] = temp;
                j++;
            }
            return array;
        }
    }
}
