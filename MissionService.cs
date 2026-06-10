using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class MissionService
{
    private HttpClient httpClient = new HttpClient();

    public async Task ShowPreviousMission()
    {
        string url = "https://ll.thespacedevs.com/2.3.0/launches/previous/?limit=1";

        try
        {
            string json = await httpClient.GetStringAsync(url);

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement mission = document.RootElement.GetProperty("results")[0];

            Console.WriteLine("=== PREVIOUS MISSION ===");
            Console.WriteLine();

            ShowMission(mission);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not load previous mission.");
            Console.WriteLine(ex.Message);
        }
    }

    public async Task ShowActualMissions()
    {
        DateTime today = DateTime.Today;
        DateTime tomorrow = today.AddDays(1);

        string start = today.ToString("yyyy-MM-dd");
        string end = tomorrow.ToString("yyyy-MM-dd");

        string url = "https://ll.thespacedevs.com/2.3.0/launches/?net__gte=" + start + "&net__lt=" + end + "&limit=5";

        try
        {
            string json = await httpClient.GetStringAsync(url);

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement missions = document.RootElement.GetProperty("results");

            Console.WriteLine("=== TODAY MISSIONS ===");
            Console.WriteLine();

            bool found = false;

            foreach (JsonElement mission in missions.EnumerateArray())
            {
                found = true;
                ShowMission(mission);
            }

            if (!found)
            {
                Console.WriteLine("No missions today.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not load today missions.");
            Console.WriteLine(ex.Message);
        }
    }
    
    public async Task ShowUpcomingMissions()
    {
        string url = "https://ll.thespacedevs.com/2.3.0/launches/upcoming/?limit=5";

        try
        {
            string json = await httpClient.GetStringAsync(url);

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement missions = document.RootElement.GetProperty("results");

            Console.WriteLine("=== UPCOMING MISSIONS ===");
            Console.WriteLine();

            foreach (JsonElement mission in missions.EnumerateArray())
            {
                ShowMission(mission);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not load upcoming missions.");
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowMission(JsonElement mission)
    {
        string fullName = mission
            .GetProperty("name")
            .GetString();
        
        string launchVehicle = fullName;
        string objective = "Unknown";

        if (fullName.Contains("|"))
        {
            string[] parts = fullName.Split('|');

            launchVehicle = parts[0].Trim();

            objective = parts[1].Trim();
        }
        
        string date = mission.GetProperty("net").GetString();
        
        string agency = mission.GetProperty("launch_service_provider").GetProperty("name").GetString();
        
        string launchSite = "Unknown";
        if (mission.TryGetProperty("pad", out JsonElement pad))
        {
            if (pad.TryGetProperty("name", out JsonElement padName))
            {
                launchSite = padName.GetString();
            }
        }
        
        string country = "Unknown";
        if (mission.TryGetProperty("pad", out JsonElement locationPad))
        {
            if (locationPad.TryGetProperty("location", out JsonElement location))
            {
                if (location.TryGetProperty("country_code", out JsonElement countryCode))
                {
                    country = countryCode.GetString();
                }
            }
        }
        
        string status = mission
            .GetProperty("status")
            .GetProperty("name")
            .GetString();

        DateTime parsedDate = DateTime.Parse(date);
        date = parsedDate.ToLocalTime().ToString("dd.MM.yyyy HH:mm");
        
        Console.WriteLine("LaunchDate: " + date);
        Console.WriteLine("LaunchVehicle: " + launchVehicle);
        Console.WriteLine("Objective: " + objective);
        Console.WriteLine("Agency: " + agency);
        Console.WriteLine("LaunchSite: " + launchSite);
        Console.WriteLine("Status: " + status);
        Console.WriteLine();
    }
}

