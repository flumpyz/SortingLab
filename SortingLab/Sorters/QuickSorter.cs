using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SortingLab.Interfaces;

namespace SortingLab.Sorters
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable
    {
        public T[] Sort(T[] sequence)
        {
            return QuickSort(sequence, 0, sequence.Length - 1);
        }
        
        private T[] QuickSort(T[] array, int bottom, int top)
        {
            var right = top;
            var left = bottom;
            var middle = (right + left) / 2;

            while (left <= right)
            {
                while (array[left].CompareTo(array[middle]) < 0)
                {
                    left++;
                }
                while (array[right].CompareTo(array[middle]) > 0)
                {
                    right--;
                }
                if (left <= right)
                {
                    (array[left], array[right]) = (array[right], array[left]);
                    left++;
                    right--;
                }
            }
            if (bottom < right)
            {
                QuickSort(array, bottom, right);
            }
            if (top > left)
            {
                QuickSort(array, left, top);
            }

            return array;
        }
    }
}
