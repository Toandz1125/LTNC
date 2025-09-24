using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Bai3;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Enter text:");
        string input = Console.ReadLine();

        TextNormalizer normalizer = new TextNormalizer();
        string normalizedText = normalizer.Normalize(input);

        TextAnalyzer analyzer = new TextAnalyzer();
        analyzer.Analyze(normalizedText);

        TextPrinter printer = new TextPrinter();
        printer.PrintResults(normalizedText, analyzer);
    }
}
