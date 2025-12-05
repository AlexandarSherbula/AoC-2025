using System;
using System.Collections.Generic;
using System.Text;

namespace AoC_2025
{
    internal class DayFive
    {

        public static void Run()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/Day_5/input.txt");
            var ranges = new List<string>();
            var ingredientsID = new List<string>();

            bool secondBlock = false;

            foreach (var line in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    secondBlock = true;
                    continue;
                }

                if (!secondBlock)
                    ranges.Add(line);
                else
                    ingredientsID.Add(line);
            }

            int freshIngredientsCount = 0;
            foreach (var ingredient in ingredientsID)
            {
                foreach(var range in ranges)
                {
                    long id = long.Parse(ingredient);
                    var parts = range.Split('-');
                    long start = long.Parse(parts[0]);
                    long end = long.Parse(parts[1]);

                    if (id >= start && id <= end)
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
