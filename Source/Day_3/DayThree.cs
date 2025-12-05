using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AoC_2025
{
    internal class DayThree
    {
        private static int DigitAt(string s, int index)
        {
            char c = s[index];
            if (c < '0' || c > '9')
                throw new ArgumentException($"Invalid character '{c}' at position {index}. Only digits are allowed.");
            return c - '0';
        }

        private static int MaxBankJoltage(string bank)
        {
            int best = -1;
            int maxPrefixDigit = DigitAt(bank, 0);

            for (int i = 1; i < bank.Length; i++)
            {
                int d = DigitAt(bank, i);
                int candidate = 10 * maxPrefixDigit + d;
                if (candidate > best) best = candidate;

                if (d > maxPrefixDigit) maxPrefixDigit = d;
            }

            return best;
        }

        static string MaxBankJoltage12(string line)
        {
            int k = 12;
            int toRemove = line.Length - k;
            var stack = new List<char>();

            foreach (char c in line)
            {
                while (stack.Count > 0 && toRemove > 0 && stack[stack.Count - 1] < c)
                {
                    stack.RemoveAt(stack.Count - 1);
                    toRemove--;
                }
                stack.Add(c);
            }

            while (stack.Count > k)
                stack.RemoveAt(stack.Count - 1);

            return new string(stack.ToArray());
        }

        public static void Run()
        {
            Stopwatch sw = Stopwatch.StartNew();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Source/Day_3/example.txt");
            string[] lines = File.ReadAllLines(path);

            long sum = 0;
            foreach (string line in lines)
            {
                string maxStr = MaxBankJoltage12(line);
                long max = long.Parse(maxStr);
                sum += max;
            }
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds + " ms");
            Console.WriteLine(sum);
        }
    }
}
