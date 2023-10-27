using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MinHeapConstruction
    {
        // Min Heap 
        // Build heap
        // sift down
        // sift up
        // insert 
        // remove
        // input
        // distance [8,12,23,17,31,30,44,102,18] //duration of lenght of task
        // fuel [1,2,1,0,3]
        // mpg = 10

        // output
        // 4
        public void RunSolution()
        {
            MinHeap heap = new MinHeap(new int[] { 8, 12, 23, 17, 31, 30, 44, 102, 18 });
            var r = heap.Heap;
        }


    }

    public class MinHeap
    {
        public MinHeap(int[] array)
        {
            Heap = BuildHeap(array);
            Length = Heap.Length;
        }
        public int Length { get; set; }
        public int[] Heap { get; set; }

        public int[] BuildHeap(int[] array)
        {
            int firstParentIdx = (array.Length - 2) / 2;
            for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
            {
                SiftDown(currentIdx, array.Length - 1, array);
            }
            return array;
        }

        public void SiftDown(int currentIdx, int endIdx, int[] heap)
        {
            int childOneIdx = currentIdx * 2 + 1;
            while (childOneIdx <= endIdx)
            {
                int childTwoIdx;
                if (currentIdx * 2 + 2 <= endIdx)
                {
                    childTwoIdx = currentIdx * 2 + 2;
                }
                else
                {
                    childTwoIdx = -1;
                }

                int idxToSwap;
                if (childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx])
                {
                    idxToSwap = childTwoIdx;
                }
                else
                {
                    idxToSwap = childOneIdx;
                }

                if (heap[idxToSwap] < heap[currentIdx])
                {
                    Swap(currentIdx, idxToSwap, heap);
                    currentIdx = idxToSwap;
                    childOneIdx = currentIdx * 2 + 1;
                }
                else
                {
                    break;
                }
            }
        }

        public void SiftUp(int currentIdx, int[] heap)
        {
            int parendIdx = (currentIdx - 1) / 2;

            while (currentIdx > 0 && heap[currentIdx] < heap[parendIdx])
            {
                Swap(currentIdx, parendIdx, heap);
                currentIdx = parendIdx;
                parendIdx = (currentIdx - 1) / 2;
            }
        }

        public int Peek()
        {
            return Heap[0];
        }

        public int Remove()
        {
            Swap(0, Heap.Length - 1, Heap);
            int valueToRemove = Heap[Heap.Length - 1];
            // Heap.RemoveAt(Heap.Length - 1);
            SiftDown(0, Heap.Length - 1, Heap);
            return valueToRemove;
        }

        public void Insert(int value)
        {
            // Heap.Add(value);
            SiftUp(Heap.Length - 1, Heap);
        }


        private int GetParent(int idx)
        {
            return (idx - 1) / 2;
        }

        private int GetFirstChild(int idx)
        {
            return idx * 2 + 1;
        }

        private int GetSecondChild(int idx)
        {
            return idx * 2 + 2;
        }

        private void Swap(int i, int j, int[] heap)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }


    public class MinHeap2
    {
        public int Length { get { return Heap.Count; } }
        public List<int> Heap { get; set; }
        public MinHeap2()
        {
            Heap = new List<int>();
        }

        public void Insert(int number)
        {
            Heap.Add(number);
            HeapifyUp(Heap.Count - 1);
        }

        public void Delete()
        {
            if (Heap.Count == 0)
            {
                return;
            }

            if (Heap.Count == 1)
            {
                Heap.RemoveAt(0);
            }
            Swap(0, Heap.Count - 1);
            Heap.RemoveAt(Length - 1);
            HeapifyDown(0);
        }

        private void HeapifyDown(int idx)
        {
            var lIdx = LeftChild(idx);
            var rIdx = RightChild(idx);

            if (lIdx >= Heap.Count || rIdx >= Heap.Count)
            {
                return;
            }

            if (idx >= Heap.Count)
            {
                return;
            }

            var lV = Heap[lIdx];
            var rV = Heap[rIdx];
            var v = Heap[idx];

            if (lV > rV && v > rV)
            {
                Swap(idx, rV);
            }
            else if (rV > lV && v > lV)
            {
                Swap(idx, lV);
            }
        }

        private void HeapifyUp(int idx)
        {
            if (idx <= 0)
            {
                return;
            }

            var p = Parent(idx);
            var parentV = Heap[p];
            var v = Heap[idx];
            if (parentV > v)
            {
                Swap(p, idx);
                HeapifyUp(p);
            }
        }

        //private void HeapifyUp(int idx)
        //{
        //    var parentIdx = Parent(idx);
        //    while(parentIdx > 0)
        //    {
        //        if (Heap[parentIdx] > Heap[idx])
        //        {
        //            Swap(parentIdx, idx);
        //        }
        //        parentIdx = Parent(parentIdx);
        //    }
        //}

        private int Parent(int idx)
        {
            return (idx - 1) / 2;
        }

        private int LeftChild(int idx)
        {
            return 2 * idx + 1;
        }
        private int RightChild(int idx)
        {
            return 2 * idx + 2;
        }

        private void Swap(int idx1, int idx2)
        {
            var temp = Heap[idx1];
            Heap[idx1] = Heap[idx2];
            Heap[idx2] = temp;
        }
    }

    public class MinHeap3
    {
        private int[] heap;
        private int size;
        private int capacity;

        public MinHeap3(int capacity)
        {
            this.capacity = capacity;
            heap = new int[capacity];
            size = 0;
        }

        private int GetParentIndex(int index) => (index - 1) / 2;
        private int GetLeftChildIndex(int index) => 2 * index + 1;
        private int GetRightChildIndex(int index) => 2 * index + 2;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < size;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < size;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;
        private int LeftChild(int index) => heap[GetLeftChildIndex(index)];
        private int RightChild(int index) => heap[GetRightChildIndex(index)];
        private int Parent(int index) => heap[GetParentIndex(index)];

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Heap is Empty");
            }
            return heap[0];
        }

        private void EnsureCapacity()
        {
            if (size == capacity)
            {
                capacity *= 2;
                Array.Resize(ref heap, capacity);
            }
        }

        private void HeapifyUp()
        {
            int index = size - 1;
            while (HasParent(index) && heap[index] < Parent(index))
            {
                int parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
 
                if (heap[index] < heap[smallerChildIndex])
                {
                    break;
                }

                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            int temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }

}
