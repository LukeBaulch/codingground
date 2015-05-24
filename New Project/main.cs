using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        var watch = new Stopwatch();
        watch.Start();
        
        var values = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
        var matches = RecursiveCheck(new int[0], values);
        
        watch.Stop();
        Console.WriteLine("{0} matches of {1} combinations in {2}ms", matches, values.Aggregate(1, (a, b) => a*b), watch.ElapsedMilliseconds);
        Console.ReadKey();
    }

    private static int RecursiveCheck(int[] used, int[] remaining)
    {
        if (remaining.Length != 0)
        {
            var matches = 0;
            foreach (var value in remaining)
            {
                matches += RecursiveCheck(used.Union(new[] {value}).ToArray(), remaining.Where(x => x != value).ToArray());
            }
            return matches;
        }
        return Equation(used[0], used[1], used[2], used[3], used[4], used[5], used[6], used[7], used[8]) ? 1 : 0;
    }

    private static bool Equation(int a, int b, int c, int d, int e, int f, int g, int h, int i)
    {
        return a + 13*b/c + d + 12*e - f - 11 + g*h/i - 10 == 66;
    }
}
