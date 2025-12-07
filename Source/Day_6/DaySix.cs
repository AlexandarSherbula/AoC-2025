using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace AoC_2025
{
    internal class DaySix
    {

        public static void Run()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/Day_6/input.txt");
            var lines = File.ReadAllLines(path);

            var tokens = lines
                .Select(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

            int maxCols = tokens.Max(arr => arr.Length);

            List<string> transposedLines = new List<string>();
            for (int col = 0; col < maxCols; col++)
            {
                var columnValues = tokens
                    .Where(arr => col < arr.Length)
                    .Select(arr => arr[col]);

                transposedLines.Add(string.Join(" ", columnValues));
            }

            long sum = 0;
            foreach(var list in transposedLines)
            {
                var parts = list.Split(' ');
                long lineSum = parts[parts.Length - 1] == "*" ? 1 : 0;
                for (int i = 0; i < parts.Length - 1; i++)
                {

                    if (!parts[i].Contains('*') && !parts[i].Contains('+'))
                    {
                        long num = long.Parse(parts[i]);
                        if (parts[parts.Length - 1] == "*")
                        {
                            lineSum *= num;
                        }
                        else if (parts[parts.Length - 1] == "+")
                        {
                            lineSum += num;
                        }
                    }
                }
                sum += lineSum;
            }
            Console.WriteLine(sum);
        }
    }
}
