using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MinMaxStackConstruction
    {
        public void RunSolution()
        {
            var mmstack = new MinMaxStack();
            mmstack.Push(5);
            int min = mmstack.getMin();
            int max = mmstack.getMax();
            mmstack.Push(7);
            min = mmstack.getMin();
            max = mmstack.getMax();
            mmstack.Push(2);
            min = mmstack.getMin();
            max = mmstack.getMax();
            var s = mmstack.Peek();
            mmstack.Pop();
            min = mmstack.getMin();
            max = mmstack.getMax();
            mmstack.Pop();
            min = mmstack.getMin();
            max = mmstack.getMax();
            mmstack.Pop();
            min = mmstack.getMin();
            max = mmstack.getMax();
        }
    }

    internal class MinMaxStack
    {
        private (int, int)[] minMax;
        private int[] stack;
        private int size;
        private int capacity;

        public MinMaxStack(int capacity = 10)
        {
            this.capacity = capacity;
            stack = new int[capacity];
            minMax = new (int, int)[capacity];
            size = 0;
        }

        public int Peek()
        {
            if (size == 0)
            {
                return -1;
            }
            return stack[size - 1];
        }

        public int Pop()
        {
            if (size > 0)
            {
                int val = stack[size - 1];
                stack[size - 1] = -1;
                minMax[size - 1] = (-1, -1);
                size--;
                return val;
            }
            return -1;
        }

        public void Push(int value)
        {
            if (size == 0)
            {
                stack[size] = value;
                minMax[size] = (value, value);
                size++;
                return;
            }
            EnsureCapacity();
            int min = minMax[size - 1].Item1;
            int max = minMax[size - 1].Item2;

            min = Math.Min(min, value);
            max = Math.Max(max, value);
            
            stack[size] = value;
            minMax[size] = (min, max);
            size++;
        }

        public int getMin()
        {
            if (size == 0)
            {
                return -1;
            }
            return minMax[size - 1].Item1;
        }

        public int getMax()
        {
            if (size == 0)
            {
                return -1;
            }
            return minMax[size - 1].Item2;
        }
        private void EnsureCapacity()
        {
            if (size == capacity)
            {
                capacity *= 2;
                Array.Resize(ref stack, capacity);
                Array.Resize(ref minMax, capacity);
            }
        }
    }
}
