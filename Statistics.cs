using System;
using System.Collections.Generic;
using System.Linq;

public class Statistics
{
    private IEnumerable<Draw> draws;

    public Statistics(IEnumerable<Draw> data)
    {
        draws = data;
    }

    public Dictionary<int, int> TopNumbers(int n)
    {
        return draws
            .SelectMany(d => d.Numbers)
            .GroupBy(x => x)
            .Select(g => new { Num = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(n)
            .ToDictionary(x => x.Num, x => x.Count);
    }

    public List<(int, int, int)> HotPairs(int n)
    {
        var dict = new Dictionary<(int, int), int>();

        foreach (var d in draws)
        {
            var nums = d.Numbers.Distinct().ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    var pair = (nums[i], nums[j]);

                    if (!dict.ContainsKey(pair))
                        dict[pair] = 0;

                    dict[pair]++;
                }
            }
        }

        return dict
            .OrderByDescending(x => x.Value)
            .Take(n)
            .Select(x => (x.Key.Item1, x.Key.Item2, x.Value))
            .ToList();
    }

    public Dictionary<string, int> Distribution()
    {
        var result = new Dictionary<string, int>
        {
            ["1-10"] = 0,
            ["11-20"] = 0,
            ["21-30"] = 0,
            ["31-40"] = 0,
            ["41-49"] = 0
        };

        foreach (var n in draws.SelectMany(d => d.Numbers))
        {
            if (n <= 10) result["1-10"]++;
            else if (n <= 20) result["11-20"]++;
            else if (n <= 30) result["21-30"]++;
            else if (n <= 40) result["31-40"]++;
            else result["41-49"]++;
        }

        return result;
    }
}