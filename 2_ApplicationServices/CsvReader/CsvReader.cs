using WarehouseApp.Components.CsvReader.Extensions;
using WarehouseApp.Components.CsvReader.Models;

namespace WarehouseApp.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Helmet> ProcessHelmets(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Helmet>();
            }
            var helmets =
                File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToHelmet();

            return helmets.ToList();
        }
    }
}
