using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC_2025
{
    internal class DayThree
    {
        public static void Run()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/Day_3/input.txt");

            int sumJolt = 0;
            foreach (string line in File.ReadAllLines(path))
            {
                string newLine = line;
                int highestJolt = line.Max();
                int highestJoltIndex = line.IndexOf((char)highestJolt);

                int result = int.Parse(line.Max().ToString());
                int secondHighestJolt;
                int secondHighestJoltIndex;
                if (highestJoltIndex == line.Length - 1)
                {
                    newLine = line.Remove(highestJoltIndex, 1);
                    secondHighestJolt = newLine.Max();
                    secondHighestJoltIndex = line.IndexOf((char)secondHighestJolt);
                }
                else
                {
                    newLine = line.Substring(highestJoltIndex + 1);
                    secondHighestJolt = newLine.Max();
                    secondHighestJoltIndex = line.IndexOf((char)secondHighestJolt) + (highestJoltIndex + 1);
                }
                
                int maximumJolt = 0;
                if (highestJoltIndex <= secondHighestJoltIndex)
                {
                    maximumJolt = (highestJolt - 48) * 10 + (secondHighestJolt - 48);
                }
                else
                {
                    maximumJolt = (secondHighestJolt - 48) * 10 + (highestJolt - 48);
                }
                sumJolt += maximumJolt;
            }
            Console.WriteLine(sumJolt);
        }
    }
}
