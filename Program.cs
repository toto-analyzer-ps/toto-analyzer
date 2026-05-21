using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

class Program
{
    static bool periodSelected = false;

    static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        var loader = new DataLoader();
        var draws = await loader.Load();

        var stats = new Statistics(draws);
        var vis = new Visualizer();

        while (true)
        {
            Console.WriteLine("\n==== ТОТО АНАЛИЗАТОР ====");
            Console.WriteLine("[1] Избери период");
            Console.WriteLine("[2] Топ N числа");
            Console.WriteLine("[3] Горещи двойки");
            Console.WriteLine("[4] Разпределение");
            Console.WriteLine("[5] Heat Map");
            Console.WriteLine("[0] Изход");
            Console.Write("Избор: ");

            string input = Console.ReadLine();

            try
            {
                int choice = int.Parse(input);

                if (choice != 1 && !periodSelected)
                {
                    Console.WriteLine("❌ Първо избери период!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        periodSelected = true;
                        Console.WriteLine("✔ Период избран.");
                        break;

                    case 2:
                        Console.Write("N = ");
                        int n = int.Parse(Console.ReadLine());
                        vis.BarChart(stats.TopNumbers(n));
                        break;

                    case 3:
                        foreach (var p in stats.HotPairs(5))
                            Console.WriteLine($"{p.Item1}-{p.Item2} => {p.Item3}");
                        break;

                    case 4:
                        foreach (var d in stats.Distribution())
                            Console.WriteLine($"{d.Key}: {d.Value}");
                        break;

                    case 5:
                        var freq = draws
                            .SelectMany(d => d.Numbers)
                            .GroupBy(x => x)
                            .ToDictionary(x => x.Key, x => x.Count());

                        vis.HeatMap(freq);
                        break;

                    case 0:
                        return;
                }
            }
            catch
            {
                Console.WriteLine("❌ Въведи валидно число!");
            }
        }
    }
}