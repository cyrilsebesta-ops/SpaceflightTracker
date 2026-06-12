using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ISSTracker
{
    private HttpClient httpClient = new HttpClient();

    public async Task StartIssTracker()
    {
        Console.WriteLine("Press Q to stop tracker.");
        Console.WriteLine();

        while (true)
        {
            Console.Clear();

            await ShowIssPosition();

            Console.WriteLine();
            Console.WriteLine("Updating every 5 seconds...");
            Console.WriteLine("Press Q to return.");

            for (int i = 0; i < 50; i++)
            {
                await Task.Delay(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Q)
                    {
                        Console.Clear();
                        return;
                    }
                }
            }
        }
    }



    private async Task ShowIssPosition()
    {
        string url = "https://api.wheretheiss.at/v1/satellites/25544";

        try
        {
            string json = await httpClient.GetStringAsync(url);

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement iss = document.RootElement;

            double latitude = iss.GetProperty("latitude").GetDouble();

            double longitude = iss.GetProperty("longitude").GetDouble();

            double altitude = iss.GetProperty("altitude").GetDouble();

            double velocity = iss.GetProperty("velocity").GetDouble();

            string location = await GetLocation(latitude, longitude);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=== ISS LIVE TRACKER ===");

            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine("Name: International Space Station");

            Console.WriteLine("Status: Active");

            Console.WriteLine("Position: "
                + latitude.ToString("0.00")
                + ", "
                + longitude.ToString("0.00"));

            Console.WriteLine("Latitude: "
                + latitude.ToString("0.00"));

            Console.WriteLine("Longitude: "
                + longitude.ToString("0.00"));

            Console.WriteLine("Altitude: "
                + altitude.ToString("0.00")
                + " km");

            Console.WriteLine("Velocity: "
                + velocity.ToString("0.00")
                + " km/h");

            Console.WriteLine("Flying over: " + location);
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Could not load ISS data.");

            Console.ResetColor();
        }
    }



    private async Task<string> GetLocation(double latitude, double longitude)
    {
        string url =
            "https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat="
            + latitude
            + "&lon="
            + longitude;

        try
        {
            httpClient.DefaultRequestHeaders.UserAgent.Clear();

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("SpaceflightTracker");

            string json = await httpClient.GetStringAsync(url);

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement root = document.RootElement;

            if (root.TryGetProperty("address", out JsonElement address))
            {
                if (address.TryGetProperty("country", out JsonElement country))
                {
                    return country.GetString();
                }

                if (address.TryGetProperty("state", out JsonElement state))
                {
                    return state.GetString();
                }

                if (address.TryGetProperty("county", out JsonElement county))
                {
                    return county.GetString();
                }

                if (address.TryGetProperty("ocean", out JsonElement ocean))
                {
                    return ocean.GetString();
                }
            }

            return "Ocean or unknown area";
        }
        catch
        {
            return "Unknown area";
        }
    }
}