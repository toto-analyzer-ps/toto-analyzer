using System;
using System.Collections.Generic;
using System.Linq;

public class Visualizer
{
    public void BarChart(Dictionary<int, int> data)
    {
        int max = data.Values.Max();

        foreach (var x in data)
        {
            int len = (int)((x.Value / (double)max) * 20);
            Console.WriteLine($"{x.Key,2} | {new string('#', len)} {x.Value}");
        }
    }

    public void HeatMap(Dictionary<int, int> freq)
    {
        int max = freq.Values.Max();

        for (int i = 1; i <= 49; i++)
        {
            int val = freq.ContainsKey(i) ? freq[i] : 0;

            double p = val / (double)max;

            if (p > 0.7) Console.ForegroundColor = ConsoleColor.Red;
            else if (p > 0.4) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write($"{i,3}");

            if (i % 7 == 0) Console.WriteLine();
        }

        Console.ResetColor();
    }
}