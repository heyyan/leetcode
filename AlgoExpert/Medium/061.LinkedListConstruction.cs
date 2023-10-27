using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class LinkedListConstruction
    {
        public void RunSolution()
        {
            MinHeap heap = new MinHeap(new int[] { 8, 12, 23, 17, 31, 30, 44, 102, 18 });
            var r = heap.Heap;
        }
    }
}
