using WarehouseApp.Components.CsvReader;
using System.Xml.Linq;

namespace WarehouseApp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;
        public App(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }
        public void Run()
        {
            CreateXml();
            QueryXml();
        }

        private static void QueryXml()
        {
            var document = XDocument.Load("Fuel.xml");
            var names = document
                .Element("Helmets")?
                .Elements("Helmet")
                .Where(x => x.Attribute("Manufacturer")?.Value == "Helmet Race")
                .Select(x => x.Attribute("Name")?.Value);

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private void CreateXml()
        {
            var records = _csvReader.ProcessHelmets("Resources\\Files\\Fuel.csv");

            var document = new XDocument();
            var helmets = new XElement("Helmets", records
                .Select(x =>
                new XElement("Helmet",
                new XAttribute("Division", x.Division),
                new XAttribute("Combined", x.Combined),
                new XAttribute("Manufacturer", x.Manufacturer))));
            document.Add(helmets);
            document.Save("Fuel.xml");
        }
    }
}



/*var groups = helmets
    .GroupBy(x => x.Manufacturer)
    .Select(g => new
    {
        Name = g.Key,
        Max = g.Max(c => c.Combined),
        Average = g.Average(c => c.Combined),
    })
    .OrderBy(x => x.Average);
foreach (var group in groups)
{
    Console.WriteLine($"{group.Name}");
    Console.WriteLine($"\t Max: {group.Max}");
    Console.WriteLine($"\t Average: {group.Average}");

}*/


/*            var helmetsInCountry = helmets.Join(
                manufacturers,
                x => x.Manufacturer,
                x => x.Name,
                (helmet, manufacturer) =>
                new
                {
                    manufacturer.Country,
                    helmet.Name,
                    helmet.Combined
                })
                .OrderByDescending(X => X.Combined)
                .ThenBy(x => x.Name);

            foreach (var helmet in helmetsInCountry)
            {
                Console.WriteLine($"{helmet.Country}");
                Console.WriteLine($"\t Max: {helmet.Name}");
                Console.WriteLine($"\t Average: {helmet.Combined}");

            }*/


/*private readonly IUserComunication _userComunication;
public App(IUserComunication userComunication)
{
    _userComunication = userComunication;
}
public void Run()
{
    _userComunication.Comunication();
*/


