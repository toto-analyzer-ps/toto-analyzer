using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class DataLoader
{
    private HttpClient client = new HttpClient();

    public async Task<IEnumerable<Draw>> Load()
    {
        try
        {
            string url = "https://info.toto.bg/statistika/6x49.json";

            string json = await client.GetStringAsync(url);

            return JsonSerializer.Deserialize<List<Draw>>(json);
        }
        catch
        {
            // fallback тестови данни
            return new List<Draw>
            {
                new Draw { Year = 2024, Numbers = new List<int>{1,5,7,12,20,33} },
                new Draw { Year = 2024, Numbers = new List<int>{2,5,9,12,33,40} },
                new Draw { Year = 2025, Numbers = new List<int>{1,7,11,20,33,45} },
                new Draw { Year = 2025, Numbers = new List<int>{5,7,12,20,33,49} }
            };
        }
    }
}