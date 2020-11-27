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

            while (right > middle || left < middle)
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
                }
            }
            if (left - bottom > 1)
            {
                QuickSort(array, bottom, left);
            }
            if (top - right > 1)
            {
                QuickSort(array, right, top);
            }

            return array;
        }
    }
}
