using System;
using System.Threading.Tasks;

public class CommandHandler
{
    private HistoryService historyService = new HistoryService();
    private AgencyService agencyService = new AgencyService();
    private MissionService missionService = new MissionService();
    private ISSTracker ISSTracker = new ISSTracker();

    public async Task HandleCommand(string command)
    {
        command = command.ToLower();
        
        if (command == "help")
        {
            ShowHelp();
        }
        else if (command == "clear")
        {
            Console.Clear();
        }
        else if (command == "history")
        {
            historyService.ShowMissionNames();
        }
        else if (command.StartsWith("history "))
        {
            string name = command.Replace("history ", "");
            historyService.ShowMissionDetail(name);
        }
        else if (command == "agencies")
        {
            agencyService.ShowAgencyNames();
        }
        else if (command.StartsWith("agency "))
        {
            string name = command.Replace("agency ", "");
            agencyService.ShowAgencyDetail(name);
        }
        else if (command == "actual")
        {
            await missionService.ShowActualMissions();
        }
        else if (command == "upcoming")
        {
            await missionService.ShowUpcomingMissions();
        }
        else if (command == "iss")
        {
            await ISSTracker.StartIssTracker();
        }
        else if (command == "exit")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Unknown command (write help).");
        }
    }

    private void ShowHelp()
    {
        Console.WriteLine("help - writes down all commands");
        Console.WriteLine("clear - clears the history");
        Console.WriteLine("upcoming - 5 upcoming rocket launch");
        Console.WriteLine("actual - actual rocket launch");
        Console.WriteLine("history - list of historic space missions");
        Console.WriteLine("history apollo11 - details about the mission");
        Console.WriteLine("agencies - list of the agencies");
        Console.WriteLine("agency nasa - details about the agency");
        Console.WriteLine("iss - live ISS position");    
        Console.WriteLine("exit - exits the program");
    }
}