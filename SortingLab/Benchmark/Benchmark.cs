using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SortingLab.Interfaces;

namespace SortingLab.Benchmark
{
    public static class Benchmark
    {
        public static double Run(Stream input, Stream output, ISorter<string> sorter, int wordCount)
        {
            const int numberOfRepetitions = 5;
            var text = TextReader.TextReader.GetText(input);
            var words = Regex.Split(text, @"\W+")
                             .Take(wordCount)
                             .Select(word => word.ToLower())
                             .ToArray();

            string[] SortedFunc() => sorter.Sort(words);
            var result = Measure(SortedFunc, numberOfRepetitions);
            var sortedWords = SortedFunc();
            WriteFrequencyDict(output, sortedWords);

            return result;
        }

        private static double Measure(Func<string[]> sortedFunc, int num)
        {
            var stopwatch = new Stopwatch();

            for (var i = 0; i < num; i++)
            {
                stopwatch.Start();
                sortedFunc();
                stopwatch.Stop();
            }

            return stopwatch.Elapsed.TotalMilliseconds / num;
        }

        private static void WriteFrequencyDict(Stream output, IEnumerable<string> sortedWords)
        {
            foreach (var keyValuePair in GetFrequencyDict(sortedWords))
            {
                output.StreamWriteLine($"'{keyValuePair.Key}' : {keyValuePair.Value}");
            }
        }

        private static Dictionary<string, int> GetFrequencyDict(IEnumerable<string> sortedWords)
        {
            var frequencyDictionary = new Dictionary<string, int>();
            foreach (var word in sortedWords)
            {
                if (!frequencyDictionary.ContainsKey(word))
                {
                    frequencyDictionary[word] = 0;
                }
                frequencyDictionary[word]++;
            }
            return frequencyDictionary;
        }
    }
}
