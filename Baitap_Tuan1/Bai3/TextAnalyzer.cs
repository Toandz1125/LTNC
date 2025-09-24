using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bai3
{
    class TextAnalyzer
    {
        public Dictionary<string, int> WordFrequency { get; private set; }

        public void Analyze(string text)
        {
            WordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            string[] words = Regex.Split(text, @"\W+")
                                    .Where(w => !string.IsNullOrWhiteSpace(w))
                                    .ToArray();

            foreach (string word in words)
            {
                if (WordFrequency.ContainsKey(word))
                    WordFrequency[word]++;
                else
                    WordFrequency[word] = 1;
            }
        }

        public int TotalWords => WordFrequency?.Values.Sum() ?? 0;
        public int DistinctWords => WordFrequency?.Keys.Count ?? 0;
    }
}
