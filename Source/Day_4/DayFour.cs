using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AoC_2025
{
    internal class DayFour
    {

        public static void Run()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/Day_4/input.txt");
            string[] lines = File.ReadAllLines(path);

            int width = lines[0].Length;
            int height = lines.Length;

            int sum = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (lines[y][x] != '@')
                        continue;

                    List<char> adjacentPositions = new List<char>();

                    int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
                    int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

                    for (int i = 0; i < dx.Length; i++)
                    {
                        int newY = y + dy[i];
                        int newX = x + dx[i];

                        if (newY >= 0 && newY < lines.Length &&
                            newX >= 0 && newX < lines[newY].Length)
                        {
                            adjacentPositions.Add(lines[newY][newX]);
                        }
                    }

                    int rolledPaperCount = 0;
                    for (int t = 0; t < adjacentPositions.Count; t++)
                    {
                        if (adjacentPositions[t] == '@')
                        {
                            rolledPaperCount++;
                        }
                    }

                    if (rolledPaperCount < 4)
                        sum++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
