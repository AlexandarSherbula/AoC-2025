using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace AoC_2025
{
    internal class DayOne
    {
        public static void Run()
        {
            int arrowPosition = 50;

            int zeroCount = 0;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/DayOne/input.txt");
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, @"\d+");
                int prevArrowPosition = arrowPosition;
                if (match.Success)
                {
                    int parsedNumber = int.Parse(match.Value);
                    if (line.Contains('L'))
                    {
                        for (int i = 0; i < parsedNumber; i++)
                        {
                            arrowPosition--;
                            if (arrowPosition == 0)
                            {
                                zeroCount++;
                            }

                            if (arrowPosition < 0)
                            {
                                arrowPosition += 100;
                            }
                        }
                    }
                    else if (line.Contains('R'))
                    {
                        for (int i = 0; i < parsedNumber; i++)
                        {
                            arrowPosition++;
                            if (arrowPosition == 100)
                            {
                                arrowPosition -= 100;
                                zeroCount++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(zeroCount);

        }
    }
}
