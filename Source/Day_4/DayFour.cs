using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace AoC_2025
{
    internal class DayFour
    {
        static void ReplaceChar(string[] lines, int y, int x, char newChar)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            if (y < 0 || y >= lines.Length) throw new ArgumentOutOfRangeException(nameof(y));
            if (x < 0 || x >= lines[y].Length) throw new ArgumentOutOfRangeException(nameof(x));

            // Convert to char array, modify, rebuild string
            char[] chars = lines[y].ToCharArray();
            chars[x] = newChar;
            lines[y] = new string(chars);
        }


        public static void Run()
        {
            Stopwatch sw = Stopwatch.StartNew();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/Day_4/input.txt");
            string[] lines = File.ReadAllLines(path);

            int width = lines[0].Length;
            int height = lines.Length;

            List<int> removedRollPapersIndex = new List<int>();

            int sum = 0;
            int sumPerState;

            do
            {
                sumPerState = 0;
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
                        {
                            sumPerState++;
                            removedRollPapersIndex.Add(y * width + x);
                        }
                    }
                }

                sum += sumPerState;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int t = 0; t < removedRollPapersIndex.Count; t++)
                        {
                            if (y * width + x == removedRollPapersIndex[t])
                                ReplaceChar(lines, y, x, 'x');
                        }
                    }
                }

                removedRollPapersIndex.Clear();
            } while (sumPerState != 0);

            Console.WriteLine(sum);
        }
    }
}
