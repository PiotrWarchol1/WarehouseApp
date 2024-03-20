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
                .Where(x => x.Attribute("Manufacturer")?.Value == " Helmets Race")
                .Select(x => x.Attribute("Name")?.Value);

            foreach (var name in names)
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
                new XAttribute("Name", x.Name),
                new XAttribute("Combined", x.Combined),
                new XAttribute("Manufacturer", x.Manufacturer)
                )));
            document.Add(helmets);
            document.Save("Fuel.xml");
        }
    }
}