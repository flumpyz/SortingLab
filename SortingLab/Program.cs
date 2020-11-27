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
            var array = new int[] {1, 3, 4, 7, 2, 5, 6, 8, 9, 71, 92, 10, 15, 12, 100, 150, 201, 190, 147, 21, 14, 76};
            

            array = quickSorter.Sort(array);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
