// Třída obsahující data o Agenturách
public class AgencyService
{
    // Vytvoření seznamu agentur
    private List<Agency> agencies = new List<Agency>();

    // Konstruktor
    public AgencyService()
    {
        // Vytvoření objektu
        Agency nasa = new Agency();

        nasa.Name = "NASA (National Aeronautics and Space Administration)";
        nasa.Founded = "29 July 1958";
        nasa.Country = "USA (United States of America)";

        agencies.Add(nasa);

        
        // Vytvoření objektu
        Agency isro = new Agency();

        isro.Name = "ISRO (Indian Space Research Organisation)";
        isro.Founded = "15 August 1969";
        isro.Country = "India (Republic of India)";

        agencies.Add(isro);
        
        
        // Vytvoření objektu
        Agency esa = new Agency();

        esa.Name = "ESA (European Space Agency)";
        esa.Founded = "30 May 1975";
        esa.Country = "23 Member States (France, Germany, Italy, and others)";

        agencies.Add(esa);
        
        
        // Vytvoření objeku
        Agency csa = new Agency();

        csa.Name = "CSA (Canadian Space Agency)";
        csa.Founded = "1 March 1989";
        csa.Country = "Canada";

        agencies.Add(csa);

        
        // Vytvoření objektu
        Agency cnsa = new Agency();

        cnsa.Name = "CNSA (China National Space Administration)";
        cnsa.Founded = "22 April 1993";
        cnsa.Country = "China (People's Republic of China)";

        agencies.Add(cnsa);
        
        
        // Vytvoření objektu
        Agency spacex = new Agency();

        spacex.Name = "SpaceX (Space Exploration Technologies Corporation)";
        spacex.Founded = "14 March 2002";
        spacex.Country = "USA (United States of America)";
        
        agencies.Add(spacex);


        // Vytvoření objektu
        Agency jaxa = new Agency();

        jaxa.Name = "JAXA (Japan Aerospace Exploration Agency)";
        jaxa.Founded = "1 October 2003";
        jaxa.Country = "Japan";

        agencies.Add(jaxa);
        
        
        // Vytvoření objektu
        Agency lab = new Agency();
        
        lab.Name = "Rocket Lab Corporation";
        lab.Founded = "2006";
        lab.Country = "New Zealand USA (United States of America)";
        
        agencies.Add(jaxa);
        
        
        // Vytvoření objektu
        Agency roskosmos = new Agency();

        roskosmos.Name = "Roskosmos";
        roskosmos.Founded = "2015";
        roskosmos.Country = "Russia (Russian Federation)";

        agencies.Add(roskosmos);
    }
    
    public void ShowAgencyNames()
    {
        foreach (Agency agency in agencies)
        {
            Console.WriteLine("- " + agency.Name);
        }
    }

    public void ShowAgencyDetail(string name)
    {
        foreach (Agency agency in agencies)
        {
            if (agency.Name.ToLower().Contains(name.ToLower()))
            {
                Console.WriteLine("Agency: " + agency.Name);
                Console.WriteLine("Founded: " + agency.Founded);
                Console.WriteLine("Country: " + agency.Country);
                return;
            }
        }

        Console.WriteLine("Agency not found.");
    }
    }