using System;
using System.Collections.Generic;

public class HistoryService
{
    private List<Mission> historicMissions = new List<Mission>();

    public HistoryService()
    {
        
        Mission sputnik1 = new Mission();

        sputnik1.Name = "Sputnik 1";
        sputnik1.LaunchDate = "4 October 1957";
        sputnik1.LaunchVehicle = "R-7";
        sputnik1.LaunchSite = "Baikonur Cosmodrome, Tyuratam, Kazakh SSR (modern-day Kazakhstan)";
        sputnik1.Country = "USSR";
        sputnik1.Agency = "Soviet Space Program";
        sputnik1.Objective = "First artificial satellite";
        sputnik1.Status = "Mission completed, Sputnik 1 became Earth first artificial satellite";
        sputnik1.IsCrewed = false;
        sputnik1.Crew = "";

        historicMissions.Add(sputnik1);

        Mission vostok1 = new Mission();

        vostok1.Name = "Vostok 1";
        vostok1.LaunchDate = "12 April 1961";
        vostok1.LaunchVehicle = "Vostok-K";
        vostok1.LaunchSite = "Baikonur Cosmodrome, Tyuratam, Kazakh SSR (modern-day Kazakhstan)";
        vostok1.Country = "USSR";
        vostok1.Agency = "Soviet Space Program";
        vostok1.Objective = "First crewed spaceflight";
        vostok1.Status = "Mission completed, Yuri Gagarin became first human in Space";
        vostok1.IsCrewed = true;
        vostok1.Crew = "Yuri Gagarin";

        historicMissions.Add(vostok1);

        Mission voschod2 = new Mission();

        voschod2.Name = "Voschod 2";
        voschod2.LaunchDate = "18 March 1965";
        voschod2.LaunchVehicle = "Voschod";
        voschod2.LaunchSite = "Baikonur Cosmodrome, Tyuratam, Kazakh SSR (modern-day Kazakhstan)";
        voschod2.Country = "USSR";
        voschod2.Agency = "Soviet Space Program";
        voschod2.Objective = "First spacewalk";
        voschod2.Status = "Mission completed, Alexei Leonov became first human to perform Spacewalk";
        voschod2.IsCrewed = true;
        voschod2.Crew = "Pavel Belyayev, Alexei Leonov";

        historicMissions.Add(voschod2);

        Mission apollo8 = new Mission();

        apollo8.Name = "Apollo 8";
        apollo8.LaunchDate = "21 December 1968";
        apollo8.LaunchVehicle = "Saturn V";
        apollo8.LaunchSite = "Kennedy Space Center Launch Complex 39, Merritt Island, Florida, USA";
        apollo8.Country = "USA";
        apollo8.Agency = "NASA";
        apollo8.Objective = "First crewed Moon orbit mission";
        apollo8.Status = "Mission completed, Frank Borman, Jim Lovell and William Anders became the first humans to travel beyond Low Earth Orbit";
        apollo8.IsCrewed = true;
        apollo8.Crew = "Frank Borman, Jim Lovell, William Anders";

        historicMissions.Add(apollo8);

        Mission apollo11 = new Mission();

        apollo11.Name = "Apollo 11";
        apollo11.LaunchDate = "16 July 1969";
        apollo11.LaunchVehicle = "Saturn V";
        apollo11.LaunchSite = "Kennedy Space Center Launch Complex 39, Merritt Island, Florida, USA";
        apollo11.Country = "USA";
        apollo11.Agency = "NASA";
        apollo11.Objective = "First Moon landing";
        apollo11.Status = "Mission completed, On the 20 July 1969 Neil Armstrong and Buzz Aldrin became first humans on the Moon";
        apollo11.IsCrewed = true;
        apollo11.Crew = "Neil Armstrong, Buzz Aldrin, Michael Collins";

        historicMissions.Add(apollo11);
    }
    
    public void ShowMissionNames()
    {
        foreach (Mission mission in historicMissions)
        {
            Console.WriteLine("- " + mission.Name);
        }
    }

    public void ShowMissionDetail(string name)
    {
        foreach (Mission mission in historicMissions)
        {
            if (mission.Name.ToLower().Replace(" ", "").Contains(name.ToLower()))
            {
                Console.WriteLine("Mission: " + mission.Name);
                Console.WriteLine("Launch Date: " + mission.LaunchDate);
                Console.WriteLine("Launch Vehicle: " + mission.LaunchVehicle);
                Console.WriteLine("Launch Site: " + mission.LaunchSite);
                Console.WriteLine("Agency: " + mission.Agency);
                Console.WriteLine("Objective: " + mission.Objective);
                Console.WriteLine("Status: " + mission.Status);

                if (mission.IsCrewed)
                {
                    Console.WriteLine("Crew: " + mission.Crew);
                }
                else
                {
                    Console.WriteLine("Crewed: No");
                }

                return;
            }
        }

        Console.WriteLine("Mission not found.");
    }
}