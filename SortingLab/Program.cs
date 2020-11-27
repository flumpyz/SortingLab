using System;
using SortingLab.Sorters;

namespace SortingLab
{
    static class Program
    {
        private static void Main()
        {
            var bubbleSorter = new BubbleSorter<int>();
            var quickSorter = new QuickSorter<int>();
            var array = new int[] {1, 3, 4, 2, 5, 6, 8};

            array = quickSorter.Sort(array);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
