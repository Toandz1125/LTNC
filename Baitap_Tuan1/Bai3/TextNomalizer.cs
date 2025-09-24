using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bai3
{

    class TextNormalizer
    {
        public string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Remove extra spaces
            string temp = Regex.Replace(input, @"\s+", " ").Trim();

            // Capitalize the first letter of each sentence
            string[] sentences = Regex.Split(temp, @"(?<=[.!?])\s+");
            for (int i = 0; i < sentences.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(sentences[i]))
                {
                    sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
                }
            }
            return string.Join(" ", sentences);
        }
    }
}
