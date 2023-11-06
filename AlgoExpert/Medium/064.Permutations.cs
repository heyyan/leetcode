using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class Permutations
    {
        public void RunSolution()
        {
            var values = GetPermutations2(new int[] { 1, 2, 3 });
        }

        private List<List<int>> GetPermutations(int[] array)
        {
            var permutations = new List<List<int>>();
            premutationHealper(array.ToList(), new List<int>(), permutations);

            return permutations;
        }

        private void premutationHealper(List<int> array, List<int> currentPermutations, List<List<int>> permutations)
        {
            if (array.Count == 0 && currentPermutations.Count > 0)
            {
                permutations.Add(currentPermutations);
            }
            else
            {
                for (int i = 0; i < array.Count; i++)
                {
                    int exclude = array[i];
                    List<int> newArray = array.Where(x => x != exclude).ToList();
                    var newPermutations = new List<int>();
                    newPermutations.AddRange(currentPermutations);
                    newPermutations.Add(array[i]);
                    premutationHealper(newArray, newPermutations, permutations);
                }

            }
        }

        private List<List<int>> GetPermutations2(int[] array)
        {
            var permutations = new List<List<int>>();
            premutationHealper2(0, array.ToList(), permutations);

            return permutations;
        }

        private void premutationHealper2(int i, List<int> array, List<List<int>> permutations)
        {
            if (i == array.Count - 1)
            {
                permutations.Add(array);
            }
            else
            {
                for (int j = i; j < array.Count; j++)
                {
                    Swap(array, i, j);
                    premutationHealper2(i + 1, array, permutations);
                    Swap(array, i, j);
                }
            }
        }

        private void Swap(List<int> array, int i, int j)
        {
            var temp = array[i]; array[i] = array[j]; array[j] = temp;
        }
    }
}
