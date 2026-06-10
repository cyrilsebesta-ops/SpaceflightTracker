// Jak má vypadat struktura Misí

public class Mission
{
    public string Name { get; set; }
    public string LaunchDate { get; set; }
    public string LaunchVehicle { get; set; }
    public string LaunchSite { get; set; }
    public string Country { get; set; }
    public string Agency { get; set; }
    public string Objective { get; set; }
    public string Status { get; set; }
    public bool IsCrewed { get; set; }
    public string Crew { get; set; }
}