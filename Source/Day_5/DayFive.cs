using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Text;

namespace AoC_2025
{
    internal class DayFive
    {
        struct Range
        {
            public long start;
            public long end;

            public Range(long start, long end)
            {
                this.start = start;
                this.end = end;
            }
        }

        public static void Run()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/Day_5/input.txt");
            var ranges = new List<Range>();
            var ingredientsID = new List<long>();

            bool firstBlock = true;

            foreach (var line in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    firstBlock = false;
                    continue;
                }

                if (firstBlock)
                {
                    var parts = line.Split('-');
                    long start = long.Parse(parts[0]);
                    long end = long.Parse(parts[1]);
                    ranges.Add(new Range(start, end));
                }
                else
                    ingredientsID.Add(long.Parse(line));
            }

            int freshIngredientsCount = 0;
            foreach (var ingredient in ingredientsID)
            {
                foreach(var range in ranges)
                {                    
                    long start = range.start;
                    long end = range.end;
            
                    if (ingredient >= start && ingredient <= end)
                    {
                        freshIngredientsCount++;
                        break;
                    }
                }
            }
            Console.WriteLine(freshIngredientsCount);
        }
    }
}
