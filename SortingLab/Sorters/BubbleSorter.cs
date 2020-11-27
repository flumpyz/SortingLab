using System;
using System.Collections.Generic;
using SortingLab.Interfaces;

namespace SortingLab.Sorters
{
    public class BubbleSorter<T> : ISorter<T> where T : IComparable
    {
        public T[] Sort(T[] sequence)
        {
            for (var i = 0; i < sequence.Length - 1; i++)
            {
                for (var j = 0; j < sequence.Length - 1; j++)
                {
                    if (sequence[j].CompareTo(sequence[j + 1]) > 0)
                    {
                        (sequence[j], sequence[j + 1]) = (sequence[j + 1], sequence[j]);
                    }
                }
            }

            return sequence;
        }
    }
}
