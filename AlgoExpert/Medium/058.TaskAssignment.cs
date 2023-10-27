using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class TaskAssignment
    {
        // input
        // array [1, 3, 5, 3, 1, 4] //duration of lenght of task
        // k =3 // number of worker

        //output
        //[[4,2],[0,5],[3,1]]
        public void RunSolution()
        {
            var r = GetTaskAssignment2(new int[] { 1, 3, 5, 3, 1, 4 }, 3);
        }

        private object GetTaskAssignment(int[] array, int workers)
        {
            Queue<(int, int)> pair = new Queue<(int, int)>();
            var newArray = array.ToArray();
            Array.Sort(newArray);
            int start = 0;
            int end = array.Length - 1;
            while (workers > 0)
            {
                pair.Enqueue((newArray[start], newArray[end]));
                start++;
                end--;
                workers--;
            }
            var result = new List<(int, int)>();
            bool[] visited = new bool[array.Length];
            while (pair.Count > 0)
            {
                int first = 0;
                int second = 0;
                var item = pair.Dequeue();
                for (int i = 0; i < array.Length; i++)
                {
                    if (item.Item1 == array[i] && !visited[i])
                    {
                        first = i;
                        visited[i] = true;
                        break;
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    if (item.Item2 == array[i] && !visited[i])
                    {
                        second = i;
                        visited[i] = true;
                        break;
                    }
                }
                result.Add((first, second));
            }

            return result.ToArray();
        }

        private object GetTaskAssignment2(int[] array, int workers)
        {
            List<(int, int)> pair = new();
            var sortedTasks = array.ToArray();
            Array.Sort(sortedTasks);
            var taskDurationToIndices = GetTaskDurationsToIndicies(array);

            for (int i = 0; i < workers; i++)
            {
                int task1Duration = sortedTasks[i];
                var indiciesWithTaskDuration = taskDurationToIndices[task1Duration];
                int task1Index = indiciesWithTaskDuration[indiciesWithTaskDuration.Count - 1];
                indiciesWithTaskDuration.RemoveAt(indiciesWithTaskDuration.Count - 1);

                int task2Duration = sortedTasks[sortedTasks.Length - 1 - i];
                var indiciesWithTask2Duration = taskDurationToIndices[task2Duration];
                int task2Index = indiciesWithTask2Duration[indiciesWithTask2Duration.Count - 1];
                indiciesWithTask2Duration.RemoveAt(indiciesWithTask2Duration.Count - 1);

                pair.Add((task1Index, task2Index));
            }
            return pair.ToArray();
        }

        private Dictionary<int, List<int>> GetTaskDurationsToIndicies(int[] array)
        {
            Dictionary<int, List<int>> taskDurations = new Dictionary<int, List<int>>();

            for (int i = 0; i < array.Length; i++)
            {
                if (taskDurations.ContainsKey(array[i]))
                {
                    taskDurations[array[i]].Add(i);
                }
                else
                {
                    var list = new List<int>() { i };
                    taskDurations.Add(array[i], list);
                }
            }

            return taskDurations;
        }
    }
}
