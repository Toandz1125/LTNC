using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class TextPrinter
    {
        public void PrintResults(string normalizedText, TextAnalyzer analyzer)
        {
            Console.WriteLine("\n--- Normalized Text ---");
            Console.WriteLine(normalizedText);

            Console.WriteLine($"\nTotal words: {analyzer.TotalWords}");
            Console.WriteLine($"Distinct words: {analyzer.DistinctWords}");

            Console.WriteLine("\n--- Word Frequency ---");
            foreach (var pair in analyzer.WordFrequency.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
