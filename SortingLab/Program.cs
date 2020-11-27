using System;
using System.Collections.Generic;
using System.IO;
using SortingLab.Sorters;

namespace SortingLab
{
    static class Program
    {
        private static void Main()
        {
            var path = $"C:/Users/{Environment.UserName}/Desktop";
            var counts = new List<int> {100, 500, 1000, 2000, 5000};

            using (var resultFile = new FileStream($"{path}/result.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                foreach (var count in counts)
                {
                    using (var file = new FileStream($"{path}/text.txt", FileMode.Open, FileAccess.Read))
                    {
                        var result = Benchmark.Benchmark.Run(file,
                                                             Console.OpenStandardOutput(),
                                                             new BubbleSorter<string>(), 
                                                             count);
                        resultFile.StreamWriteLine($"{count} : {result}");
                    }
                }
            }
        }
    }
}
