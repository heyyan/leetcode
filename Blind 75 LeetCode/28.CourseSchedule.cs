using leetcode.AlgoExpert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class CourseSchedule
    {
        // There are a total of numCourses courses you have to take, labeled form 0 to numCoursers-1
        // Some courses may have prerequsites, for example to take course 0 you have to first take course 1
        // which is expressed as a pair. [0,1]
        // Given the total number of courses and a list of prerequsite pairs, is it possible for you to finish all course
        // Input numCourse = 2, prerequisites [[1,0]]
        //output true
        // explanation There are a total of 2 courses to take. To take course 1 you have to finish course 0. so it is possiable
        // Input numCourse = 2, prerequisites [[1,0],[0,1]]
        //output false
        // Input numCourse = 2, prerequisites [[0,1],[0,2],[1,3],[1,4],[3,4]]
        //output false
        public void RunSolution()
        {
            //var result = GetCourseSchedule(5, new List<List<int>> {
            //    new List<int> { 0, 1 },
            //    new List<int> { 0, 2 },
            //    new List<int> { 1,3 },
            //    new List<int> { 1,4 },
            //    new List<int> { 3,4 }
            //});

            var r = CanFinish(5, new int[][] { 
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 1,3 },
                new int[] { 1,4 },
                new int[] { 3,4 }
            });
        }

        private bool GetCourseSchedule(int numCourse, List<List<int>> prerequisites)
        {
            Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourse; i++)
            {
                preMap.Add(i, new List<int>());
            }
            foreach (var pre in prerequisites)
            {
                preMap[pre[0]].Add(pre[1]);
            }
            List<int> visistSet = new List<int>();

            //DFS
            bool DFS(int crs)
            {
                if (visistSet.Contains(crs))
                {
                    return false;
                }
                if (preMap[crs].Count <= 0)
                {
                    return true;
                }
                visistSet.Add(crs);

                foreach (var pre in preMap[crs])
                {
                    if (DFS(pre) == false)
                    {
                        return false;
                    }
                }
                visistSet.Remove(crs);
                preMap[crs].Clear();
                return true;
            }

            for (int i = 0; i < numCourse; i++)
            {
                if (DFS(i) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<List<int>> adj = new List<List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(new List<int>());
            }

            foreach (int[] edge in prerequisites)
            {
                adj[edge[1]].Add(edge[0]);
            }

            int[] indegree = new int[numCourses];
            foreach (int[] edge in prerequisites)
            {
                indegree[edge[0]]++;
            }

            int enrolled = 0;
            Queue<int> queue = new Queue<int>();
            for (int node = 0; node < indegree.Length; node++)
            {
                if (indegree[node] == 0)
                {
                    queue.Enqueue(node);
                    enrolled++;
                }
            }

            while (queue.Count > 0)
            {
                int currNode = queue.Dequeue(); // current course
                foreach (int neighbor in adj[currNode])
                {
                    indegree[neighbor]--;
                    if (indegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                        enrolled++;
                    }
                }
            }

            return (numCourses == enrolled);
        }

    }
}
